using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider bgmVolumeSlider; // Reference to the UI Slider
    public AudioSource bgmAudioSource; // Reference to the AudioSource component
    public Slider sfxVolumeSlider; // Reference to the UI Slider
    public AudioSource sfxAudioSource; // Reference to the AudioSource component

    private void Start()
    {
        // Initialize the slider value to the saved audio source volume or set it to the default volume (e.g., 0.5f)
        bgmVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        // Attach an event listener to the slider to handle volume changes
        bgmVolumeSlider.onValueChanged.AddListener(ChangeVolume);
        sfxVolumeSlider.onValueChanged.AddListener(ChangeVolume);

        // Apply the saved volume settings
        bgmAudioSource.volume = bgmVolumeSlider.value;
        sfxAudioSource.volume = sfxVolumeSlider.value;
    }

    private void ChangeVolume(float volume)
    {
        // Update the audio source volume when the slider value changes
        bgmAudioSource.volume = bgmVolumeSlider.value;
        sfxAudioSource.volume = sfxVolumeSlider.value;

        // Save the volume settings to PlayerPrefs
        PlayerPrefs.SetFloat("BGMVolume", bgmVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
        PlayerPrefs.Save();
    }
}