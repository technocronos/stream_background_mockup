using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContributionManager : MonoBehaviour
{
    public Button ButtonContribute;

    private float m_GoalProgress = 0f;
    public Slider GoalSlider;
    public ContributionNotification ContributionNotification;
    public GameObject GoalReachedGo;
    public TMP_Text ProgressText;
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
        GoalSlider.value = m_GoalProgress;
        ProgressText.text = string.Format("{0:0} / 10 Apples", m_GoalProgress*10);
    }
}
