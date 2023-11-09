using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TerrainUtils;
using UnityEngine.SceneManagement;

public class Dialogue2 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public string[] lines2;
    public string[] lines3;
    public string[] lines4;
    public float textSpeed;

    public GameObject Choice01;
    public GameObject Choice02;
    public GameObject Choice03;
    public GameObject timer;

    public GameObject Choice04;
    public GameObject Choice05;
    public GameObject Choice06;
    public GameObject timer2;

    public GameObject Choice07;
    public GameObject Choice08;
    public GameObject Choice09;
    public GameObject timer3;

    public GameObject Choice10;
    public GameObject Choice11;
    public GameObject Choice12;
    public GameObject timer4;

    public ScoringB score;

    public int ChoiceMade;
    public int ChoiceMade2;
    public int ChoiceMade3;

    public bool done = false;
    public bool done2 = false;

    private int index;
    private int index2;
    private int index3;

    public static bool situation;

    // Start is called before the first frame update
    void Start()
    {
        
        textComponent.text = string.Empty;
        StartDialogue();
        StartDialogue2();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();



        
            }
            else
            {

                StopAllCoroutines();
                textComponent.text = lines[index];
                
            }

            if (done == true)
            {
                
                NextLine2();
                done = false;

                if (done == false)
                {
                    StopAllCoroutines();
                    textComponent.text = lines2[index2];
                }
            }

            if (done2 == true)
            {
                
                NextLine3();
                done2 = false;

                if (done2 == false)
                {
                    StopAllCoroutines();
                    textComponent.text = lines3[index3];
                }
            }

        }

        if (ChoiceMade >= 1)
        {
            Choice01.SetActive(false);
            Choice02.SetActive(false);
            Choice03.SetActive(false);
            timer.SetActive(false);
            done = true;
        }

        if (ChoiceMade2 >= 1)
        {            
            Choice04.SetActive(false);
            Choice05.SetActive(false);
            Choice06.SetActive(false);
            timer2.SetActive(false);
            done2 = true;
        }

        if (ChoiceMade3 >= 1)
        {
            Choice07.SetActive(false);
            Choice08.SetActive(false);
            Choice09.SetActive(false);
            timer3.SetActive(false);
        }
    }

    public void ChoiceOption1()
    { 
        textComponent.text = "Sorry, I got left behind in the studio...";
        ChoiceMade = 1;
        Debug.Log("1.1 ans");
    }

    public void ChoiceOption2()
    {
        textComponent.text = "I apologise Benia, Game Host Joe held me back.";
        ChoiceMade = 2;
        Debug.Log("1.2 ans");
        score.AddScore(1);
    }

    public void ChoiceOption3()
    {
        textComponent.text = "So sorry, I wanted to come to right away but I couldn't think of anything to say to you... ";
        ChoiceMade = 3;
        Debug.Log("1.3 ans");
        score.AddScore(2);
    }

    public void ChoiceOption4()
    {
        textComponent.text = "0 points";
        ChoiceMade2 = 1;
        Debug.Log("2.1 ans");
    }

    public void ChoiceOption5()
    {
        textComponent.text = "1 points";
        ChoiceMade2 = 2;
        Debug.Log("2.2 ans");
        score.AddScore(1);
    }

    public void ChoiceOption6()
    {
        textComponent.text = "2 points";
        ChoiceMade2 = 3;
        Debug.Log("2.3 ans");
        score.AddScore(2);
    }

    public void ChoiceOption7()
    {
        textComponent.text = "0 points";
        ChoiceMade3 = 1;
        Debug.Log("3.1 ans");
    }

    public void ChoiceOption8()
    {
        textComponent.text = "1 points";
        ChoiceMade3 = 2;
        Debug.Log("3.2 ans");
        score.AddScore(1);
    }

    public void ChoiceOption9()
    {
        textComponent.text = "2 points";
        ChoiceMade3 = 3;
        Debug.Log("3.3 ans");
        score.AddScore(2);
    }

    public void ChoiceOption10()
    {
        textComponent.text = "0 points";
        ChoiceMade3 = 1;
        Debug.Log("3.1 ans");
    }

    public void ChoiceOption11()
    {
        textComponent.text = "1 points";
        ChoiceMade3 = 2;
        Debug.Log("3.2 ans");
        score.AddScore(1);
    }

    public void ChoiceOption12()
    {
        textComponent.text = "2 points";
        ChoiceMade3 = 3;
        Debug.Log("3.3 ans");
        score.AddScore(2);
    }

    void StartDialogue()
    {
        index = 0;
        index2 = 0;
        index3 = 0;
        //StartCoroutine(TypeLine());
        //StartCoroutine(TypeLine2());
        //StartCoroutine(TypeLine3());

        //if (done == true)
        //{
        //    StartCoroutine(TypeLine2());
        //}

        //if (done2 == true)
        //{
        //    StartCoroutine(TypeLine2());
        //}
    }

    void StartDialogue2()
    {
        index2 = 0;
        //StartCoroutine(TypeLine2());
    }

    void StartDialogue3()
    {
        index3 = 0;
        //StartCoroutine(TypeLine3());
    }

    //IEnumerator TypeLine()
    //{
    //    foreach (char c in lines[index].ToCharArray())
    //    {
    //        textComponent.text += c;
    //        yield return new WaitForSeconds(textSpeed);
    //    }
    //}
    //IEnumerator TypeLine2()
    //{
    //    foreach (char c in lines2[index2].ToCharArray())
    //    {
    //        textComponent.text += c;
    //        yield return new WaitForSeconds(textSpeed);
    //    }
    //}
    //IEnumerator TypeLine3()
    //{
    //    foreach (char c in lines3[index3].ToCharArray())
    //    {
    //        textComponent.text += c;
    //        yield return new WaitForSeconds(textSpeed);
    //    }
    //}

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            //StartCoroutine(TypeLine());
        }
        else if(index >= 1)
        {
            timer.SetActive(true);
            Choice01.SetActive(true);
            Choice02.SetActive(true);
            Choice03.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

        
    }

    void NextLine2()
    {
        if (index2 < lines2.Length - 1)
        {
            index2++;
            textComponent.text = string.Empty;
            //StartCoroutine(TypeLine2());
        }
        else if (index2 > 1)
        {
            timer2.SetActive(true);
            Choice04.SetActive(true);
            Choice05.SetActive(true);
            Choice06.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }


    }

    void NextLine3()
    {
        if (index3 < lines3.Length - 1)
        {
            index3++;
            textComponent.text = string.Empty;
            //StartCoroutine(TypeLine3());
        }
        else if (index3 > 1)
        {
            timer3.SetActive(true);
            Choice07.SetActive(true);
            Choice08.SetActive(true);
            Choice09.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }


    }

    public void SuccessButton()
    {
        situation = true;
        SceneManager.UnloadScene("Jon Benia minigame");
    }

    public void FailButton()
    {
        situation = false;
        SceneManager.UnloadScene("Jon Benia minigame");
    }
}

