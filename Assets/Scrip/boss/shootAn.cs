using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootAn : MonoBehaviour
{
    GameObject player;

    public GameObject bulletA1, bulletA2;
    public Transform bulletPos1,bulletPos2, bulletPos3;

    int RandomAtk;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public  void atk1()
    {
        Instantiate(bulletA1,bulletPos1.position, Quaternion.identity);
        Instantiate(bulletA1, bulletPos3.position, Quaternion.identity);

    }
    public void atk2()
    {
        Instantiate(bulletA2,bulletPos2.position, Quaternion.identity);
        
    }
}

 
