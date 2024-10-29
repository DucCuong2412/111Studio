using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inGameMenu : MonoBehaviour
{
    public GameObject MenuPause, Deadpanel;
    public data scriptable;
    int count = 2;
     

    void Start()
    {
        Deadpanel.SetActive(false);
        MenuPause.SetActive(false);
 

        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape) && (count %2 ==0) ) 
        {
            count++;
            Time.timeScale = 0f;
            MenuPause.SetActive(true);

        }else if(Input.GetKeyDown(KeyCode.Escape) && ( count %2 !=0) )
        {
            count--;
            Time.timeScale = 1f;
            MenuPause.SetActive(false);

        }
    }
    public void _ClickContinue()
    {
        count--;
        Time.timeScale = 1f;
        MenuPause.SetActive(false);
        
    }

    public void _LoadScene(string index)
    {
        SceneManager.LoadSceneAsync(index);
        scriptable.scoreee = 0;
    }
   
    public void backMenu()
    {
        SceneManager.LoadScene(2);
    }

   
}
