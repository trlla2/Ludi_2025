using UnityEngine;

public class Instrument : MonoBehaviour
{
    private Collider2D collision;
    private Vector3 startDragPosition;
    private DropArea currentDropArea;

    private void Start()
    {
        collision = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        startDragPosition = transform.position;
        //transform.position = GetMousePositionInWorldSpace();
        if (currentDropArea != null)
        {
            currentDropArea.Clear();
            currentDropArea = null;
        }
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePositionInWorldSpace();
    }

    private void OnMouseUp()
    {
        collision.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        collision.enabled = true;

        if (hitCollider != null && hitCollider.TryGetComponent(out DropArea instrumentDropArea) && !instrumentDropArea.isOccupied)
        {
            instrumentDropArea.OnInstrumentDrop(this.gameObject);
            currentDropArea = instrumentDropArea;
        }
        else
        {
            transform.position = startDragPosition;
        }
    }

    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;

        return mousePos;
    }

}
