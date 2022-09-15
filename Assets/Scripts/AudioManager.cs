using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip mainTheme;

    [SerializeField] AudioClip Success;
    [SerializeField] AudioClip Buzzer;

    [SerializeField] AudioClip Click1;
    [SerializeField] AudioClip Click2;
    [SerializeField] AudioClip Click3;
    [SerializeField] AudioClip Click4;
    [SerializeField] AudioClip Click5;


    //--------------------


    public AudioClip GetMainThemeAudio()
    {
        return mainTheme;
    }
    public AudioClip GetSuccessAudio()
    {
        return Success;
    }
    public AudioClip GetBuzzerAudio()
    {
        return Buzzer;
    }
    public AudioClip GetClickAudio()
    {
        int random = Random.Range(1, 5);

        switch (random)
        {
            case 1:
                return Click1;
            case 2:
                return Click2;
            case 3:
                return Click3;
            case 4:
                return Click4;
            case 5:
                return Click5;
            default:
                return Click1;
        }
    }
}
