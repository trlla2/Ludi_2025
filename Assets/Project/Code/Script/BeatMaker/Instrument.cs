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
        if (currentDropArea != null)
        {
            lastDropArea = currentDropArea;
            currentDropArea.Clear();
            currentDropArea = null;
        }
        Debug.Log(gameObject.name + lastDropArea.name);
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
            collision.enabled = true;

            if (hitCollider != null && hitCollider.TryGetComponent(out DropArea instrumentDropArea) && !instrumentDropArea.isOccupied)
            {
                instrumentDropArea.OnInstrumentDrop(this);
            }
            else
            {
                Debug.Log("ei");
                SetCurrentDropArea(lastDropArea);
                currentDropArea.SetCurrentInstrument(this.gameObject);
                SetPositionToCurrentDropAreaPosition();
            }
        }
    }

    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;

        return mousePos;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }

    public void SetPositionToCurrentDropAreaPosition()
    {
        transform.position = new Vector3(currentDropArea.transform.position.x, currentDropArea.transform.position.y, transform.position.z);
    }

    public void SetCurrentDropArea(DropArea dropArea)
    {
        if (currentDropArea == null)
            currentDropArea = dropArea;
    }

    public InstrumentType GetInstrumentType() { return type; }

    public DropArea GetLastDropArea() { return lastDropArea; }

}
