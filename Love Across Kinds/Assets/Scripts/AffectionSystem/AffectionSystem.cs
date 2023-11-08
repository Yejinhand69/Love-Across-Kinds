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

    

    //Array of Class
    public CharacterAffection[] characterAffections = new CharacterAffection[3];

    public Dictionary<string, int> affectionDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        characterAffections[0].name = "Xina";
        characterAffections[1].name = "Benia";
        characterAffections[2].name = "Florine";

        affectionDictionary = new Dictionary<string, int>();

        affectionDictionary["Xina"] = 0;
        affectionDictionary["Benia"] = 0;
        affectionDictionary["Florine"] = 0;
    }

    //Call this method when need to + affection
    //Note: name for if statement need to change to character that is interacting
    public void GetAffection()
    {
        for(int i = 0; i < characterAffections.Length; i++)
        {
            if(EventClick.interactObjectName == characterAffections[i].name && characterAffections[i].affectionPoint < maxAffectionPoint)
            {
                AudioManager.instance.PlaySFX("Affection Gain");
                int num = characterAffections[i].affectionPoint++;
                characterAffections[i].hearts[num].SetActive(true);

                affectionDictionary[characterAffections[i].name] = characterAffections[i].affectionPoint;
            }
        }
    }
}

[System.Serializable]
public class CharacterAffection
{
    public string name;
    public int affectionPoint;
    public GameObject[] hearts;
}
