using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataProcessor : MonoBehaviour
{
    public static List<DialogueData> dataList = new List<DialogueData>();

    public void Awake()
    {
        //Read/Load .csv file
        TextAsset dialogue = Resources.Load<TextAsset>("DialogueData");

        //Split the data line by line
        string[] data = dialogue.text.Split(new char[] { '\n' });

        //Data Processing
        for(int i = 1; i < data.Length - 1; i++)
        {
            //Spilt data into each columm by comma
            string[] row = data[i].Split(new char[] { ',' });

            DialogueData dialogueData = new DialogueData();

            //Inseting each data into variable respectively
            dialogueData.name = row[0];
            int.TryParse(row[1], out dialogueData.id);
            dialogueData.sentence = row[2];
            int.TryParse(row[3], out dialogueData.nextSentenceID);
            bool.TryParse(row[4], out dialogueData.checkIfOption);
            dialogueData.option1 = row[5];
            dialogueData.option2 = row[6];
            dialogueData.option3 = row[7];
            int.TryParse(row[8], out dialogueData.option1_sentenceID);
            int.TryParse(row[9], out dialogueData.option2_sentenceID);
            int.TryParse(row[10], out dialogueData.option3_sentenceID);
            bool.TryParse(row[11], out dialogueData.checkIfEnd);
            bool.TryParse(row[12], out dialogueData.checkIfAffection);

            //Add the variables with data into a list
            dataList.Add(dialogueData);
        }
    }
}

//Data Storage variable class
public class DialogueData
{
    public string name;
    public int id;
    public string sentence;
    public int nextSentenceID;
    public bool checkIfOption;
    public string option1;
    public string option2;
    public string option3;
    public int option1_sentenceID;
    public int option2_sentenceID;
    public int option3_sentenceID;
    public bool checkIfEnd;
    public bool checkIfAffection;
}