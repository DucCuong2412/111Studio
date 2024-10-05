using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu, Updategame, Tutorial;
    void Start()
    {
        Menu.SetActive(true);
        Updategame.SetActive(false);
        Tutorial.SetActive(false);
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


    //het chuc nang menu
    public void _BackMenu()
    {
        Menu.SetActive(true);
        Updategame.SetActive(false);
        Tutorial.SetActive(false);
    }
   

  
}
