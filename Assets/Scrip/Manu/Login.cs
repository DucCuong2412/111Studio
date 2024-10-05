using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour
{
    public GameObject Register, login, loi, daco, MainMenu;

    void Start()
    {
        MainMenu.SetActive(true);
        Register.SetActive(false);
        login.SetActive(false);
        loi.SetActive(false);
        daco.SetActive(false);
    }

    public void SignUp()
    {
        MainMenu.SetActive(false);
        Register.SetActive(true);
    }
    public void LoginGame()
    {
        MainMenu.SetActive(false);
        login.SetActive(true);
    }
    
   
}
