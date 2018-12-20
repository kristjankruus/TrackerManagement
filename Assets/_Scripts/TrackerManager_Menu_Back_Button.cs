using UnityEngine;
using UnityEngine.UI;

public class TrackerManager_Menu_Back_Button : MonoBehaviour
{
    public Button Button;
    public GameObject MainMenu;
    public GameObject SubMenus;

    void Start()
    {
        Button.onClick.AddListener(BackToMainMenu);
    }

    private void BackToMainMenu()
    {
        var children = SubMenus.GetComponentInChildren<Transform>();
        foreach (Transform child in children)
        {
            child.gameObject.SetActive(false);
        }
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
