using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SanhGAme : MonoBehaviour
{
        
    void Start()
    {
        
    }

    public void LoadScene(string index) 
    { 
        SceneManager.LoadScene(index);
    }

    
}
