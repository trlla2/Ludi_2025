using UnityEngine;

public class DropArea : MonoBehaviour
{
    [SerializeField] protected GameObject currentInstrument;
    public bool isOccupied => currentInstrument;
    private void Update()
    {
        //Debug.Log(isOccupied + this.gameObject.name);
    }

    public virtual void OnInstrumentDrop(Instrument instrument)
    {
        SetCurrentInstrument(instrument.gameObject);
        instrument.SetPosition(this.transform.position);
        instrument.SetCurrentDropArea(this);
    }

    public void Clear()
    {
        currentInstrument = null;
    }

    public void SetCurrentInstrument(GameObject instrument) 
    { 
        if(currentInstrument == null)
            currentInstrument = instrument; 
    }
}
