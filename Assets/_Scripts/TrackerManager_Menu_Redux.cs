using UnityEngine;
using UnityEngine.UI;

public class TrackerManager_Menu_Redux : MonoBehaviour 
{
	public Camera menuRigCamera;

	[Space(10)]
	
	public TrackerManager_Prefs_Handler prefs;

	[Space(10)]

	public Slider heightSlider;

	[Space(5)]
	
	public Toggle startWithVRToggle;
	public Toggle hideMainWindowToggle;
	public Toggle useChapColorToggle;
	public Toggle onlyShowInDashToggle;
    public Toggle showBatteryToggle;

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
		heightSlider.value = prefs.Height;

		startWithVRToggle.isOn = prefs.StartWithSteamVR;
		hideMainWindowToggle.isOn = prefs.HideMainWindow;

		useChapColorToggle.isOn = prefs.UseChaperoneColor;

		onlyShowInDashToggle.isOn = prefs.OnlyShowInDashboard;

        showBatteryToggle.isOn = prefs.ShowBatteryPercentage;

        disableLinkToggle.isOn = prefs.LinkDevice == TrackerManagerPrefsLinkDevice.None;

		rightLinkToggle.isOn = prefs.LinkDevice == TrackerManagerPrefsLinkDevice.Right;
		leftLinkToggle.isOn = prefs.LinkDevice == TrackerManagerPrefsLinkDevice.Left;

		flipSidesToggle.isOn = prefs.FlipSides;
	}

	public void ResetSettings()
	{
		prefs.Reset();
		SetUIValues();
	}
}