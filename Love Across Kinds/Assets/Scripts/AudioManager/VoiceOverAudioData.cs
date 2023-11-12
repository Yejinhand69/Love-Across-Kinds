using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
public class VoiceOverAudioData : MonoBehaviour
{
    public string folderName;
    public List<VoiceOverData> _VoiceClips;

    private void Start()
    {
        AudioManager.instance.voiceOverScript = this;
    }

    private void Update()
    {
        var voiceOver = Resources.LoadAll(folderName).Cast<AudioClip>().ToArray();

        for (int i = 0; i < voiceOver.Length; i++)
        {
            if(voiceOver[i].name == i.ToString())
            {
                _VoiceClips[i].voiceClip = voiceOver[i];
            }  
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
