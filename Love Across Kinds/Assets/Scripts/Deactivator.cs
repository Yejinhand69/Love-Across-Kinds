using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deactivator : MonoBehaviour
{
    public GameObject[] ObjInScene;
    // Update is called once per frame
    void Update()
    {
        if(SceneManager.sceneCount > 1)
        {
            for(int i = 0; i < ObjInScene.Length; i++)
            {
                ObjInScene[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < ObjInScene.Length; i++)
            {
                ObjInScene[i].SetActive(true);
            }
        }
    }
}
