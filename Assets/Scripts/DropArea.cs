using UnityEngine;

public class DropArea : MonoBehaviour
{
    private GameObject currentInstrument;

    public bool isOccupied => currentInstrument;
    public void OnInstrumentDrop(GameObject instrument)
    {
        currentInstrument = instrument;
        instrument.transform.position = transform.position;
    }

    public void Clear()
    {
        currentInstrument = null;
    }
}
