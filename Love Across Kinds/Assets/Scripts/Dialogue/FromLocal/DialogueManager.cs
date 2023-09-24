using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //UI stuffs
    //public GameObject background;
    public GameObject optionBox;
    //public Image actorImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI option1Text;
    public TextMeshProUGUI option2Text;

    //Stroing data of Dialogues from .csv
    private List<DialogueData> datas;

    //Indicator
    private int currIndexPos;
    public int currSentenceId = 0;

    //Animator
    private Animator anim;

    private void Start()
    {
        datas = DataProcessor.dataList;
        dialogueText.text = string.Empty;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!datas[currIndexPos].checkIfOption)
        {
            if (Input.anyKeyDown)
            {
                NextSentence();
            }
        }
    }

    //Method to show DialogueBox & Search the upmost data of each character by NAME
    public void OpenDialogue(string objName, int startID)
    {
        anim.SetBool("isOpenDialogue", true);

        for(int i = 0; i <= datas.Count - 1; i++)
        {
            if(datas[i].name == objName)
            {
                currIndexPos = i;
                currSentenceId = startID;
                nameText.text = datas[i].name;
                break;
            }
        }

        DisplaySentence();
    }

    //Method to display specific sentence by using datas.id in data
    public void DisplaySentence()
    {
        for(int i = currIndexPos; i <= datas.Count - 1; i++)
        {
            if(datas[i].id == currSentenceId)
            {
                currIndexPos = i;
                dialogueText.text = datas[currIndexPos].sentence;
                if (datas[currIndexPos].checkIfOption)
                {
                    Debug.Log("Show Option");
                    ShowOptions();
                }
                break;
            }
        }

        
    }

    //Method to Display next sentence/ End the dialogue
    public void NextSentence()
    {
        if (datas[currIndexPos].checkIfEnd)
        {
            EndDialogue();
        }
        else
        {
            currSentenceId++;
            DisplaySentence();
        }
    }

    public void EndDialogue()
    {
        anim.SetBool("isOpenDialogue", false);
    }

    //Method to Show options
    public void ShowOptions()
    {
        option1Text.text = datas[currIndexPos].option1;
        option2Text.text = datas[currIndexPos].option2;
        optionBox.SetActive(true);
    }

    public void ChooseOption1()
    {
        currSentenceId = datas[currIndexPos].option1_sentenceID - 1;
        optionBox.SetActive(false);
        NextSentence();
    }

    public void ChooseOption2()
    {
        currSentenceId = datas[currIndexPos].option2_sentenceID - 1;
        optionBox.SetActive(false);
        NextSentence();
    }
}
