using UnityEngine;
using UnityEngine.Events;

public class StageDropArea : DropArea
{
    [SerializeField] private InstrumentType requiredInstrumentType;

    public UnityEvent OnGoodDrop;
    public UnityEvent OnBadDrop;

    public override void OnInstrumentDrop(Instrument instrument) 
    {
        if (instrument.GetInstrumentType() == requiredInstrumentType)
        {
            currentInstrument = instrument.gameObject;
            instrument.gameObject.transform.position = transform.position;
            OnGoodDrop.Invoke();
        }
        else
        {
            instrument.SetPositionToStartingDragPosition();
            OnBadDrop.Invoke();
        }
    }
}
