using UnityEngine;

public class DropArea : MonoBehaviour
{
    [SerializeField] protected GameObject currentInstrument;
    public bool isOccupied => currentInstrument;

    public virtual void OnInstrumentDrop(Instrument instrument)
    {
        currentInstrument = instrument.gameObject;
        instrument.gameObject.transform.position = transform.position;

        
    }

    public void Clear()
    {
        currentInstrument = null;
    }
}
