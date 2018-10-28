using UnityEngine;
using UnityEngine.UI;

public class TrackerManager_Menu_Redux : MonoBehaviour 
{
	public Camera menuRigCamera;

	[Space(10)]
	
	public TrackerManager_Prefs_Handler prefs;
    public TrackerManager_Menu_BatteryLevel batteryMenu;

    [Space(5)]
	
	public Toggle startWithVRToggle;
	public Toggle hideMainWindowToggle;
	public Toggle useChapColorToggle;
	public Toggle onlyShowInDashToggle;

    [Space(5)]

	public Toggle disableLinkToggle;
	public Toggle rightLinkToggle;
	public Toggle leftLinkToggle;
	public Toggle flipSidesToggle;

	public void SteamStart()
	{

		if(!prefs.Load())			
			Debug.Log("Bad Settings Load!");

		SetUIValues();
	}

	public void SetUIValues()
	{
		startWithVRToggle.isOn = prefs.StartWithSteamVR;
		hideMainWindowToggle.isOn = prefs.HideMainWindow;

		useChapColorToggle.isOn = prefs.UseChaperoneColor;

		onlyShowInDashToggle.isOn = prefs.OnlyShowInDashboard;

        disableLinkToggle.isOn = prefs.LinkDevice == TrackerManagerPrefsLinkDevice.None;

		rightLinkToggle.isOn = prefs.LinkDevice == TrackerManagerPrefsLinkDevice.Right;
		leftLinkToggle.isOn = prefs.LinkDevice == TrackerManagerPrefsLinkDevice.Left;

		flipSidesToggle.isOn = prefs.FlipSides;

        batteryMenu.SetUIValues();
    }

	public void ResetSettings()
	{
		prefs.Reset();
		SetUIValues();
	}
}