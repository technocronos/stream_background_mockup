using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    public Button ButtonFireworks;

    public GameObject FireworksPref;

    private void Awake()
    {
        ButtonFireworks.onClick.AddListener(StartFireworks);
    }

    private void StartFireworks()
    {
        Instantiate(FireworksPref);
    }

    private void Update()
    {
        bool isActive = true;
        if (PlayerPrefs.HasKey(PlayableEffectsSettingsManager.EffectsOnOff))
        {
            isActive = PlayerPrefs.GetInt(PlayableEffectsSettingsManager.EffectsOnOff) == 1;
        }
        ButtonFireworks.gameObject.SetActive(isActive);
    }
}
