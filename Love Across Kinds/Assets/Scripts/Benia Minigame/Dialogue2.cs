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

    public string[] response1a;
    public string[] response1b;
    public string[] response1c;
    public string[] response2a;
    public string[] response2b;
    public string[] response2c;
    public string[] response3a;
    public string[] response3b;
    public string[] response3c;
    public string[] response4a;
    public string[] response4b;
    public string[] response4c;

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

    public GameObject win;
    public GameObject lose;

    public ScoringB scorePoint;
    public TimingB time;
    public TimingB2 time2;
    public TimingB3 time3;
    public TimingB4 time4;

    public int ChoiceMade;
    public int ChoiceMade2;
    public int ChoiceMade3;
    public int ChoiceMade4;

    public bool done = false;
    public bool done2 = false;
    public bool done3 = false;

    public bool responseDone1 = false;
    public bool responseDone1b = false;
    public bool responseDone1c = false;
    public bool responseDone2a = false;
    public bool responseDone2b = false;     
    public bool responseDone2c = false;
    public bool responseDone3a = false;    
    public bool responseDone3b = false;
    public bool responseDone3c = false;
    public bool responseDone4a = false;
    public bool responseDone4b = false;
    public bool responseDone4c = false;

    private int index;
    private int index2;
    private int index3;
    private int index4;

    private int Rindex;
    private int Rindex2;
    private int Rindex3;
    private int Rindex4;

    public static bool situation;
    void Start()
    {
        
        textComponent.text = string.Empty;
        StartDialogue();
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

            if (responseDone1 == true)
            {
                Response1a();
                responseDone1 = false;

                if (responseDone1 == false)
                {
                    StopAllCoroutines();
                    textComponent.text = response1a[Rindex];
                }
            }
            else if (responseDone1b == true)
            {
                Response1b();
                responseDone1b = false;

                if (responseDone1b == false)
                {
                    StopAllCoroutines();
                    textComponent.text = response1b[Rindex];
                }
            }
            else if (responseDone1c == true)
            {
                Response1c();
                responseDone1c = false;

                if (responseDone1c == false)
                {
                    StopAllCoroutines();
                    textComponent.text = response1c[Rindex];
                }
            }

            //if (time.chooseLeastScoreAnswer == true)
            //{
            //    Response1b();
            //    time.chooseLeastScoreAnswer = false;
            //}

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

            if (responseDone2a == true)
            {
                Response2a();
                responseDone2a = false;

                if (responseDone2a == false)
                {
                    StopAllCoroutines();
                    textComponent.text = response2a[Rindex2];
                }
            }
            else if (responseDone2b == true)
            {
                Response2b();
                responseDone2b = false;

                if (responseDone2b == false)
                {
                    StopAllCoroutines();
                    textComponent.text = response2b[Rindex2];
                }
            }
            else if (responseDone2c == true)
            {
                Response2c();
                responseDone2c = false;

                if (responseDone2c == false)
                {
                    StopAllCoroutines();
                    textComponent.text = response2c[Rindex2];
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

            if (responseDone3a == true)
            {
                Response3a();
                responseDone3a = false;

                if (responseDone3a == false)
                {
                    StopAllCoroutines();
                    textComponent.text = response3a[Rindex3];
                }
            }
            else if (responseDone3b == true)
            {
                Response3b();
                responseDone3b = false;

                if (responseDone3b == false)
                {
                    StopAllCoroutines();
                    textComponent.text = response3b[Rindex3];
                }
            }
            else if (responseDone3c == true)
            {
                Response3c();
                responseDone3c = false;

                if (responseDone3c == false)
                {
                    StopAllCoroutines();
                    textComponent.text = response3c[Rindex3];
                }
            }

            if (done3 == true)
            {

                NextLine4();
                done3 = false;

                if (done3 == false)
                {
                    StopAllCoroutines();
                    textComponent.text = lines4[index4];
                }
            }

            if (responseDone4a == true)
            {
                Response4a();
                responseDone4a = false;

                if (responseDone4a == false)
                {
                    StopAllCoroutines();
                    textComponent.text = response4a[Rindex4];
                }
            }
            else if (responseDone4b == true)
            {
                Response4b();
                responseDone4b = false;

                if (responseDone4b == false)
                {
                    StopAllCoroutines();
                    textComponent.text = response4b[Rindex4];
                }
            }
            else if (responseDone4c == true)
            {
                Response4c();
                responseDone4c = false;

                if (responseDone4c == false)
                {
                    StopAllCoroutines();
                    textComponent.text = response4c[Rindex4];
                }
            }

        }

        if (ChoiceMade == 1)
        {
            Choice01.SetActive(false);
            Choice02.SetActive(false);
            Choice03.SetActive(false);
            timer.SetActive(false);
            responseDone1 = true;
        }
        else if (ChoiceMade == 2 || time.chooseLeastScoreAnswer == true) 
        {
            Choice01.SetActive(false);
            Choice02.SetActive(false);
            Choice03.SetActive(false);
            timer.SetActive(false);
            responseDone1b = true;
            
        }
        else if (ChoiceMade == 3)
        {
            Choice01.SetActive(false);
            Choice02.SetActive(false);
            Choice03.SetActive(false);
            timer.SetActive(false);
            responseDone1c = true;
        }

        if (ChoiceMade2 == 1)
        {            
            Choice04.SetActive(false);
            Choice05.SetActive(false);
            Choice06.SetActive(false);
            timer2.SetActive(false);
            responseDone2a = true;
        }
        else if(ChoiceMade2 == 2)
        {
            Choice04.SetActive(false);
            Choice05.SetActive(false);
            Choice06.SetActive(false);
            timer2.SetActive(false);
            responseDone2b = true;
        }
        else if (ChoiceMade2 == 3 || time2.chooseLeastScoreAnswer == true)
        {
            Choice04.SetActive(false);
            Choice05.SetActive(false);
            Choice06.SetActive(false);
            timer2.SetActive(false);
            responseDone2c = true;
        }

        if (ChoiceMade3 == 1 || time3.chooseLeastScoreAnswer == true)
        {
            Choice07.SetActive(false);
            Choice08.SetActive(false);
            Choice09.SetActive(false);
            timer3.SetActive(false);
            responseDone3a = true;
        }
        else if (ChoiceMade3 == 2)
        {
            Choice07.SetActive(false);
            Choice08.SetActive(false);
            Choice09.SetActive(false);
            timer3.SetActive(false);
            responseDone3b = true;
        }
        else if (ChoiceMade3 == 3)
        {
            Choice07.SetActive(false);
            Choice08.SetActive(false);
            Choice09.SetActive(false);
            timer3.SetActive(false);
            responseDone3c = true;
        }

        if (ChoiceMade4 == 1 || time4.chooseLeastScoreAnswer == true)
        {
            Choice10.SetActive(false);
            Choice11.SetActive(false);
            Choice12.SetActive(false);
            timer4.SetActive(false);
            responseDone4a = true;
        }
        else if (ChoiceMade4 == 2)
        {
            Choice10.SetActive(false);
            Choice11.SetActive(false);
            Choice12.SetActive(false);
            timer4.SetActive(false);
            responseDone4b = true;
        }
        else if (ChoiceMade4 == 3)
        {
            Choice10.SetActive(false);
            Choice11.SetActive(false);
            Choice12.SetActive(false);
            timer4.SetActive(false);
            responseDone4c = true;
        }
    }

    public void ChoiceOption1a()
    {
        textComponent.text = "“Someone made me sign up actually-”";
        ChoiceMade = 1;
        Debug.Log("1.1 ans");
        scorePoint.AddScore(2);
        
    }

    public void ChoiceOption1b()
    {
        textComponent.text = "“Oh, nothing too interesting-”";
        ChoiceMade = 2;
        Debug.Log("1.2 ans");
        
    }

    public void ChoiceOption1c()
    {
        textComponent.text = "“Something boring, but because of it I met you-”";
        ChoiceMade = 3;
        Debug.Log("1.3 ans");
        scorePoint.AddScore(1);
    }

    public void ChoiceOption2a()
    {
        textComponent.text = "“It was a bit of an accident-”";
        ChoiceMade2 = 1;
        Debug.Log("2.1 ans");
        scorePoint.AddScore(2);
    }

    public void ChoiceOption2b()
    {
        textComponent.text = "“Guess it just came to me-”";
        ChoiceMade2 = 2;
        Debug.Log("2.2 ans");
        scorePoint.AddScore(1);
    }

    public void ChoiceOption2c()
    {
        textComponent.text = "“Well-”";
        ChoiceMade2 = 3;
        Debug.Log("2.3 ans");
        
    }

    public void ChoiceOption3a()
    {
        textComponent.text = "“Well considering that you look like a human-”";
        ChoiceMade3 = 1;
        Debug.Log("3.1 ans");
    }

    public void ChoiceOption3b()
    {
        textComponent.text = "“I know a little bit-”";
        ChoiceMade3 = 2;
        Debug.Log("3.2 ans");
        scorePoint.AddScore(1);
    }

    public void ChoiceOption3c()
    {
        textComponent.text = "“Not exactly-”";
        ChoiceMade3 = 3;
        Debug.Log("3.3 ans");
        scorePoint.AddScore(2);
    }

    public void ChoiceOption4a()
    {
        textComponent.text = "“What, uh- totally-”";
        ChoiceMade4 = 1;
        Debug.Log("3.1 ans");
    }

    public void ChoiceOption4b()
    {
        textComponent.text = "“Was it that obvious?”";
        ChoiceMade4 = 2;
        Debug.Log("3.2 ans");
        scorePoint.AddScore(2);
    }

    public void ChoiceOption4c()
    {
        textComponent.text = "“Uh, Um-”";
        ChoiceMade4 = 3;
        Debug.Log("3.3 ans");
        scorePoint.AddScore(1);
    }

    void StartDialogue()
    {
        index = 0;
        index2 = 0;
        index3 = 0;
        index4 = 0;

        Rindex = 0;
        Rindex2 = 0;
        Rindex3 = 0;
        Rindex4 = 0;

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
        }
    }

    void Response1a()
    {
        Debug.Log(Rindex);
        if (Rindex < response1a.Length - 1)
        {
            Rindex++;
            textComponent.text = string.Empty;
            //StartCoroutine(TypeLine2());
        }
        else if (Rindex > 1)
        {
            done = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    void Response1b()
    {
        Debug.Log(Rindex);
        if (Rindex < response1b.Length - 1)
        {
            Rindex++;
            textComponent.text = string.Empty;
        }
        else if (Rindex > 1)
        {
            done = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    void Response1c()
    {
        Debug.Log(Rindex);
        if (Rindex < response1c.Length - 1)
        {
            Rindex++;
            textComponent.text = string.Empty;
        }
        else if (Rindex > 1)
        {
            done = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Response2a()
    {
        Debug.Log(Rindex2);
        if (Rindex2 < response2a.Length - 1)
        {
            Rindex2++;
            textComponent.text = string.Empty;
        }
        else if (Rindex2 > 1)
        {
            done2 = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Response2b()
    {
        Debug.Log(Rindex2);
        if (Rindex2 < response2b.Length - 1)
        {
            Rindex2++;
            textComponent.text = string.Empty;
        }
        else if (Rindex2 > 1)
        {
            done2 = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Response2c()
    {
        Debug.Log(Rindex2);
        if (Rindex2 < response2c.Length - 1)
        {
            Rindex2++;
            textComponent.text = string.Empty;
        }
        else if (Rindex2 > 1)
        {
            done2 = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Response3a()
    {
        Debug.Log(Rindex3);
        if (Rindex3 < response3a.Length - 1)
        {
            Rindex3++;
            textComponent.text = string.Empty;
        }
        else if (Rindex3 > 1)
        {
            done3 = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Response3b()
    {
        Debug.Log(Rindex3);
        if (Rindex3 < response3b.Length - 1)
        {
            Rindex3++;
            textComponent.text = string.Empty;
        }
        else if (Rindex3 > 1)
        {
            done3 = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Response3c()
    {
        Debug.Log(Rindex3);
        if (Rindex3 < response3c.Length - 1)
        {
            Rindex3++;
            textComponent.text = string.Empty;
        }
        else if (Rindex3 > 1)
        {
            done3 = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Response4a()
    {
        Debug.Log(Rindex4);
        if (Rindex4 < response4a.Length - 1)
        {
            Rindex4++;
            textComponent.text = string.Empty;
        }
        else if (Rindex4 > 1)
        {
            CheckedScore();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Response4b()
    {
        Debug.Log(Rindex4);
        if (Rindex4 < response4b.Length - 1)
        {
            Rindex4++;
            textComponent.text = string.Empty;
        }
        else if (Rindex4 > 1)
        {
            CheckedScore();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Response4c()
    {
        Debug.Log(Rindex4);
        if (Rindex4 < response4c.Length - 1)
        {
            Rindex4++;
            textComponent.text = string.Empty;
        }
        else if (Rindex4 > 1)
        {
            CheckedScore();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void NextLine()
    {
        Debug.Log(index);
        
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
            }
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
        Debug.Log("int2" + index2);
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

    void NextLine4()
    {
        if (index4 < lines4.Length - 1)
        {
            index4++;
            textComponent.text = string.Empty;
            //StartCoroutine(TypeLine3());
        }
        else if (index4 > 1)
        {
            timer4.SetActive(true);
            Choice10.SetActive(true);
            Choice11.SetActive(true);
            Choice12.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }


    }

    void CheckedScore()
    {
        if (scorePoint.score < 4)
        {
            situation = false;
            lose.SetActive(true);
        }
        else
        {
            situation = true;
            win.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Jon Benia minigame");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Lobby");
    }
}

