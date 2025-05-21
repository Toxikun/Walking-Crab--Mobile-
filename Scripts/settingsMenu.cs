using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("UI References")]
    public GameObject settingsPanel;        // Aç/kapa yapılacak panel
    public Slider volumeSlider;             // Ses ayarı slider'ı

    [Header("Audio")]
    public AudioMixer audioMixer;           // Master AudioMixer
    private const string volumeParam = "Volume"; // Exposed parametre adı

    private void Start()
    {

        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume);

        volumeSlider.onValueChanged.AddListener(SetVolume);
     
    }

    public void ToggleSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }


    public void SetVolume(float volume)
    {
        float dB = Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat(volumeParam, dB);
        Debug.Log($"SetVolume: {volume} → {dB} dB");
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
    public void LeaveSettings()
    {
        settingsPanel.SetActive(false);
    }
}
