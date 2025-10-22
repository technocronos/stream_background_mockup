using UnityEngine;

public class SelfHidingObj : MonoBehaviour
{
    public float HideAfterOverride = 0f;
    private float m_HideAfter = 5f;
    private float m_StartingTime;

    private void OnEnable()
    {
        m_StartingTime = Time.realtimeSinceStartup;
        if (HideAfterOverride > float.Epsilon) { m_HideAfter = HideAfterOverride; }
    }

    void Update()
    {
        if (Time.realtimeSinceStartup - m_StartingTime > m_HideAfter)
        {
            gameObject.SetActive(false);
        }
    }
}
