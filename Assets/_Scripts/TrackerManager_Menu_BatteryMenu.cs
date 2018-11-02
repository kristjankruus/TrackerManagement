using UnityEngine;
using UnityEngine.UI;

public class TrackerManager_Menu_BatteryMenu : MonoBehaviour
{
    public TrackerManager_Prefs_Handler prefs;
    [Space(10)]
    public Toggle showBatteryPercentage;
    public Toggle showWhenBatteryLow;
    public Toggle notifyWhenBatteryLow;
    public Dropdown batteryLowThreshold;
    public Slider colorSlider;
    public Image colorHandle;
    public Slider opacitySlider;
    public Image opacityHandle;

    void Start()
    {
        colorSlider.onValueChanged.AddListener(delegate { ColorSliderValueChange(); });
        opacitySlider.onValueChanged.AddListener(delegate { OpacitySliderValueChange(); });
        batteryLowThreshold.onValueChanged.AddListener(delegate { BatteryLowThresholdChanged(); });
    }

    private void BatteryLowThresholdChanged()
    {
        prefs.BatteryLowThreshold = batteryLowThreshold.value;
    }

    public void SetUIValues()
    {
        showBatteryPercentage.isOn = prefs.ShowBatteryPercentage;
        showWhenBatteryLow.isOn = prefs.ShowWhenBatteryLow;
        notifyWhenBatteryLow.isOn = prefs.NotifyWhenBatteryLow;
        batteryLowThreshold.value = prefs.BatteryLowThreshold;        
        opacitySlider.value = prefs.BatteryLabelOpacity;

        float hue, saturation, value;
        Color.RGBToHSV(prefs.BatteryLabelColor, out hue, out saturation, out value);
        colorSlider.value = hue;
    }

    public void ColorSliderValueChange()
    {
        colorHandle.color = Color.HSVToRGB(colorSlider.value, 1, 1);
        prefs.BatteryLabelColor = colorHandle.color;
	    OpacitySliderValueChange();
    }

    public void OpacitySliderValueChange()
    {
        opacityHandle.color = Color.HSVToRGB(colorSlider.value, opacitySlider.value, 1);
        prefs.BatteryLabelOpacity = opacitySlider.value;
    }
}
