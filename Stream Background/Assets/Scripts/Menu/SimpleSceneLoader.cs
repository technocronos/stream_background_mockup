using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MenuUi))]
public class SimpleSceneLoader : MonoBehaviour
{
    private static SimpleSceneLoader Instance = null;
    private static readonly string HideMenuOnStart = "HideMenuOnStart";
    public static bool IsHideMenuOnStart { get {
            if (!PlayerPrefs.HasKey(HideMenuOnStart)) { return false; }
            return (PlayerPrefs.GetInt(HideMenuOnStart) == 1);
        } }

    private void Start()
    {
        if (Instance != null && Instance != this) { Destroy(Instance); }
        Instance = this;
        PlayerPrefs.SetInt(HideMenuOnStart, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            ToggleMenu();
        }
    }

    public void LoadSceneEffects()
    {
        SceneManager.LoadScene("PlayableEffects");
    }

    public void LoadSceneVoting()
    {
        SceneManager.LoadScene("Voting");
    }

    public void LoadSceneProgress()
    {
        SceneManager.LoadScene("ProgressGauge");
    }

    public void LoadStartScene()
    {
        PlayerPrefs.SetInt(HideMenuOnStart, 1);
        SceneManager.LoadScene(0);
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void ToggleMenu()
    {
        GetComponent<MenuUi>().ToggleMenu();
    }
}
