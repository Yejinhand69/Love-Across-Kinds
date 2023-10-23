using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource _BGMSource;
    public AudioSource _SFXSource;
    public AudioSource _VoiceOverSource;

    public BGM_Data[] bGM_Datas;
    public List<SFX_Data> sFX_Datas;
    [HideInInspector] 
    public VoiceOverAudioData voiceOverScript;

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
        _BGMSource.Stop();
        for(int i = 0; i < bGM_Datas.Length; i++)
        {
            if(bGM_Datas[i].Name == SceneManager.GetActiveScene().name)//currentPhase)
            {
                _BGMSource.clip = bGM_Datas[i].BGM;
                _BGMSource.Play();
            }
        }
        
        UpdateSFX();

    }

    public void UpdateSFX()
    {
        var clips_SFX = Resources.LoadAll("SFX", typeof(AudioClip)).Cast<AudioClip>().ToArray();

        sFX_Datas = new List<SFX_Data>();

        for (int i = 0; i < clips_SFX.Length; i++)
        {
            SFX_Data sFX_Data = new SFX_Data();

            sFX_Data.SFX = clips_SFX[i];
            sFX_Data.ClipName = clips_SFX[i].name;

            sFX_Datas.Add(sFX_Data);
        }
    }

    public void PlaySFX(string clipName)
    {
        for(int i = 0; i < sFX_Datas.Count; i++)
        {
            if(clipName == sFX_Datas[i].ClipName)
            {
                _SFXSource.PlayOneShot(sFX_Datas[i].SFX);
            }
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        _SFXSource.PlayOneShot(clip);
    }

    public void PlayVoice(int dialogueID)
    {
        _VoiceOverSource.Stop();
        _VoiceOverSource.PlayOneShot(voiceOverScript._VoiceClips[dialogueID].voiceClip);
    }
}

[System.Serializable]
public class BGM_Data
{
    public string Name;
    public AudioClip BGM;
}

public class SFX_Data
{
    public string ClipName;
    public AudioClip SFX;
}