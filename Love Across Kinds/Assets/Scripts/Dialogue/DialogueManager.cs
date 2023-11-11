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

    public string phaseIndicator;
    [HideInInspector] public int XinaAttemp;
    [HideInInspector] public int BeniaAttemp;
    [HideInInspector] public int FlorineAttemp;
    [HideInInspector] public int GHJoeAttemp;

    //Animator
    public Animator dialogueAnim;
    private Animator characterAnim;

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
        dialogueAnim.SetBool("isOpenDialogue", true);

        //Get animator from current interact object
        characterAnim = EventClick.interactObjAnim;

        StartCoroutine(DelayDialogueActive());
        currIndexPos = 0;

        for (int i = 0; i <= datas.Count - 1; i++)
        {
            if (datas[i].name == objName || datas[i].name == " ")
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
        for (int i = 0; i <= datas.Count - 1; i++)
        {
            if (datas[i].sentenceID == currSentenceId)
            {
                currIndexPos = i;

                //AudioManager.instance.PlayVoice(currSentenceId);

                //Check and change NameBox for player's name
                if (datas[currIndexPos].name == "Player")
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
                            currInteractCharName = EventClick.interactObjectName;
                            break;
                    }
                }

                //Check and change DialogueBox for player's name
                string[] words = datas[currIndexPos].sentence.Split(new char[] { ' ' });

                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j] == "PlayerName")
                    {
                        words[j] = UserData.instance.playerName;
                    }
                }

                string sentence = "";

                for (int k = 0; k < words.Length; k++)
                {
                    if (k == 0)
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
                switch (datas[currIndexPos].expression)
                {
                    case "Neutral":
                        //Expression change here...
                        characterAnim.SetBool("isSmile", false);
                        characterAnim.SetBool("isAngry", false);
                        characterAnim.SetBool("isSad", false);
                        characterAnim.SetBool("isShy", false);
                        break;
                    case "Happy":
                        //Expression change here...
                        characterAnim.SetBool("isSmile", true);
                        characterAnim.SetBool("isAngry", false);
                        characterAnim.SetBool("isSad", false);
                        characterAnim.SetBool("isShy", false);
                        break;
                    case "Angry":
                        //Expression change here...
                        characterAnim.SetBool("isSmile", false);
                        characterAnim.SetBool("isAngry", true);
                        characterAnim.SetBool("isSad", false);
                        characterAnim.SetBool("isShy", false);
                        break;
                    case "Sad":
                        //Expression change here...
                        characterAnim.SetBool("isSmile", false);
                        characterAnim.SetBool("isAngry", false);
                        characterAnim.SetBool("isSad", true);
                        characterAnim.SetBool("isShy", false);
                        break;
                    case "Shy":
                        //Expression change here...
                        characterAnim.SetBool("isSmile", false);
                        characterAnim.SetBool("isAngry", false);
                        characterAnim.SetBool("isSad", false);
                        characterAnim.SetBool("isShy", true);
                        break;
                    default:
                        break;
                }

                if (datas[currIndexPos].checkIfAffection)
                {
                    AffectionSystem.Instance.GetAffection();
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
        dialogueAnim.SetBool("isOpenDialogue", false);
        dialogueActive = false; 

        switch (datas[currIndexPos]._event)
        {
            case "AffectionEvent":
                switch (currInteractCharName)
                {
                    case "Xina":
                        //FreeTime
                        if(PhaseManager.instance.currentPhase == "FreeTime")
                        {
                            //if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 3)
                            //{
                            //    //Dialogue Before Mini Game
                            //    //Affection Event 2 happens here...
                            //}
                            if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 1)
                            {
                                //Dialogue Before Mini Game
                                OpenDialogue(" ", 5);
                                //Affection Event 1 happens here...
                                StartCoroutine(RhythmGameFTAE1());
                            }
                            else if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] == 0)
                            {
                                //Spend time
                                OpenDialogue(" ", 385);
                            }
                        }
                        //Special
                        else if(PhaseManager.instance.currentPhase == "Special")
                        {
                            if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 3)
                            {
                                //Dialogue Before Mini Game
                                OpenDialogue(" ", 389);
                                //Affection Event 2 happens here...
                                StartCoroutine(RhythmGameSAE2());
                            }
                            else if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 1)
                            {
                                //Dialogue Before Mini Game
                                OpenDialogue(" ", 8);
                                //Affection Event 1 happens here...
                                StartCoroutine(RhythmGameSAE1());
                            }
                            else if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] == 0)
                            {
                                //Spend time
                                OpenDialogue(" ", 590);
                            }
                        }
                        break;

                    case "Benia":
                        //FreeTime
                        if (PhaseManager.instance.currentPhase == "FreeTime")
                        {
                            //if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 3)
                            //{
                            //    //Dialogue Before Mini Game
                            //    //Affection Event 2 happens here...
                            //}
                            if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 1)
                            {
                                //Dialogue Before Mini Game
                                OpenDialogue(" ", 113);
                                //Affection Event 1 happens here...
                                StartCoroutine(TriviaGameFTAE1());
                            }
                            else if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] == 0)
                            {
                                //Spend time
                                OpenDialogue(" ", 384);
                            }
                        }
                        //Special
                        else if (PhaseManager.instance.currentPhase == "Special")
                        {
                            //if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 3)
                            //{
                            //    //Dialogue Before Mini Game
                            //    //Affection Event 2 happens here...
                            //}
                            if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 1)
                            {
                                //Dialogue Before Mini Game
                                OpenDialogue(" ", 116);
                                //Affection Event 1 happens here...
                                StartCoroutine(TriviaGameSAE1());
                            }
                            else if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] == 0)
                            {
                                //Spend time
                                OpenDialogue(" ", 589);
                            }
                        }
                        
                        break;

                    case "Florine":

                        //FreeTime
                        if (PhaseManager.instance.currentPhase == "FreeTime")
                        {
                            //if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 3)
                            //{
                            //    //Dialogue Before Mini Game
                            //    //Affection Event 2 happens here...
                            //}
                            if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 1)
                            {
                                //Dialogue Before Mini Game
                                OpenDialogue(" ", 279);
                                //Affection Event 1 happens here...
                                StartCoroutine(PairMatchingGameFTAE1());
                            }
                            else if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] == 0)
                            {
                                //Spend time
                                OpenDialogue(" ", 386);
                            }
                        }
                        //Special
                        else if (PhaseManager.instance.currentPhase == "Special")
                        {
                            //if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 3)
                            //{
                            //    //Dialogue Before Mini Game
                                
                            //    //Affection Event 2 happens here...
                                
                            //}
                            if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] >= 1)
                            {
                                //Dialogue Before Mini Game
                                OpenDialogue(" ", 282);
                                //Affection Event 1 happens here...
                                StartCoroutine(PairMatchingGameSAE1());
                            }
                            else if (AffectionSystem.Instance.affectionDictionary[currInteractCharName] == 0)
                            {
                                //Spend time
                                OpenDialogue(" ", 591);
                            }
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

                if (PhaseManager.instance.currentPhase == "Special")
                {
                    SceneManager.LoadScene("Episode2");
                }

                if (PhaseManager.instance.currentPhase == "Prologue")
                {
                    SceneManager.LoadScene("LivingFloor" + PhaseManager.instance.currentEpisode);
                }

                PhaseManager.instance.ChangePhase();

                break;

            case "ChangePhase":
                
                PhaseManager.instance.ChangePhase();
                
                if (PhaseManager.instance.currentPhase == "Special")
                {
                    SceneManager.LoadScene("LivingFloor" + PhaseManager.instance.currentEpisode);
                }

                if (PhaseManager.instance.currentPhase == "Filming")
                {
                    SceneManager.LoadScene("Recording" + PhaseManager.instance.currentEpisode);
                }

                if (PhaseManager.instance.currentPhase == "FreeTime")
                {
                    SceneManager.LoadScene("Recording" + PhaseManager.instance.currentEpisode);
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
        for(int i = currIndexPos; i < datas.Count; i++)
        {
            if (datas[i].checkIfOption)
            {
                currSentenceId = i;
                currIndexPos = i;
                DisplaySentence();
                break;
            }
            else if (datas[i].checkIfEnd)
            {
                EndDialogue();
                currSentenceId = i;
                currIndexPos = i;
                Debug.Log(currSentenceId);
                break;
            }
        }
    }

    //Add reference to mini game script here 
    private string rhythmGameSceneName = "Rhythm Game";
    private string pairMatchingGameSceneName = "Jon macthing pair";
    private string trivaSceneName = "Jon Benia minigame";

    IEnumerator RhythmGameFTAE1()
    {
        yield return new WaitForSeconds(0.5f);

        while (dialogueActive)
        {
            yield return null;
        }

        // Use SceneManager.LoadSceneAsync to load the scene asynchronously.
        SceneManager.LoadSceneAsync(rhythmGameSceneName, LoadSceneMode.Additive);

        bool checkWinLose = true;
        yield return new WaitForSeconds(0.5f);

        while (SceneManager.GetSceneByName(rhythmGameSceneName).isLoaded)
        {
            checkWinLose = GameManager.situation;
            yield return null;
        }

        if (checkWinLose)
        {
            Debug.Log("Success");
            OpenDialogue(" ", 31); // Call StartDialogue without arguments
        }
        else
        {
            Debug.Log("Fail");
            OpenDialogue(" ", 34); // Call StartDialogue without arguments
        }
    }

    IEnumerator RhythmGameSAE1()
    {
        yield return new WaitForSeconds(0.5f);

        while (dialogueActive)
        {
            yield return null;
        }

        // Use SceneManager.LoadSceneAsync to load the scene asynchronously.
        SceneManager.LoadSceneAsync(rhythmGameSceneName, LoadSceneMode.Additive);

        bool checkWinLose = true;
        yield return new WaitForSeconds(0.5f);

        while (SceneManager.GetSceneByName(rhythmGameSceneName).isLoaded)
        {
            Debug.Log("Loop");
            checkWinLose = GameManager.situation;
            yield return null;
        }
        
        if (checkWinLose)
        {
            Debug.Log("Success");
            OpenDialogue(" ", 34); // Call StartDialogue without arguments
        }
        else
        {
            Debug.Log("Fail");
            OpenDialogue(" ", 37); // Call StartDialogue without arguments
        }
    }

    IEnumerator RhythmGameSAE2()
    {
        yield return new WaitForSeconds(0.5f);

        while (dialogueActive)
        {
            yield return null;
        }

        // Use SceneManager.LoadSceneAsync to load the scene asynchronously.
        SceneManager.LoadSceneAsync(rhythmGameSceneName, LoadSceneMode.Additive);

        bool checkWinLose = true;
        yield return new WaitForSeconds(0.5f);

        while (SceneManager.GetSceneByName(rhythmGameSceneName).isLoaded)
        {
            checkWinLose = GameManager.situation;
            yield return null;
        }

        if (checkWinLose)
        {
            Debug.Log("Success");
            OpenDialogue(" ", 400); // Call StartDialogue without arguments
        }
        else
        {
            Debug.Log("Fail");
            OpenDialogue(" ", 404); // Call StartDialogue without arguments
        }
    }

    IEnumerator PairMatchingGameFTAE1()
    {
        yield return new WaitForSeconds(0.5f);

        while (dialogueActive)
        {
            yield return null;
        }

        // Use SceneManager.LoadSceneAsync to load the scene asynchronously.
        SceneManager.LoadSceneAsync(pairMatchingGameSceneName, LoadSceneMode.Additive);

        bool checkWinLose = true;
        yield return new WaitForSeconds(0.5f);

        while (SceneManager.GetSceneByName(pairMatchingGameSceneName).isLoaded)
        {
            checkWinLose = GameControllerScript.situation;
            yield return null;
        }

        if (checkWinLose)
        {
            Debug.Log("Success");
            OpenDialogue(" ", 305); // Call StartDialogue without arguments
        }
        else
        {
            Debug.Log("Fail");
            OpenDialogue(" ", 311); // Call StartDialogue without arguments
        }
    }

    IEnumerator PairMatchingGameSAE1()
    {
        yield return new WaitForSeconds(0.5f);

        while (dialogueActive)
        {
            yield return null;
        }


        // Use SceneManager.LoadSceneAsync to load the scene asynchronously.
        SceneManager.LoadSceneAsync(pairMatchingGameSceneName, LoadSceneMode.Additive);

        bool checkWinLose = true;
        yield return new WaitForSeconds(0.5f);

        while (SceneManager.GetSceneByName(pairMatchingGameSceneName).isLoaded)
        {
            checkWinLose = GameControllerScript.situation;
            yield return null;
        }

        if (checkWinLose)
        {
            Debug.Log("Success");
            OpenDialogue(" ", 308); // Call StartDialogue without arguments
        }
        else
        {
            Debug.Log("Fail");
            OpenDialogue(" ", 314); // Call StartDialogue without arguments
        }
    }

    IEnumerator TriviaGameFTAE1()
    {
        yield return new WaitForSeconds(0.5f);

        while (dialogueActive)
        {
            yield return null;
        }


        // Use SceneManager.LoadSceneAsync to load the scene asynchronously.
        SceneManager.LoadSceneAsync(trivaSceneName, LoadSceneMode.Additive);

        bool checkWinLose = true;
        yield return new WaitForSeconds(0.5f);

        while (SceneManager.GetSceneByName(trivaSceneName).isLoaded)
        {
            checkWinLose = Dialogue2.situation;
            yield return null;
        }

        if (checkWinLose)
        {
            Debug.Log("Success");
            OpenDialogue(" ", 216); // Call StartDialogue without arguments
        }
        else
        {
            Debug.Log("Fail");
            OpenDialogue(" ", 263); // Call StartDialogue without arguments
        }
    }

    IEnumerator TriviaGameSAE1()
    {
        yield return new WaitForSeconds(0.5f);

        while (dialogueActive)
        {
            yield return null;
        }

        // Use SceneManager.LoadSceneAsync to load the scene asynchronously.
        SceneManager.LoadSceneAsync(trivaSceneName, LoadSceneMode.Additive);

        bool checkWinLose = true;
        yield return new WaitForSeconds(0.5f);

        while (SceneManager.GetSceneByName(trivaSceneName).isLoaded)
        {
            checkWinLose = Dialogue2.situation;
            yield return null;
        }

        if (checkWinLose)
        {
            Debug.Log("Success");
            OpenDialogue(" ", 219); // Call StartDialogue without arguments
        }
        else
        {
            Debug.Log("Fail");
            OpenDialogue(" ", 266); // Call StartDialogue without arguments
        }
    }
}
