using UnityEngine;

public class SelfHidingObj : MonoBehaviour
{
    private float m_HideAfter = 5f;
    private float m_StartingTime;

    private void OnEnable()
    {
        m_StartingTime = Time.realtimeSinceStartup;
    }

    void Update()
    {
        if (Time.realtimeSinceStartup - m_StartingTime > m_HideAfter)
        {
            gameObject.SetActive(false);
        }
    }
}
