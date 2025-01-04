using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

[ExecuteInEditMode]
public class VoiceOverAudioData : MonoBehaviour
{
    public string folderName;
    public List<VoiceOverData> _VoiceClips;

#if UNITY_EDITOR
    private void Update()
    {
        ProcessVoiceOver();
    }


    public void ProcessVoiceOver()
    {
        var voiceOver = Resources.LoadAll("VoiceOver/" + folderName).Cast<AudioClip>().ToArray();

        for (int i = 0; i < voiceOver.Length; i++)
        {
            string[] splitName = voiceOver[i].name.Split(new char[] { ' ' });
            //if(voiceOver[i].name == (_VoiceClips[i].actorName + " line " + _VoiceClips[i].dialogueID))
            //{
            //    _VoiceClips[i].voiceClip = voiceOver[i];
            //}  
            for (int j = 0; j < _VoiceClips.Count; j++)
            {
                if (splitName.Length == 3)
                {
                    if (splitName[2].Trim() == _VoiceClips[j].dialogueID.ToString().Trim())
                    {
                        _VoiceClips[j].voiceClip = voiceOver[i];
                        break;
                    }
                }


                if (splitName.Length == 4)
                {
                    if (splitName[3].Trim() == _VoiceClips[j].dialogueID.ToString().Trim())
                    {
                        _VoiceClips[j].voiceClip = voiceOver[i];
                        break;
                    }
                }
            }
        }
    }

#endif
}

[System.Serializable]
public class VoiceOverData
{
    public string actorName;
    public int dialogueID;
    public string sentence;
    public AudioClip voiceClip;
}
