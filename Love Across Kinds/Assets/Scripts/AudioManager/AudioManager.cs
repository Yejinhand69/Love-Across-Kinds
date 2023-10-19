using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource _BGMSource;
    public AudioSource _SFXSource;
    public AudioSource _VoiceOverSource;

    public BGM_Data[] bGM_Datas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _VoiceOverSource = GameObject.Find("VoiceOver_Source").GetComponent<AudioSource>();

        _BGMSource.Stop();
        for(int i = 0; i < bGM_Datas.Length; i++)
        {
            if(bGM_Datas[i].SceneName == SceneManager.GetActiveScene().name)
            {
                _BGMSource.clip = bGM_Datas[i].BGM;
                _BGMSource.Play();
            }
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        _SFXSource.PlayOneShot(clip);
    }

    public void PlayVoice(AudioClip clip)
    {
        _VoiceOverSource.Stop();
        _VoiceOverSource.PlayOneShot(clip);
    }
}

[System.Serializable]
public class BGM_Data
{
    public string SceneName;
    public AudioClip BGM;
}