using System.Collections;
using UnityEngine;

public enum InstrumentType
{
    ELECTRIC_GUITAR,
    ACOUSTICGUITAR,
    BASS,
    DRUMS,
    CAJON,
    PALMAS,
    PIANO,
    MICROPHONE,
    BONGOS,
    FLUTE,
    VIOLIN,
    HARMONICA
}

public class Instrument : MonoBehaviour
{
    private Collider2D collision;
    private DropArea lastDropArea;
    [SerializeField] private DropArea currentDropArea;
    [SerializeField] private InstrumentType type;

    private void Start()
    {
        collision = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        //startDragPosition = transform.position;
        //transform.position = GetMousePositionInWorldSpace();
        if (currentDropArea != null)
        {
            lastDropArea = currentDropArea;
            currentDropArea.Clear();
        }
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePositionInWorldSpace();
    }

    private void OnMouseUp()
    {
        if (collision.enabled)
        {
            collision.enabled = false;
            Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
            //StartCoroutine(RestoreColliderNextFrame());
            collision.enabled = true;

            if (hitCollider != null && hitCollider.TryGetComponent(out DropArea instrumentDropArea) && !instrumentDropArea.isOccupied)
            {
                instrumentDropArea.OnInstrumentDrop(this);
                currentDropArea = instrumentDropArea;
            }
            else
            {
                currentDropArea = lastDropArea;
                currentDropArea.SetCurrentInstrument(this.gameObject);
                SetPositionToCurrentDropAreaPosition();
                //SetPositionToStartingDragPosition();
            }
        }
    }

    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;

        return mousePos;
    }

    private IEnumerator RestoreColliderNextFrame()
    {
        yield return null;
        collision.enabled = true;
    }

    public void SetPositionToCurrentDropAreaPosition()
    {
        transform.position = currentDropArea.transform.position;
    }

    public InstrumentType GetInstrumentType() { return type; }

}
