using UnityEngine;
using UnityEngine.UI;

public class TrackerManager_Menu_Tracker_Selection : MonoBehaviour
{
    public Button Button;
    public Text Text;
    public int TrackerId;
    public SubMenu SubMenu { get; set; }

    void Start()
    {
        Button.onClick.AddListener(SetSubMenuActive);
    }

    private void SetSubMenuActive()
    {
        SubMenu.gameObject.SetActive(true);
        //SubMenu.SetTracker(TrackerId);
    }
}
