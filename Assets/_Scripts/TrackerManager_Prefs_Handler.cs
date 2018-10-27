using System;
using System.IO;
using UnityEngine;
using Steamworks;

public class TrackerManager_Prefs_Handler : MonoBehaviour 
{       
    private TrackerManagerPrefs prefs = new TrackerManagerPrefs();
    private string _filePath = "";
    private string _fileName = "";

    public void SetFilePath(string path, string fileName)
    {
        _filePath = path;
        _fileName = fileName;
    }

    public float FollowSpeed 
    {
        get 
        {
            return prefs.FollowSpeed;
        }
        set 
        {
            value = value > 1f ? 1f : value;
            value = value < 0.1f ? 0.1f : value;

            prefs.FollowSpeed = value;
            Save();
        }
    }

    public bool StartWithSteamVR
    {
        get 
        {
            return prefs.StartWithSteamVR;
        }
        set
        {
            prefs.StartWithSteamVR = value;
            Save();
        }
    }

    public bool HideMainWindow 
    {
        get 
        {
            return prefs.HideMainWindow;
        }
        set 
        {
            prefs.HideMainWindow = value;
            Save();
        }
    }

    public bool FollowPlayerHeadset
    {
        get 
        {
            return prefs.FollowPlayerHeadset;
        }
        set
        {
            prefs.FollowPlayerHeadset = value;
            Save();
        }
    }
    
    public bool UseChaperoneColor 
    {
        get 
        {
            return prefs.UseChaperoneColor;
        }
        set 
        {
            prefs.UseChaperoneColor = value;
            Save();
        }
    }

    public bool LinkOpacityWithTwist
    {
        get 
        {
            return prefs.LinkOpacityWithTwist;
        }
        set 
        {
            prefs.LinkOpacityWithTwist = value;
            Save();
        }
    }

    public bool OnlyShowInDashboard 
    {
        get 
        {
            return prefs.OnlyShowInDashboard;
        }
        set 
        {
            prefs.OnlyShowInDashboard = value;
            Save();
        }
    }

    public bool ShowBatteryPercentage
    {
        get
        {
            return prefs.ShowBatteryPercentage;
        }
        set
        {
            prefs.ShowBatteryPercentage = value;
            Save();
        }
    }

    public TrackerManagerPrefsLinkDevice LinkDevice 
    {
        get 
        {
            return prefs.LinkDevice;
        }
        set 
        {
            prefs.LinkDevice = value;
            Save();
        }
    }

    public bool FlipSides 
    {
        get 
        {
            return prefs.FlipSides;
        }
        set 
        {
            prefs.FlipSides = value;
            Save();
        }
    }


    public bool Save(bool skipSteam = false, TrackerManagerPrefs overrideP = null)
    {
        TrackerManagerPrefs p;

        if(overrideP != null)
            p = overrideP;
        else
            p = prefs;

        p.lastEditTime = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

        string text = JsonUtility.ToJson(prefs, true);
        string fullP = _filePath + _fileName;

        Debug.Log("Writing Local Prefs!");
        File.WriteAllText(fullP, text);

        if(!skipSteam)
            SteamSave();

        return File.Exists(fullP);
    }

    public bool SteamSave() 
    {
        if(SteamManager.Initialized && SteamRemoteStorage.IsCloudEnabledForAccount())
        {
            string text = JsonUtility.ToJson(prefs, true);
            
            var bytes = System.Text.Encoding.ASCII.GetBytes(text);
            var byteCount = System.Text.Encoding.ASCII.GetByteCount(text);

            Debug.Log("Writing Prefs to SteamCloud!");
            return SteamRemoteStorage.FileWrite(_fileName, bytes, byteCount);
        }
        else
            return false;
    }

    public bool Load()
    {
        TrackerManagerPrefs fileP = FileLoad();
        TrackerManagerPrefs steamP = SteamLoad();

        bool res = false;
        
        bool skipSteam = false;
        TrackerManagerPrefs p = new TrackerManagerPrefs();

        if(fileP != null && steamP != null) 
        {
            if(fileP.lastEditTime >= steamP.lastEditTime)
                p = fileP;
            else 
            {
                p = steamP;
                skipSteam = true;
            }

            res = true;
        }
        else if(fileP == null && steamP != null)
        {
            p = steamP;
            skipSteam = true;
            res = true;
        }
        else if(fileP != null && steamP == null)
        {
            p = fileP;
            res = true;
        }
        
        prefs = p;
        Save(skipSteam);
        
        return res;
    }

    public TrackerManagerPrefs SteamLoad() 
    {
        if(SteamManager.Initialized && SteamRemoteStorage.IsCloudEnabledForAccount())
        {
            if(SteamRemoteStorage.FileExists(_fileName))
            {
                string text = "";
                var byteCount = SteamRemoteStorage.GetFileSize(_fileName);
                var bytes = new byte[byteCount];
                
                Debug.Log("Reading Prefs from SteamCloud!");
                var fileC = SteamRemoteStorage.FileRead(_fileName, bytes, byteCount);

                if(fileC > 0)
                    text = System.Text.Encoding.ASCII.GetString(bytes);
                    
                var o = (TrackerManagerPrefs) JsonUtility.FromJson(text, typeof(TrackerManagerPrefs));

                if(o != null)
                    return o;        
            }   
        }
        
        return null;
    }

    public TrackerManagerPrefs FileLoad()
    {
        string fullP = _filePath + _fileName;
        
        if(!File.Exists(fullP))
            return null;

        Debug.Log("Reading Local Prefs!");
        string text = File.ReadAllText(fullP);

        return (TrackerManagerPrefs) JsonUtility.FromJson(text, typeof(TrackerManagerPrefs));
    }

    public void Reset()
    {
        prefs = new TrackerManagerPrefs();
        Save();
        Load();
    }
}

// #enterpriseNames
public enum TrackerManagerPrefsLinkDevice 
{
    None,
    Right,
    Left
}

[Serializable] public class TrackerManagerPrefs 
{
    public Int32 lastEditTime = 0;

    public float FollowSpeed = 1f;

    public bool StartWithSteamVR = true;
    public bool HideMainWindow = false;

    public bool FollowPlayerHeadset = false;
    public bool UseChaperoneColor = false;
    public bool LinkOpacityWithTwist = false;

    public bool OnlyShowInDashboard = false;
    public bool ShowBatteryPercentage = false;

    public TrackerManagerPrefsLinkDevice LinkDevice = TrackerManagerPrefsLinkDevice.None;
    public bool FlipSides = false;
}
