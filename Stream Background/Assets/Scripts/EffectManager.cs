using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject FireworksPref;
    public void StartFireworks()
    {
        Instantiate(FireworksPref);
    }
}
