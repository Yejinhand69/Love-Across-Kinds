using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverAudioData : MonoBehaviour
{
    public List<VoiceOverData> _VoiceClips;
}

[System.Serializable]
public class VoiceOverData
{
    public string actorName;
    public int dialogueID;
    public string sentence;
    public AudioClip voiceClip;
}
