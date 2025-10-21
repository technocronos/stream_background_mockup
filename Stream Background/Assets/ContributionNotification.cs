using UnityEngine;
using System.Collections;

public class ContributionNotification : MonoBehaviour
{
    public GameObject NotificationGo;
    private Coroutine m_AppearRoutine;
    public void OnContributionReceived()
    {
        if (m_AppearRoutine != null) { 
            StopCoroutine(m_AppearRoutine); }
        m_AppearRoutine = StartCoroutine(AppearRoutine());
    }

    private IEnumerator AppearRoutine()
    {
        NotificationGo.SetActive(false);
        yield return new WaitForSecondsRealtime(0.1f);
        NotificationGo.SetActive(true);
    }
}
