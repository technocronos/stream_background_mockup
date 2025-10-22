using UnityEngine;
using UnityEngine.UI;

public class TabSubmenu : MonoBehaviour
{
    public Toggle parentToggle;
    void Start()
    {
        if (!parentToggle.isOn)
        {
            gameObject.SetActive(false);
        }
        parentToggle.onValueChanged.AddListener(OnToggleChanged);

    }

    private void OnDestroy()
    {
        if (parentToggle != null) { parentToggle.onValueChanged.RemoveListener(OnToggleChanged); }
    }

    private void OnToggleChanged(bool isOn)
    {
        gameObject.SetActive(isOn);
    }
}
