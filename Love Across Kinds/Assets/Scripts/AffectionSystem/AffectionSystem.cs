using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AffectionSystem : MonoBehaviour
{
    //Singleton
    public static AffectionSystem Instance;

    //Validation
    [SerializeField] private int maxAffectionPoint = 7;

    //UI stuffs
    [SerializeField] private GameObject AffectionUIParent;
    //[SerializeField] private TextMeshProUGUI Xina;
    //[SerializeField] private TextMeshProUGUI Benia;
    //[SerializeField] private TextMeshProUGUI Florine;

    //Array of Class
    public CharacterAffection[] characterAffections = new CharacterAffection[3];

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        characterAffections[0].name = "Xina";
        characterAffections[1].name = "Benia";
        characterAffections[2].name = "Florine";
    }

    //Call this method when need to + affection
    //Note: name for if statement need to change to character that is interacting
    public void GetAffection()
    {
        for(int i = 0; i < characterAffections.Length; i++)
        {
            if(EventClick.interactObjectName == characterAffections[i].name && characterAffections[i].affectionPoint < maxAffectionPoint)
            {
                int num = characterAffections[i].affectionPoint++;
                characterAffections[i].hearts[num].SetActive(true);
            }
        }
    }

    public void OpenAffectionWindow()
    {
        AffectionUIParent.SetActive(true);
    }

    public void CloseAffectionWindow()
    {
        AffectionUIParent.SetActive(false);
    }
}

[System.Serializable]
public class CharacterAffection
{
    public string name;
    public int affectionPoint;
    public GameObject[] hearts;
}
