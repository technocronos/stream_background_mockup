using UnityEngine;
using UnityEngine.UI;

public class MenuUi : MonoBehaviour
{
    public Button ButtonClose;
    public Button ButtonQuitApp;
    public GameObject MenuContainer;
    public bool IsActiveOnStart = false;
    public GameObject[] ActivateOnStart;

    private void Awake()
    {
        ButtonClose.onClick.AddListener(CloseMenu);
        ButtonQuitApp.onClick.AddListener(QuitApplication);
        MenuContainer.SetActive(IsActiveOnStart && !SimpleSceneLoader.IsHideMenuOnStart); 
        
        foreach (var entry in ActivateOnStart)
        {
            entry.SetActive(true);
        }
    }

    public void ToggleMenu()
    {
        MenuContainer.SetActive(!MenuContainer.activeSelf);
    }

    public void OpenMenu()
    {
        MenuContainer.SetActive(true);
    }

    public void CloseMenu()
    {
        MenuContainer.SetActive(false);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
