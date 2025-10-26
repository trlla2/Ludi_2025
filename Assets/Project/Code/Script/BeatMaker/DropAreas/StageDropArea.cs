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
            instrument.SetCurrentDropArea(this);
            instrument.gameObject.transform.position = transform.position;
            OnGoodDrop.Invoke();
            
        }
        else
        {
            Debug.Log(instrument.GetInstrumentType());
            instrument.SetCurrentDropArea(instrument.GetLastDropArea());
            instrument.SetPositionToCurrentDropAreaPosition();
            OnBadDrop.Invoke();
        }
    }
}
