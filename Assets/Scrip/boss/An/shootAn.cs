using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootAn : MonoBehaviour
{
    GameObject player;

    public GameObject bulletA1, bulletA2,tulucban,Tuonglua;
    public Transform bulletPos1,bulletPos2, bulletPos3,WavePos;
    public GameObject Wave1, Wave2;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("takedame");
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
    public void atk3()
    {
        GameObject tulucmoi = Instantiate(Wave1, WavePos.position, Quaternion.identity);
        Destroy(tulucmoi,3f);
        GameObject tulucmoi2 = Instantiate(Wave2, WavePos.position, Quaternion.identity);
        Destroy(tulucmoi2, 3f);
    }
    public void atk4()
    {
        GameObject tuongluamoi = Instantiate(Tuonglua,bulletPos2.position,Quaternion.identity);
        Destroy(tuongluamoi, 2f);
    }
    public void tuluc()
    {
        GameObject tulucmoi =  Instantiate(tulucban,bulletPos2.position, Quaternion.identity);
        Destroy(tulucmoi,0.5f);
    }
}

 
