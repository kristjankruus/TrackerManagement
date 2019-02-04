using UnityEngine;

public class Tracker_Role_Panel : MonoBehaviour
{
    public OVR_Handler ovrHandler = OVR_Handler.instance;
    // Start is called before the first frame update
    void Start()
    {
        ovrHandler.GetTrackersFromSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
