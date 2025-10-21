using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneLoader : MonoBehaviour
{
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

    public void LoadSceneSelection()
    {
        SceneManager.LoadScene("_Start_");
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
