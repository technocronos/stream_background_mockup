using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContributionManager : MonoBehaviour
{
    private float m_GoalProgress = 0f;
    public Slider GoalSlider;
    public GameObject ContributionMadeGo;
    public GameObject GoalReachedGo;
    public TMP_Text ProgressText;
    private bool m_IsGoalReached = false;

    public void MakeContribution()
    {
        if (m_IsGoalReached) return;
        m_GoalProgress += 0.1f;
        ContributionMadeGo.SetActive(true);
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
