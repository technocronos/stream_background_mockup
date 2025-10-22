using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContributionManager : MonoBehaviour
{
    public GameObject FeatureContainer;
    public Button ButtonContribute;

    private float m_GoalProgress = 0f;
    public Slider GoalSlider;
    public ContributionNotification ContributionNotification;
    public GameObject GoalReachedGo;
    public TMP_Text ProgressText;
    public TMP_Text TitleText;
    private bool m_IsGoalReached = false;

    private void Awake()
    {
        ButtonContribute.onClick.AddListener(MakeContribution);
    }

    private void MakeContribution()
    {
        if (m_IsGoalReached) return;
        m_GoalProgress += 0.1f;
        ContributionNotification.OnContributionReceived();
        if (m_GoalProgress > 1f - float.Epsilon)
        {
            GoalReachedGo.SetActive(true);
            m_IsGoalReached = true;
        }
    }

    private void Update()
    {
        bool isShown = PlayerPrefs.HasKey(GoalSettingsManager.GoalProgressOnOff);
        FeatureContainer.SetActive(isShown);
        if (!isShown) return;
        var maxValue = PlayerPrefs.GetInt(GoalSettingsManager.GoalProgressAimValue);
        GoalSlider.value = m_GoalProgress;
        ProgressText.text = string.Format("{0:0} / {1} {2}", m_GoalProgress * maxValue,
            maxValue,
            PlayerPrefs.GetInt(GoalSettingsManager.GoalProgressType) == 0 ? "アップル" : "日本円");
        TitleText.text = PlayerPrefs.GetString(GoalSettingsManager.GoalProgressText);
    }
}
