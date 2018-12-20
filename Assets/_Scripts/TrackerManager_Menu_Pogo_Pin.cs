using UnityEngine;

public class TrackerManager_Menu_Pogo_Pin : MonoBehaviour
{
    public RectTransform Content;
    public TrackerManager_Menu_Tracker_Selection TrackerSelection;
    public TrackerManagement_Menu_Input_Output InputOutputMenu;
    public OVR_Handler ovrHandler = OVR_Handler.instance;

    public void SetActive()
    {
        int counter = 0;
        foreach (var tracker in ovrHandler.GetTrackers())
        {
            var selection = Instantiate(TrackerSelection, Vector3.zero, Quaternion.identity);
            //inputOutputMenu.SetTracker(tracker.Key);
            selection.SubMenu = InputOutputMenu;
            selection.TrackerId = tracker.Key;
            selection.Text.text = tracker.Value;
            selection.gameObject.GetComponent<Transform>().SetParent(Content);
            selection.gameObject.GetComponent<Transform>().localScale = new Vector3(.5f, .5f, .5f);
            selection.gameObject.GetComponent<Transform>().localRotation = Quaternion.identity;
            selection.gameObject.GetComponent<Transform>().localPosition = new Vector3(0, (float)-11.5 * counter, 0);
            counter++;
        }
    }
}
