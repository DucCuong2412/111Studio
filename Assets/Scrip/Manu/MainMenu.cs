using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu, Updategame, Tutorial, HighScore;
    void Start()
    {
        Menu.SetActive(true);
        Updategame.SetActive(false);
        Tutorial.SetActive(false);
        HighScore.SetActive(false);
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

    //het chuc nang menu
    public void _BackMenu()
    {
        Menu.SetActive(true);
        Updategame.SetActive(false);
        Tutorial.SetActive(false);
        HighScore.SetActive(false);
    }
   

  
}
