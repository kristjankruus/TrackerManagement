using UnityEngine;
using UnityEngine.UI;

public class TrackerManager_Menu_Main : MonoBehaviour
{
    public RectTransform MainMenu;
    public RectTransform GeneralMenu;
    public RectTransform BatterySettingsMenu;
    public RectTransform TrackerRolesMenu;
    public RectTransform FullBodyMenu;
    [Space(10)]
    public Button GeneralSettingsButton;
    public Button BatteryManagementButton;
    public Button TrackerRolesButton;
    public Button FullBodyButton;

    private void Start()
    {
        GeneralSettingsButton.onClick.AddListener(SetGeneralSettingsActive);
        BatteryManagementButton.onClick.AddListener(SetBatteryManagementSettingsActive);
        TrackerRolesButton.onClick.AddListener(SetTrackerRoleSettingsActive);
        FullBodyButton.onClick.AddListener(SetFullBodySettingsActive);
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
    }

    private void SetFullBodySettingsActive()
    {
        SetMenusInactive();
        FullBodyMenu.gameObject.SetActive(true);
    }
}
