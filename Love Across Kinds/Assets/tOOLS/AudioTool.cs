using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AudioTool : EditorWindow
{
    public TextAsset dialogueData;

    private List<string> nameList;
    private List<int> idList;
    private List<string> sentenceList;

    [MenuItem("Tools/Audio Tool")]
    public static void ShowWindow()
    {
        GetWindow<AudioTool>("Audio Tool");
    }

    private void OnGUI()
    {
        
        GUILayout.Label("Dialogue File", EditorStyles.boldLabel);
        
        dialogueData = EditorGUILayout.ObjectField(new GUIContent("Dialogue Data File", "Fill this section with Dialogue Data File(.txt)"), dialogueData, typeof(TextAsset), false) as TextAsset;

        if (GUILayout.Button("Process Dialogue Data"))
        {
            ProcessDialogueData();
        }

        if (GUILayout.Button("Generate VoiceOver Source"))
        {
            GenerateAudioSource();
        }
    }

    private void ProcessDialogueData()
    {
        if (dialogueData == null)
        {
            Debug.Log("Dialgue Data File is not filled");
            return;
        }

        if(idList.Count > 0)
        {
            idList.Clear();
        }
        if(nameList.Count > 0)
        {
            nameList.Clear();
        }
        if(sentenceList.Count > 0)
        {
            sentenceList.Clear();
        }
        
        string[] data = dialogueData.text.Split(new char[] { '\n' });
        
        for(int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { '\t' });

            DialogueData dialogueData = new DialogueData();

            dialogueData.name = row[0];
            int.TryParse(row[1], out dialogueData.sentenceID);
            dialogueData.sentence = row[2];

            nameList.Add(dialogueData.name);
            idList.Add(dialogueData.sentenceID);
            sentenceList.Add(dialogueData.sentence);
        }
    }

    private void GenerateAudioSource()
    {
        if (GameObject.Find("VoiceOver_Source") != null)
        {
            DestroyImmediate(GameObject.Find("VoiceOver_Source"));
        }
        
        GameObject _VoiceOverSource = new GameObject("VoiceOver_Source");
        _VoiceOverSource.AddComponent<AudioSource>().playOnAwake = false;
        _VoiceOverSource.AddComponent<VoiceOverAudioData>();

        VoiceOverAudioData audioData = _VoiceOverSource.GetComponent<VoiceOverAudioData>();

        audioData._VoiceClips = new List<VoiceOverData>();

        for(int i = 0; i < idList.Count; i++)
        {
            VoiceOverData voiceOverData = new VoiceOverData();

            voiceOverData.actorName = nameList[i];
            voiceOverData.dialogueID = idList[i];
            voiceOverData.sentence = sentenceList[i];

            audioData._VoiceClips.Add(voiceOverData);
        }
    }
}
