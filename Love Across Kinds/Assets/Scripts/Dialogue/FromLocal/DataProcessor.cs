using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataProcessor : MonoBehaviour
{
    public static List<DialogueData> dataList = new List<DialogueData>();

    public void Awake()
    {
        TextAsset dialogue = Resources.Load<TextAsset>("DialogueData");

        string[] data = dialogue.text.Split(new char[] { '\n' });

        for(int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });

            DialogueData dialogueData = new DialogueData();

            dialogueData.name = row[0];
            int.TryParse(row[1], out dialogueData.id);
            dialogueData.sentence = row[2];
            bool.TryParse(row[3], out dialogueData.checkIfOption);
            dialogueData.option1 = row[4];
            dialogueData.option2 = row[5];
            int.TryParse(row[6], out dialogueData.option1_sentenceID);
            int.TryParse(row[7], out dialogueData.option2_sentenceID);
            bool.TryParse(row[8], out dialogueData.checkIfEnd);

            dataList.Add(dialogueData);
        }
    }
}

public class DialogueData
{
    public string name;
    public int id;
    public string sentence;
    public bool checkIfOption;
    public string option1;
    public string option2;
    public int option1_sentenceID;
    public int option2_sentenceID;
    public bool checkIfEnd;
}
