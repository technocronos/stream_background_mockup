using UnityEngine;
using UnityEngine.UI;

public class PlayableEffectsSettingsManager : MonoBehaviour
{
    public Toggle EffectsOnOffToggle;
    public static readonly string EffectsOnOff;

    private void Awake()
    {
        EffectsOnOffToggle.onValueChanged.AddListener(OnEffectsOnOffToggleChanged);
    }

    private void OnEffectsOnOffToggleChanged(bool isOn)
    {
        PlayerPrefs.SetInt(EffectsOnOff, isOn ? 1 : 0);
    }

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(EffectsOnOff)) 
            EffectsOnOffToggle.SetIsOnWithoutNotify(PlayerPrefs.GetInt(EffectsOnOff) == 1);
    }
}
