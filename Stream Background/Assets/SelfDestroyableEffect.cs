using UnityEngine;

public class SelfDestroyableEffect : MonoBehaviour
{
    public GameObject mainObj;
    public float effectDuration = 10f;
    private float startingTime;
    
    void Start()
    {
        if (mainObj) mainObj.SetActive(true);
        startingTime = Time.realtimeSinceStartup;
    }

    void Update()
    {
        if (Time.realtimeSinceStartup - startingTime > effectDuration)
        {
            Destroy(this.gameObject);
        }
    }
}
