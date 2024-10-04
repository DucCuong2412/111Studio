using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dangki;
    public GameObject login_signup;


    public void buttonDangki()
    {
        login_signup.SetActive(false);
        dangki.SetActive(true);
    }
    public void butotnDangnhap()
    {
        SceneManager.LoadScene("login");
    }
    public void Backlogin_signup()
    {
        login_signup.SetActive(true);
        dangki.SetActive(false);
    }
}
