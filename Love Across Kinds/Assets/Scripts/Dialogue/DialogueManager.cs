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
    public GameObject _JoeHand;
    public GameObject dialogueBox;
    public GameObject storyBox;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI storyText;

    //Options stuffs
    public GameObject optionBox1;
    public GameObject optionBox2;
    public GameObject optionBox3;
    public TextMeshProUGUI option1Text;
    public TextMeshProUGUI option2Text;
    public TextMeshProUGUI option3Text;
    public GameObject skipButtonDialogue;
    public GameObject skipButtonStory;

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
    public Animator characterAnim;

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
                    Epidose1Filming.isPlayedSFX = false;
                }
            }
        }

        if(SceneManager.GetActiveScene().name == "Episode 0")
        {
            if (AudioManager.instance._SFXSource.isPlaying)
            {
                skipButtonDialogue.SetActive(false);
                skipButtonStory.SetActive(false);
            }
            else
            {
                skipButtonDialogue.SetActive(true);
                skipButtonStory.SetActive(true);
            }
        }
        
    }

    //Method to show DialogueBox & Search the upmost data of each character by NAME
    public void OpenDialogue(string objName, int startID)
    {
        dialogueAnim.SetBool("isOpenDialogue", true);

        //Get animator from current interact object
        characterAnim = EventClick.interactObjAnim;

        if(characterAnim != null)
        {
            characterAnim.SetBool("DialogueActive", true);
        }
        
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

                AudioManager.instance.PlayVoice(currSentenceId);

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
                storyText.text = sentence;
                
                if(nameText.text == " ")
                {
                    storyBox.SetActive(true);
                    dialogueBox.SetActive(false);
                }
                else
                {
                    storyBox.SetActive(false);
                    dialogueBox.SetActive(true);
                }
                
                if(_JoeHand != null)
                {
                    if (nameText.text.Contains("Game") || nameText.text.Contains("Host") || nameText.text.Contains("Joe"))
                    {
                        _JoeHand.SetActive(true);
                        if (Camera.main != null)
                        {
                            _JoeHand.transform.position = Camera.main.transform.position + Vector3.forward * 3 + Vector3.down;
                        }
                    }
                    else
                    {
                        _JoeHand.SetActive(false);
                    }
                }
                
                //Expressions
                if(characterAnim != null)
                {
                    switch (datas[currIndexPos].expression)
                    {
                        case 1:
                            Debug.Log("Happy");
                            //Expression change here...
                            characterAnim.SetBool("isSmile", true);
                            characterAnim.SetBool("isAngry", false);
                            characterAnim.SetBool("isSad", false);
                            characterAnim.SetBool("isShy", false);
                            break;
                        case 2:
                            Debug.Log("Angry");
                            //Expression change here...
                            characterAnim.SetBool("isSmile", false);
                            characterAnim.SetBool("isAngry", true);
                            characterAnim.SetBool("isSad", false);
                            characterAnim.SetBool("isShy", false);
                            break;
                        case 3:
                            Debug.Log("Sad");
                            //Expression change here...
                            characterAnim.SetBool("isSmile", false);
                            characterAnim.SetBool("isAngry", false);
                            characterAnim.SetBool("isSad", true);
                            characterAnim.SetBool("isShy", false);
                            break;
                        case 4:
                            Debug.Log("Shy");
                            //Expression change here...
                            characterAnim.SetBool("isSmile", false);
                            characterAnim.SetBool("isAngry", false);
                            characterAnim.SetBool("isSad", false);
                            characterAnim.SetBool("isShy", true);
                            break;
                        default:
                            Debug.Log("Neutral");
                            //Expression change here...
                            characterAnim.SetBool("isSmile", false);
                            characterAnim.SetBool("isAngry", false);
                            characterAnim.SetBool("isSad", false);
                            characterAnim.SetBool("isShy", false);
                            break;
                    }
                }

                if (datas[currIndexPos].checkIfAffection)
                {
                    AffectionSystem.Instance.GetAffection();
                    datas[currIndexPos].checkIfAffection = false;
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

        if (characterAnim != null)
        {
            characterAnim.SetBool("DialogueActive", false);
        }

        dialogueActive = false;

        if(_JoeHand != null)
        {
            _JoeHand.SetActive(false);
        }

        if (datas[currIndexPos].checkIfAffection)
        {
            AffectionSystem.Instance.GetAffection();
            datas[currIndexPos].checkIfAffection = false;
        }

        switch (datas[currIndexPos]._event)
        {
            case 1:
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

            case 2:
                ScavengerEvent.isScavengerEvent = true;
                Debug.Log(ScavengerEvent.isScavengerEvent);
                break;

            case 3:
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

            case 4:
                
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
                    SceneManager.LoadScene("LivingFloor" + PhaseManager.instance.currentEpisode);
                }

                if (PhaseManager.instance.currentPhase == "Special")
                {
                    SceneManager.LoadScene("LivingFloor" + PhaseManager.instance.currentEpisode);
                }

                break;


            case 5:
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
                currSentenceId = i;
                currIndexPos = i;
                EndDialogue();
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
