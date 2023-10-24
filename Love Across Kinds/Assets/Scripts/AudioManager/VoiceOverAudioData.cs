using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
public class VoiceOverAudioData : MonoBehaviour
{
    public string FolderName;
    public List<VoiceOverData> _VoiceClips;

    private void Start()
    {
        //this.transform.parent = GameObject.Find("AudioManager").transform;
        //AudioManager.instance._VoiceOverSource = GetComponent<AudioSource>();
        AudioManager.instance.voiceOverScript = GetComponent<VoiceOverAudioData>();
    }

    private void Update()
    {
        var voiceOver = Resources.LoadAll(FolderName).Cast<AudioClip>().ToArray();

        for (int i = 0; i < voiceOver.Length; i++)
        {
            _VoiceClips[i].voiceClip = voiceOver[i];
        }
    }
}

[System.Serializable]
public class VoiceOverData
{
    public string actorName;
    public int dialogueID;
    public string sentence;
    public AudioClip voiceClip;
}
