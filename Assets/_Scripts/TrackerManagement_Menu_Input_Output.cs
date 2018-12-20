using UnityEngine;

public class TrackerManagement_Menu_Input_Output : MonoBehaviour
{
    public TrackerManager_Menu_Pogo_Simulate SimulateInput1;
    public TrackerManager_Menu_Pogo_Simulate SimulateInput2;
    public TrackerManager_Menu_Pogo_Simulate SimulateInput3;
    public TrackerManager_Menu_Pogo_Simulate SimulateInput4;
    public TrackerManager_Menu_Pogo_Simulate SimulateOutput;
    
    public TrackerManager_Tracker Tracker { get; set; }
    public OVR_Handler ovrHandler = OVR_Handler.instance;

    public void SetTracker(int trackerId)
    {
        SimulateInput1.TrackerPin = Tracker.Input1;
        SimulateInput2.TrackerPin = Tracker.Input2;
        SimulateInput3.TrackerPin = Tracker.Input3;
        SimulateInput4.TrackerPin = Tracker.Input4;
        SimulateOutput.TrackerPin = Tracker.Output;
    }
}
