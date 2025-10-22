using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MenuUi))]
public class SimpleSceneLoader : MonoBehaviour
{
    private static SimpleSceneLoader Instance = null;

    private void Start()
    {
        if (Instance != null && Instance != this) { Destroy(Instance); }
        Instance = this;
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

    public void ExitApp()
    {
        Application.Quit();
    }

    public void ToggleMenu()
    {
        GetComponent<MenuUi>().ToggleMenu();
    }
}
