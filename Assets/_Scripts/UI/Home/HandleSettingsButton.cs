using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandleSettingsButton : MonoBehaviour
{
    public TextMeshProUGUI textColor;
    public GameObject function;

    public void OnClickSettingsButton(Color newColor)
    {
        textColor.color = newColor;
        function.SetActive(true);

        ButtonSettingsClickSound();
    }

    public void CloseSettingsFunction(Color normalColor)
    {
        textColor.color = normalColor;
        function.SetActive(false);

        ButtonSettingsClickSound();
    }

    private void ButtonSettingsClickSound()
    {
        AudioManager._instance.ButtonClickSound();
    }
}
