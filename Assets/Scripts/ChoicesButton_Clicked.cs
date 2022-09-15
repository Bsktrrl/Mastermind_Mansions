using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoicesButton_Clicked : MonoBehaviour
{
    SceneManager sceneManager;
    AudioManager audioManager;

    [SerializeField] GameObject thisGO;
    Sprite thisSprite;
    Color thisColor;

    AudioSource audioEffects;


    //--------------------


    private void Awake()
    {
        sceneManager = FindObjectOfType<SceneManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Start()
    {
        audioEffects = GetComponent<AudioSource>();

        thisSprite = thisGO.GetComponent<Image>().sprite;
        thisColor = thisGO.GetComponent<Image>().color;
    }
    private void Update()
    {
        DestroyObject();
    }


    //--------------------


    public void onClicked()
    {
        if (sceneManager.pause == true) { return; }

        audioEffects.PlayOneShot(audioManager.GetClickAudio(), 0.75f);

        for (int i = 0; i < sceneManager.Box_Display_List.Count; i++)
        {
            if (sceneManager.Box_Display_List[i].transform.Find("Background").GetComponent<Image>().sprite == null)
            {
                thisColor = new Color(1f, 1f, 1f, 1f);

                sceneManager.Box_Display_List[i].transform.Find("Background").GetComponent<Image>().sprite = thisSprite;
                sceneManager.Box_Display_List[i].transform.Find("Background").GetComponent<Image>().color = thisColor;
                
                return;
            }
        }
    }

    public Sprite GetChoiceSprite()
    {
        return thisSprite;
    }

    void DestroyObject()
    {
        if (sceneManager.destroyBO)
        {
            Destroy(this.gameObject);
        }
    }
}
