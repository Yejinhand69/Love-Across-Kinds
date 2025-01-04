using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataProcessor : MonoBehaviour
{
    public static DataProcessor instance;

    public List<DialogueData> dataList = new List<DialogueData>();
    public int totalOptionNum;

    public void Awake()
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

        ProcessDialogueData();
    }

    public void ProcessDialogueData()
    {
        instance.totalOptionNum = 0;
        instance.dataList.Clear();

        //Read/Load dialogue file
        TextAsset dialogue = Resources.Load<TextAsset>("Dialogue/DialogueDataEpisode" + PhaseManager.instance.currentEpisode + PhaseManager.instance.currentPhase);
        Debug.Log(dialogue.name);
        //Split the data line by line
        string[] data = dialogue.text.Split(new char[] { '\n' });
        
        //Data Processing
        for (int i = 0; i < data.Length - 1; i++)
        {
            //Spilt data into each columm by comma
            string[] row = data[i].Split(new char[] { '\t' }); 

            //Add on for automation
            if (i == 0)
            {
                // To check and store total number of options in the data
                for(int j = 0; j < row.Length; j++)
                {
                    var titleText = row[j].ToCharArray();
                    string tempText = "";
                    for(int k = 0; k < titleText.Length - 1; k++)
                    {
                        tempText += titleText[k];
                    }

                    if(tempText.Equals("option"))
                    {
                        instance.totalOptionNum++;
                    }
                }
            }
            else
            {
                DialogueData dialogueData = new DialogueData();

                //Inseting each data into variable respectively
                int elementCount = 0;

                dialogueData.name = row[elementCount];
                int.TryParse(row[++elementCount], out dialogueData.sentenceID);
                dialogueData.sentence = row[++elementCount];
                int.TryParse(row[++elementCount], out dialogueData.nextSentenceID);
                bool.TryParse(row[++elementCount], out dialogueData.checkIfOption);

                // First Attemp (Maunual)
                //dialogueData.option1 = row[++elementCount];
                //dialogueData.option2 = row[++elementCount];
                //dialogueData.option3 = row[++elementCount];
                //int.TryParse(row[++elementCount], out dialogueData.option1_sentenceID);
                //int.TryParse(row[++elementCount], out dialogueData.option2_sentenceID);
                //int.TryParse(row[++elementCount], out dialogueData.option3_sentenceID);

                // Updated Attemp (Automation)
                dialogueData.options = new List<string>();

                for (int j = 0; j < instance.totalOptionNum; j++)
                {
                    dialogueData.options.Add(row[++elementCount]);
                }

                dialogueData.options_sentenceID = new List<int>();

                for (int j = 0; j < instance.totalOptionNum; j++)
                {
                    int.TryParse(row[++elementCount], out int id);
                    dialogueData.options_sentenceID.Add(id);
                }
                
                bool.TryParse(row[++elementCount], out dialogueData.checkIfEnd);
                bool.TryParse(row[++elementCount], out dialogueData.checkIfAffection);
                int.TryParse(row[++elementCount], out dialogueData._event);
                int.TryParse(row[++elementCount], out dialogueData.expression);

                //Debug.Log(elementCount);

                //Add the variables with data into a list
                instance.dataList.Add(dialogueData);
            }  
        } 
    }
}

//Data Storage variable class
public class DialogueData
{
    public string name;
    public int sentenceID;
    public string sentence;
    public int nextSentenceID;
    public bool checkIfOption;

    // First Attemp (Maunual)
    //public string option1;
    //public string option2;
    //public string option3;
    //public int option1_sentenceID;
    //public int option2_sentenceID;
    //public int option3_sentenceID;

    // Updated Attemp (Automation)
    public List<string> options;  
    public List<int> options_sentenceID;

    public bool checkIfEnd;
    public bool checkIfAffection;
    public int _event;
    public int expression;
}
