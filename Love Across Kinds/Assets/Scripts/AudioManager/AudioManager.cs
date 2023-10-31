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

    public Dictionary<string, AudioClip> SFXDictionary;
    public Dictionary<string, AudioClip> BGMDictionary;

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
        //Initialise dictionary
        SFXDictionary = new Dictionary<string, AudioClip>();
        BGMDictionary = new Dictionary<string, AudioClip>();

        UpdateSFX();
        
        //Adding SFX data into Dictionary<>
        for(int i = 0; i < sFX_Datas.Count; i++)
        {
            SFXDictionary.Add(sFX_Datas[i].ClipName, sFX_Datas[i].SFX);
        }

        //Adding BGM data into Dictionary<>
        for(int i = 0; i < bGM_Datas.Length; i++)
        {
            BGMDictionary.Add(bGM_Datas[i].Name, bGM_Datas[i].BGM);
        }
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

    public void PlayBGM()
    {
        _BGMSource.Stop();

        AudioClip audioClip;

        if (BGMDictionary.TryGetValue(PhaseManager.instance.currentPhase, out audioClip))
        {
            _BGMSource.clip = audioClip;
            _BGMSource.Play();
        }
    }

    public void PlaySFX(string clipName)
    {
        AudioClip audioClip;
        
        if(SFXDictionary.TryGetValue(clipName, out audioClip))
        {
            _SFXSource.PlayOneShot(audioClip);
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