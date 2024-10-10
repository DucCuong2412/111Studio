using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class flipboss : MonoBehaviour
{
    public Transform player;
    public bool isFliped = false;
    public GameObject paneltest;
    public TextMeshProUGUI INtext1;
    public string text1 = "xin chào. tôi là con boss mạnh nhất ở đây tên An";
    public string text2 = "sao mày dám đến đây";
    public float count = 0;

    public void LookatPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < player.position.x && isFliped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFliped = false; 
        }
        else if (transform.position.x > player.position.x && !isFliped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFliped = true; 
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Console.OutputEncoding = Encoding.UTF8;
            paneltest.SetActive(true);
            INtext1.text = text1.ToString();


        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Console.OutputEncoding = Encoding.UTF8;
            paneltest.SetActive(true);
            INtext1.text = text2.ToString();


        }



    }

}
