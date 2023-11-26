using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

    public const int columns = 4;
    public const int rows = 5;

    public const float Xspace = 1.26f;
    public const float Yspace = -1.5f;

    public Scoring score;
    public GameObject win;
    public GameObject timing;

    public Vector2 CardPosittion;

    public bool MoveCard = false;
    public bool cannotWin = true;

    public int winPoint = 0;

    [SerializeField] private MainImageScript startObject;
    [SerializeField] private Sprite[] images;
    [SerializeField] private AudioSource cardDis;

    public static bool situation;

    private int[] Randomiser(int[] locations)
    {
        int[] array = locations.Clone() as int[];
        for(int i=0; i < array.Length; i++)
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    private void Start()
    {
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9};
        locations = Randomiser(locations);

        Vector3 startPosition = startObject.transform.position;

        for(int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                MainImageScript gameImage;
                if(i == 0 && j == 0)
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as MainImageScript;
                }

                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }


    }

    void Update()
    {
        if(winPoint == 10) // if win pair matching minigame
        {
            //SceneManager.LoadScene("Matching pair Win");
            win.SetActive(true);
            timing.SetActive(false);
            cannotWin = false;
            situation = true;
        }
    }

    public MainImageScript firstOpen;
    public MainImageScript secondOpen;

    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    public void imageOpened(MainImageScript startObject)
    {   
        
        if(firstOpen == null )
        {
            
            firstOpen = startObject;
            //startObject.firstPicOpen = true;
        }
        else
        {
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
            
        }
    }

    private IEnumerator CheckGuessed()
    {
        

        if (firstOpen.spriteId == secondOpen.spriteId ) // Compares the two objects
        {
            //startObject.flipAllowed = false;
            //score.AddScore(1);

            //firstOpen.Invoke("Move",0.7f);
            //secondOpen.Invoke("Move", 0.7f);
            firstOpen.Invoke("Destroy", 0.7f); 
            secondOpen.Invoke("Destroy", 0.7f);
            winPoint++;
            Debug.Log(winPoint);
            cardDis.Play();
            yield return new WaitForSeconds(0.5f);
        }
        else
        {
            
            yield return new WaitForSeconds(0.5f); // Start timer
            //score.RemoveScore(1);
            firstOpen.Close();
            secondOpen.Close();
            yield return new WaitForSeconds(0.8f);
        }

        

        firstOpen = null;
        secondOpen = null;
    }


    public void Restart()
    {
        SceneManager.LoadScene("Jon macthing pair");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Lobby1");
    }

    [System.Obsolete]
    public void Continue()
    {
        SceneManager.UnloadScene("Jon macthing pair");
    }
}
