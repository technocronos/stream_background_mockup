using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    public Button ButtonFireworks;

    public GameObject FireworksPref;

    private void Awake()
    {
        ButtonFireworks.onClick.AddListener(StartFireworks);
    }

    private void StartFireworks()
    {
        Instantiate(FireworksPref);
    }
}
