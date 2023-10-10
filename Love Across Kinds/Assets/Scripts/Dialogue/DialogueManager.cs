using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    //UI stuffs
    public GameObject optionBox;
    //public Image actorImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI option1Text;
    public TextMeshProUGUI option2Text;
    public TextMeshProUGUI option3Text;

    //Stroing data of Dialogues from .csv
    private List<DialogueData> datas;

    //Indicator
    private int currIndexPos = 0;
    private int currSentenceId = 0;
    public static bool dialogueActive;

    //Animator
    private Animator anim;

    private void Start()
    {
        datas = DataProcessor.dataList;

        dialogueText.text = string.Empty;
        dialogueActive = false;

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (dialogueActive)
        {
            if (!datas[currIndexPos].checkIfOption)
            {
                if (Input.anyKeyDown)
                {
                    NextSentence();
                }
            }
        }
    }

    //Method to show DialogueBox & Search the upmost data of each character by NAME
    public void OpenDialogue(string objName, int startID)
    {
        anim.SetBool("isOpenDialogue", true);
        StartCoroutine(DelayDialogueActive());
        currIndexPos = 0;

        for(int i = 0; i <= datas.Count - 1; i++)
        {
            if(datas[i].name == objName)
            {
                currIndexPos = i;
                currSentenceId = startID;
                
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
            if(datas[i].sentenceID == currSentenceId)
            {
                Debug.Log("Display");
                currIndexPos = i;
                nameText.text = datas[currIndexPos].name;
                dialogueText.text = datas[currIndexPos].sentence;

                if (datas[currIndexPos].checkIfOption)
                {
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
            if (!datas[currIndexPos].checkIfOption)
            {
                currSentenceId = datas[currIndexPos].nextSentenceID;
            }

            DisplaySentence();
        }
    }

    public void EndDialogue()
    {
        anim.SetBool("isOpenDialogue", false);
        dialogueActive = false;

        if (datas[currIndexPos].checkIfAffection)
        {
            AffectionSystem.Instance.GetAffection();
        }
        
    }

    //Method to Show options
    public void ShowOptions()
    {
        option1Text.text = datas[currIndexPos].option1;
        option2Text.text = datas[currIndexPos].option2;
        option3Text.text = datas[currIndexPos].option3;
        optionBox.SetActive(true);
    }

    public void ChooseOption1()
    {
        currSentenceId = datas[currIndexPos].option1_sentenceID;
        optionBox.SetActive(false);
        NextSentence();
    }

    public void ChooseOption2()
    {
        currSentenceId = datas[currIndexPos].option2_sentenceID;
        optionBox.SetActive(false);
        NextSentence();
    }

    public void ChooseOption3()
    {
        currSentenceId = datas[currIndexPos].option3_sentenceID;
        optionBox.SetActive(false);
        NextSentence();
        SceneManager.LoadScene("Rhythm Game"); // put here first , change later ......... ( for testing purposes )
    }

    IEnumerator DelayDialogueActive()
    {
        yield return new WaitForSeconds(0.5f);
        dialogueActive = true;
    }
}
