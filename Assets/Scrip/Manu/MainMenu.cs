using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu, Updategame, Tutorial, HighScore,setting,quiz;



    public float volume;
    public float save_volume;
    public AudioMixer mixer;
    public Slider Slider;

    
    void Start()
    {
        Menu.SetActive(true);
        Updategame.SetActive(false);
        Tutorial.SetActive(false);
        HighScore.SetActive(false);
        setting.SetActive(false);
       
        if (PlayerPrefs.HasKey("mussic_volume"))
        {
            loadmusic();
            Slider.value = save_volume;
        }
        else
        {
            _Music(save_volume);
        }
    }
    private void Update()
    {
        
        Debug.Log("âm lượng:"+PlayerPrefs.GetFloat("mussic_volume"));
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
    public void _quiz()
    {
        quiz.SetActive(true);
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
        quiz.SetActive(false);
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
        save_volume = volume;
        Debug.Log("volume" + volume);
        PlayerPrefs.SetFloat("mussic_volume", save_volume);
        
    }
    public void loadmusic()
    {
        save_volume = PlayerPrefs.GetFloat("mussic_volume");
        volume = save_volume;
        _Music(volume);
        Slider.value= volume;   

    }
    public void play()
    {
        SceneManager.LoadScene(3);

    }


}
