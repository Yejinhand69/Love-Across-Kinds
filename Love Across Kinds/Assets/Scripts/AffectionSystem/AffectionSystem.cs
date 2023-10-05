using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AffectionSystem : MonoBehaviour
{
    //Singleton
    public static AffectionSystem Instance;

    //Validation
    [SerializeField] private int maxAffectionPoint = 7;

    //UI stuffs
    [SerializeField] private GameObject AffectionUIParent;
    [SerializeField] private TextMeshProUGUI Xina;
    [SerializeField] private TextMeshProUGUI Bernia;
    [SerializeField] private TextMeshProUGUI Florine;
    [SerializeField] private TextMeshProUGUI XinaAffectionPoint;
    [SerializeField]private TextMeshProUGUI BerniaAffectionPoint;
    [SerializeField] private TextMeshProUGUI FlorineAffectionPoint;

    //Array of Class
    public CharacterAffection[] characterAffections = new CharacterAffection[3];

    //Storage for dialogue data list
    private List<DialogueData> dialogueDatas;

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
        characterAffections[1].name = "Bernia";
        characterAffections[2].name = "Florine";

        dialogueDatas = DataProcessor.dataList;
    }

    //Call this method when need to + affection
    //Note: name for if statement need to change to character that is interacting
    public void GetAffection()
    {
        for(int i = 0; i < characterAffections.Length; i++)
        {
            if(dialogueDatas[DialogueManager.currIndexPos].name == characterAffections[i].name && characterAffections[i].affectionPoint < maxAffectionPoint)
            {
                characterAffections[i].affectionPoint++;
            }
        }

        XinaAffectionPoint.text = characterAffections[0].affectionPoint.ToString();
        BerniaAffectionPoint.text = characterAffections[1].affectionPoint.ToString();
        FlorineAffectionPoint.text = characterAffections[2].affectionPoint.ToString();
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
}
