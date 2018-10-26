public partial class TrackerManager_Director
{
    // Methods for Easy UI.
	public void SetHideMainWindow(bool hideWin) 
	{
		if(hideWin)
		{
			menuOverlay.dontForceRenderTexture = false;
			menuRig.menuRigCamera.enabled = false;

			winC.HideUnityWindow();
			winC.ShowTrayIcon();
		}
		else
		{
			menuOverlay.dontForceRenderTexture = true;
			menuRig.menuRigCamera.enabled = true;

			winC.ShowUnityWindow();
			winC.HideTrayIcon();
		}
	}

	public void OnShowWindow()
	{
		menuRig.hideMainWindowToggle.isOn = false;
	}

	public void SetManifestAutoLaunch(bool autoLaunch)
	{
		if(handler != null && handler.Applications != null)
			handler.Applications.SetApplicationAutoLaunch(appKey, autoLaunch);
	}

	public bool GetManifestAutoLaunch()
	{
		return (handler != null && handler.Applications != null) ? handler.Applications.GetApplicationAutoLaunch(appKey) : false; 
	}
}