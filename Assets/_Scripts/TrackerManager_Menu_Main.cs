using UnityEngine;
using UnityEngine.UI;

public class TrackerManager_Menu_Main : MonoBehaviour
{
    public RectTransform MainMenu;
    public RectTransform GeneralMenu;
    public RectTransform BatterySettingsMenu;
    public Tracker_Selection TrackerRolesMenu;
    public RectTransform FullBodyMenu;
    public Tracker_Selection PogoPinMenu;
    [Space(10)]
    public Button GeneralSettingsButton;
    public Button BatteryManagementButton;
    public Button TrackerRolesButton;
    public Button FullBodyButton;
    public Button PogoPinButton;
    [Space(10)]
    public GameObject BackButton;

    private void Start()
    {
        GeneralSettingsButton.onClick.AddListener(SetGeneralSettingsActive);
        BatteryManagementButton.onClick.AddListener(SetBatteryManagementSettingsActive);
        TrackerRolesButton.onClick.AddListener(SetTrackerRoleSettingsActive);
        FullBodyButton.onClick.AddListener(SetFullBodySettingsActive);
        PogoPinButton.onClick.AddListener(SetPogoPinSettingsActive);
    }

    private void SetMenusInactive()
    {
        GeneralMenu.gameObject.SetActive(false);
        BatterySettingsMenu.gameObject.SetActive(false);
        TrackerRolesMenu.gameObject.SetActive(false);
        FullBodyMenu.gameObject.SetActive(false);
    }    

    private void SetGeneralSettingsActive()
    {
        SetMenusInactive();
        GeneralMenu.gameObject.SetActive(true);
    }

    private void SetBatteryManagementSettingsActive()
    {
        SetMenusInactive();
        BatterySettingsMenu.gameObject.SetActive(true);
    }

    private void SetTrackerRoleSettingsActive()
    {
        SetMenusInactive();
        TrackerRolesMenu.gameObject.SetActive(true);
        TrackerRolesMenu.SetActive();
        SetBackButtonActive();
        gameObject.SetActive(false);
    }

    private void SetFullBodySettingsActive()
    {
        SetMenusInactive();
        FullBodyMenu.gameObject.SetActive(true);
        SetBackButtonActive();
        gameObject.SetActive(false);
    }

    private void SetPogoPinSettingsActive()
    {
        SetMenusInactive();
        PogoPinMenu.gameObject.SetActive(true);
        PogoPinMenu.SetActive();
        SetBackButtonActive();
        gameObject.SetActive(false);
    }

    private void SetBackButtonActive()
    {
        BackButton.SetActive(true);
    }
}
