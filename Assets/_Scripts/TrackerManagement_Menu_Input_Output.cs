using System;
using UnityEngine;
using UnityEngine.UI;

public class TrackerManagement_Menu_Input_Output : MonoBehaviour
{
    public Text Input1Active;
    public Text Input2Active;
    public Text Input3Active;
    public Text Input4Active;
    public Toggle outputToggle;    

    // Use this for initialization
    void Start()
    {
        outputToggle.onValueChanged.AddListener(delegate { OutputToggleValueChange(); });
    }

    private void OutputToggleValueChange()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
