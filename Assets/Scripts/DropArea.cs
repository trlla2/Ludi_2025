using UnityEngine;
using UnityEngine.Events;

public class DropArea : MonoBehaviour
{
    [SerializeField] private GameObject currentInstrument;
    [SerializeField] private InstrumentType requiredInstrumentType;
    public UnityEvent OnGoodDrop;
    public UnityEvent OnBadDrop;

    public bool isOccupied => currentInstrument;
    public void OnInstrumentDrop(Instrument instrument)
    {
        currentInstrument = instrument.gameObject;
        instrument.gameObject.transform.position = transform.position;

        if (instrument.GetInstrumentType() == requiredInstrumentType)
            OnGoodDrop.Invoke();
        else
            OnBadDrop.Invoke();
    }

    public void Clear()
    {
        currentInstrument = null;
    }
}
