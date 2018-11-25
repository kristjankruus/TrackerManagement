using UnityEngine;
using Valve.VR;

public partial class TrackerManager_Director : MonoBehaviour 
{
	public string appKey = "";

	[Space(10)]

	public Unity_Overlay menuOverlay;

	[Space(10)]

	public TrackerManager_Menu_Redux menuRig;
    
	[Space(10)]

	public int windowWidth = 800;
    public int windowHeight = 600;

	[Space(10)]

	public int runningFPS = 90;
	public int idleFPS = 5;

	[Space(10)]

	public GameObject hmdO;	

	private TrackerManager_Prefs_Handler prefs;
	private WindowController winC;
	private OVR_Handler handler;
	
	private int targetFPS = 0;
	private int lastFps = 0;

	void Start () 
	{
		// Init SteamWorks.net
		if(SteamManager.Initialized)
			Debug.Log("Starting up SteamWorks!");
		else
			Debug.Log("SteamWorks Init Failed!");
		
		targetFPS = idleFPS;

		prefs = GetComponent<TrackerManager_Prefs_Handler>();
		handler = OVR_Handler.instance;

		winC = GetComponent<WindowController>();

		// Some SteamCloud Stuff
		// Why the hell is this not a settable public property?
		string prefsPath = Application.dataPath + "/../";
		string prefsFileName = "prefs.json";

		prefs.SetFilePath(prefsPath, prefsFileName);
	}

	public void OnApplicationQuit()	 
	{
		 prefs.Save();
	}

	// @TODO - Fix the hell outta this mess
	// Refactor the whole speghetto-mixed app state
	void Update() 
	{
		UpdateFPS();
        UpdateFPS();

        SetWindowSize();
	}

	public void UpdateFPS()
	{
		if(lastFps != targetFPS)
		{
			lastFps = targetFPS;
			Application.targetFrameRate = targetFPS;
		}
	}
	
	// Recursion DOOMSDAY
	public void SetWindowSize(int lvl = 0, int maxLvl = 5)
    {
		if(Screen.width != windowWidth || Screen.height != windowHeight)
        	Screen.SetResolution(windowWidth, windowHeight, false);

        if(Screen.width != windowWidth || Screen.height != windowHeight)
		{
			if(lvl < maxLvl)
                SetWindowSize(lvl + 1, maxLvl);
		}    
    }

	public void OnSteamVRConnect()
	{
		targetFPS = runningFPS;
	}

	public void OnSteamVRDisconnect()
	{
		if(prefs.StartWithSteamVR)
		{
			// Logging Quit. On Quit.
			Debug.Log("Quitting!");

			Application.Quit();
		}
		else
			targetFPS = idleFPS;
	}

	bool ErrorCheck(EVRApplicationError err)
	{
		bool e = err != EVRApplicationError.None;

		if(e)
			Debug.Log("App Error: " + handler.Applications.GetApplicationsErrorNameFromEnum(err));

		return e;
	}
}
