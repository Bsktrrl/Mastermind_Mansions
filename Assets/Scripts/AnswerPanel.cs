using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPanel : MonoBehaviour
{
    SceneManager sceneManager;


    //--------------------


    private void Awake()
    {
        sceneManager = FindObjectOfType<SceneManager>();
    }
    private void Update()
    {
        DestroyObject();
    }


    //--------------------


    void DestroyObject()
    {
        if (sceneManager.destroyBO)
        {
            Destroy(this.gameObject);
        }
    }
}
