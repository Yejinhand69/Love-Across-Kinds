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

    private float targetBGMVolume;
    private float targetSFXVolume;

    private void Awake()
    {
        // Find the sliders using their respective names or tags
        bgmVolumeSlider = GameObject.Find("BGMVolumeSlider").GetComponent<Slider>();
        sfxVolumeSlider = GameObject.Find("SFXVolumeSlider").GetComponent<Slider>();

        // Set initial volumes based on PlayerPrefs
        bgmAudioSource.volume = PlayerPrefs.GetFloat("BGMVolume", 0.1f);
        sfxAudioSource.volume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
    }

    private void Start()
    {
        bgmVolumeSlider.onValueChanged.AddListener(ChangeBGMVolume);
        bgmVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.1f);
        bgmAudioSource.volume = bgmVolumeSlider.value;
        targetBGMVolume = bgmVolumeSlider.value;

        sfxVolumeSlider.onValueChanged.AddListener(ChangeSFXVolume);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        sfxAudioSource.volume = sfxVolumeSlider.value;
        targetSFXVolume = sfxVolumeSlider.value;
    }

    private void Update()
    {
        if (bgmAudioSource.isPlaying)
        {
            bgmAudioSource.volume = Mathf.Lerp(bgmAudioSource.volume, targetBGMVolume, Time.deltaTime * 1.5f);
        }
        if (sfxAudioSource.isPlaying)
        {
            sfxAudioSource.volume = Mathf.Lerp(sfxAudioSource.volume, targetSFXVolume, Time.deltaTime * 1.5f);
        }
    }

    private void ChangeBGMVolume(float volume)
    {
        targetBGMVolume = volume;

        // Save the BGM volume setting to PlayerPrefs
        PlayerPrefs.SetFloat("BGMVolume", volume);
        PlayerPrefs.Save();
    }

    private void ChangeSFXVolume(float volume)
    {
        targetSFXVolume = volume;

        // Save the SFX volume setting to PlayerPrefs
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }

  

}
