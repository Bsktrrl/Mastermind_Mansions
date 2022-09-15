using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxButton : MonoBehaviour
{
    SceneManager sceneManager;
    AudioManager audioManager;

    [SerializeField] GameObject thisGO;
    [SerializeField] GameObject backgroundGO;

    Sprite backgroundSprite;
    Color backgroundColor;

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

        backgroundSprite = backgroundGO.GetComponent<Image>().sprite;
        backgroundColor = backgroundGO.GetComponent<Image>().color;
    }


    //--------------------


    public void onClicked()
    {
        if (sceneManager.pause == true) { return; }

        audioEffects.PlayOneShot(audioManager.GetClickAudio(), 0.75f);

        for (int i = 0; i < sceneManager.Box_Display_List.Count; i++)
        {
            if (sceneManager.Box_Display_List[i] == thisGO)
            {
                backgroundColor = new Color(0f, 0f, 0f, 1f);

                sceneManager.Box_Display_List[i].transform.Find("Background").GetComponent<Image>().sprite = backgroundSprite;
                sceneManager.Box_Display_List[i].transform.Find("Background").GetComponent<Image>().color = backgroundColor;

                return;
            }
        }
    }
}
