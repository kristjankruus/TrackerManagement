using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrackerManager_Menu_Pogo_Simulate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject TrackerPin;
    public Text StatusText;

    public void OnPointerDown(PointerEventData eventData)
    {
        TrackerPin.GetComponent<MeshRenderer>().material.color = Color.green;
        StatusText.text = true.ToString();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TrackerPin.GetComponent<MeshRenderer>().material.color = Color.gray;
        StatusText.text = false.ToString();
    }
}
