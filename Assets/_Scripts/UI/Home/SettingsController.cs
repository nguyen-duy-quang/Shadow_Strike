using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public ScriptableObjectButtonColor buttonColor;

    public HandleSettingsButton audioSettings;
    public HandleSettingsButton graphicsSettings;

    public Button closeSettings;

    public Button audioButton;
    public Button graphicsButton;

    public SaveAudio saveAudio;

    private void Start()
    {
        AudioButtonClick();

        saveAudio.LoadData();

        audioButton.onClick.AddListener(AudioButtonClick);
        graphicsButton.onClick.AddListener(GraphicsButtonClick);

        closeSettings.onClick.AddListener(OnClickCloseSettings);
    }

    private void OnClickCloseSettings()
    {
        gameObject.SetActive(false);
        AudioManager._instance.ButtonClickSound();

        saveAudio.SaveData();
    }

    private void AudioButtonClick()
    {
        audioSettings.OnClickSettingsButton(buttonColor.newColor);
        graphicsSettings.CloseSettingsFunction(buttonColor.normalColor);
    }
    private void GraphicsButtonClick()
    {
        audioSettings.CloseSettingsFunction(buttonColor.normalColor);
        graphicsSettings.OnClickSettingsButton(buttonColor.newColor);
    }
}
