using UnityEngine;

public class TrackerManagement_Menu_Input_Output : MonoBehaviour
{
    public TrackerManager_Menu_Pogo_Simulate SimulateInput1;
    public TrackerManager_Menu_Pogo_Simulate SimulateInput2;
    public TrackerManager_Menu_Pogo_Simulate SimulateInput3;
    public TrackerManager_Menu_Pogo_Simulate SimulateInput4;
    public TrackerManager_Menu_Pogo_Simulate SimulateOutput;

    public TrackerManager_Tracker Tracker;

    // Use this for initialization
    void Start()
    {
        SimulateInput1.TrackerPin = Tracker.Input1;
        SimulateInput2.TrackerPin = Tracker.Input2;
        SimulateInput3.TrackerPin = Tracker.Input3;
        SimulateInput4.TrackerPin = Tracker.Input4;
        SimulateOutput.TrackerPin = Tracker.Output;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
