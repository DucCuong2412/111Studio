using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int NumberLab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.F) && NumberLab ==1)
            {
                SceneManager.LoadSceneAsync("lab1");
            }
            if (Input.GetKey(KeyCode.F) && NumberLab == 2)
            {
                SceneManager.LoadSceneAsync("lab2");
            }
            if (Input.GetKey(KeyCode.F) && NumberLab == 3)
            {
                SceneManager.LoadSceneAsync("lab3");
            }
            if (Input.GetKey(KeyCode.F) && NumberLab == 4)
            {
                SceneManager.LoadSceneAsync("lab4");
            }
            if (Input.GetKey(KeyCode.F) && NumberLab == 5)
            {
                SceneManager.LoadSceneAsync("asm");
            }

        }
    }

}
