using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    //UI stuffs
    //public Image actorImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    //Options stuffs
    public GameObject optionBox1;
    public GameObject optionBox2;
    public GameObject optionBox3;
    public TextMeshProUGUI option1Text;
    public TextMeshProUGUI option2Text;
    public TextMeshProUGUI option3Text;

    //Stroing data of Dialogues from .csv
    public List<DialogueData> datas;

    //Indicator
    public int currIndexPos = 0;
    [HideInInspector] public int currSentenceId = 0;
    public static bool dialogueActive;
    private string currInteractCharName;

    [HideInInspector] public string phaseIndicator;
    [HideInInspector] public int XinaAttemp;
    [HideInInspector] public int BeniaAttemp;
    [HideInInspector] public int FlorineAttemp;
    [HideInInspector] public int GHJoeAttemp;

    //Animator
    public Animator anim;

    private void Awake()
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

        dialogueText.text = string.Empty;
        dialogueActive = false;
    }

    private void Update()
    {
        datas = DataProcessor.instance.dataList;

        if (phaseIndicator != PhaseManager.instance.currentPhase)
        {
            XinaAttemp = 0;
            BeniaAttemp = 0;
            FlorineAttemp = 0;
            GHJoeAttemp = 0;

            phaseIndicator = PhaseManager.instance.currentPhase;
        }

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
            if(datas[i].name == objName || datas[i].name == " ")
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
                currIndexPos = i;

                //AudioManager.instance.PlayVoice(currSentenceId);

                //Check and change NameBox for player's name
                if(datas[currIndexPos].name == "Player")
                {
                    nameText.text = UserData.instance.playerName;
                }
                else
                {
                    nameText.text = datas[currIndexPos].name;
                    switch (nameText.text)
                    {
                        case "Xina":
                            currInteractCharName = nameText.text;
                            break;
                        case "Benia":
                            currInteractCharName = nameText.text;
                            break;
                        case "Florine":
                            currInteractCharName = nameText.text;
                            break;
                        default:
                            break;
                    }
                }

                //Check and change DialogueBox for player's name
                string[] words = datas[currIndexPos].sentence.Split(new char[] { ' ' });

                for(int j = 0; j < words.Length; j++)
                {
                    if(words[j] == "PlayerName")
                    {
                        words[j] = UserData.instance.playerName;
                    }
                }

                string sentence = "";

                for(int k = 0; k < words.Length; k++)
                {
                    if(k == 0)
                    {
                        sentence += words[k];
                    }
                    else
                    {
                        sentence += " " + words[k];
                    }
                }

                dialogueText.text = sentence;

                //Expressions
                switch(datas[currIndexPos].expression)
                {
                    case "Neutral":
                        //Expression change here...
                        break;
                    case "Happy":
                        //Expression change here...
                        break;
                    case "Angry":
                        //Expression change here...
                        break;
                    case "Sad":
                        //Expression change here...
                        break;
                    case "Shy":
                        //Expression change here...
                        break;
                    default:
                        break;
                }



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
        if (datas[currIndexPos].checkIfEnd && currSentenceId == datas[currIndexPos].sentenceID)
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

        switch (datas[currIndexPos]._event)
        {
            case "AffectionEvent":
                switch (currInteractCharName)
                {
                    case "Xina":
                        if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 3)
                        {
                            //Dialogue Before Mini Game
                            //Affection Event 2 happens here...
                        }
                        else if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 1)
                        {
                            //Dialogue Before Mini Game
                            //Affection Event 1 happens here...
                        }
                        else if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] == 0)
                        {
                            //Spend time
                        }
                            break;

                    case "Benia":
                        if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 3)
                        {
                            //Dialogue Before Mini Game
                            //Affection Event 2 happens here...
                        }
                        else if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 1)
                        {
                            //Dialogue Before Mini Game
                            //Affection Event 1 happens here...
                        }
                        else if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] == 0)
                        {
                            //Spend time
                        }
                        break;

                    case "Florine":
                        if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 3)
                        {
                            //Dialogue Before Mini Game
                            //Affection Event 2 happens here...
                        }
                        else if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 1)
                        {
                            //Dialogue Before Mini Game
                            //Affection Event 1 happens here...
                        }
                        else if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] == 0)
                        {
                            //Spend time
                        }
                        break;

                    default:
                        break;
                }
                break;

            case "ScavengerEvent":

                break;

            case "Sleep":
                PhaseManager.instance.currentEpisode++;
                PhaseManager.instance.ChangePhase();
                SceneManager.LoadScene("LivingFloor" + PhaseManager.instance.currentEpisode);
                break;

            case "ChangePhase":
                PhaseManager.instance.ChangePhase();
                if(PhaseManager.instance.currentPhase == "Filming")
                {
                    SceneManager.LoadScene("Recording" + PhaseManager.instance.currentEpisode);
                }

                if (PhaseManager.instance.currentPhase == "FreeTime")
                {
                    SceneManager.LoadScene("Recording" + PhaseManager.instance.currentEpisode);
                }

                if(PhaseManager.instance.currentPhase == "Special")
                {
                    SceneManager.LoadScene("LivingFloor" + PhaseManager.instance.currentEpisode);
                }
                    break;
                

            case "FilmingConvo":
                switch (currInteractCharName)
                {
                    case "Xina":
                        Epidose1Filming.XinaRepeatID = 160;
                        break;
                    case "Benia":
                        Epidose1Filming.BeniaRepeatID = 234;
                        break;
                    case "Florine":
                        Epidose1Filming.FlorineRepeatID = 314;
                        break;
                    default:
                        break;
                }

                break;

            default:
                break;
        }
    }

    //Method to Show options
    public void ShowOptions()
    {

        if (datas[currIndexPos].option1 != "-")
        {
            optionBox1.SetActive(true);
            option1Text.text = datas[currIndexPos].option1;
        }
        if (datas[currIndexPos].option2 != "-")
        {
            optionBox2.SetActive(true);
            option2Text.text = datas[currIndexPos].option2;
        }
        if (datas[currIndexPos].option3 != "-")
        {
            optionBox3.SetActive(true);
            option3Text.text = datas[currIndexPos].option3;
        }  
    }

    public void ChooseOption1()
    {
        currSentenceId = datas[currIndexPos].option1_sentenceID;

        optionBox1.SetActive(false);
        optionBox2.SetActive(false);
        optionBox3.SetActive(false);

        if (currSentenceId == datas[currIndexPos].sentenceID && datas[currIndexPos].checkIfEnd)
        {
            EndDialogue();
        }
        else
        {
            NextSentence();
        }
    }

    public void ChooseOption2()
    {
        currSentenceId = datas[currIndexPos].option2_sentenceID;

        optionBox1.SetActive(false);
        optionBox2.SetActive(false);
        optionBox3.SetActive(false);

        if (currSentenceId == datas[currIndexPos].sentenceID && datas[currIndexPos].checkIfEnd)
        {
            EndDialogue();
        }
        else
        {
            NextSentence();
        }
    }

    public void ChooseOption3()
    {
        currSentenceId = datas[currIndexPos].option3_sentenceID;

        optionBox1.SetActive(false);
        optionBox2.SetActive(false);
        optionBox3.SetActive(false);

        if (currSentenceId == datas[currIndexPos].sentenceID && datas[currIndexPos].checkIfEnd)
        {
            EndDialogue();
        }
        else
        {
            NextSentence();
        }
        //SceneManager.LoadScene("Rhythm Game"); // put here first , change later ......... ( for testing purposes )
    }

    IEnumerator DelayDialogueActive()
    {
        yield return new WaitForSeconds(0.5f);
        dialogueActive = true;
    }

    public void SkipDialogue()
    {
        EndDialogue();
        optionBox1.SetActive(false);
        optionBox2.SetActive(false);
        optionBox3.SetActive(false);
    }
}
