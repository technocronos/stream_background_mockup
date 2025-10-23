using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalSettingsManager : MonoBehaviour
{
    public Toggle OnOffToggle;
    public TMP_InputField GoalText;
    public TMP_Dropdown GoalTypeDropdown;
    public TMP_InputField GoalValueText;
    public Button ButtonApply;

    public static readonly string GoalProgressOnOff = "GoalProgressOnOff";
    public static readonly string GoalProgressText = "GoalProgressText";
    public static readonly string GoalProgressAimValue = "GoalProgressValue";
    public static readonly string GoalProgressType = "GoalProgressType";

    private void Awake()
    {
        ButtonApply.onClick.AddListener(OnButtonApply);
        OnOffToggle.onValueChanged.AddListener(OnToggleOnOffChanged);
    }

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(GoalProgressText))
        {
            GoalText.text = PlayerPrefs.GetString(GoalProgressText);
        }
        if (PlayerPrefs.HasKey(GoalProgressType))
        {
            GoalTypeDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt(GoalProgressType));
        }

        OnOffToggle.SetIsOnWithoutNotify(PlayerPrefs.HasKey(GoalProgressOnOff));

        if (PlayerPrefs.HasKey(GoalProgressAimValue))
        {
            GoalValueText.text = PlayerPrefs.GetInt(GoalProgressAimValue).ToString();
        }
    }

    private void OnButtonApply()
    {
        PlayerPrefs.SetString(GoalProgressText, GoalText.text);

        PlayerPrefs.SetInt(GoalProgressType, GoalTypeDropdown.value);
        PlayerPrefs.SetInt(GoalProgressAimValue, int.Parse(GoalValueText.text));



        FindAnyObjectByType<SimpleSceneLoader>().CloseVoting();
        FindAnyObjectByType<ContributionManager>().ResetGauge();
    }

    private void OnToggleOnOffChanged(bool isOn)
    {
        if (isOn && !PlayerPrefs.HasKey(GoalProgressOnOff))
        { PlayerPrefs.SetInt(GoalProgressOnOff, 1); }
        else if (!isOn && PlayerPrefs.HasKey(GoalProgressOnOff))
        { PlayerPrefs.DeleteKey(GoalProgressOnOff); }
    }
}
;