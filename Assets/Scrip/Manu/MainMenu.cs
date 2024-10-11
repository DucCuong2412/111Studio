using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu, Updategame, Tutorial, HighScore,setting
        ;

    public float volume;
    public AudioMixer mixer;

    
    void Start()
    {
        Menu.SetActive(true);
        Updategame.SetActive(false);
        Tutorial.SetActive(false);
        HighScore.SetActive(false);
        setting.SetActive(false);
    }
    // chuc nang cua Menu
    public void _ClickUpdate()
    {
        Updategame.SetActive(true);
        Menu.SetActive(false);
    }
    public void _ClickTutorial()
    {
        Menu.SetActive(false);
        Tutorial.SetActive(true);
    }

    public void _ClickQuit() { 

        Application.Quit();
    }
    public void _ClickScore()
    {
        Menu.SetActive(false);
        HighScore.SetActive(true );
    }
    public void _ClickSetting()
    {
        Menu.SetActive(false );
        setting.SetActive(true);
    }

    //het chuc nang menu
    public void _BackMenu()
    {
        Menu.SetActive(true);
        Updategame.SetActive(false);
        Tutorial.SetActive(false);
        HighScore.SetActive(false);
        setting .SetActive(false);
    }

    //build seting
    public void _Low()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void _High()
    {
        QualitySettings.SetQualityLevel(1);
    }
    //build music
    public void _Music(float volume)
    {
        mixer.SetFloat("volume",volume);
        Debug.Log("volume" + volume);
        
    }


}
