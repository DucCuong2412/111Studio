using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spanw1;
    public Transform spanw2;
    public Transform spanw3;
    public Transform spanw4;
    public Transform spanw5;

    public GameObject boomb;
    public float timer;
    public int count;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= 1)
        {
            count++;
            timer = 0;
        }
        if (count == 5 )
        {
        List<Transform> spawnPoints = new List<Transform> { spanw1, spanw2, spanw3, spanw4, spanw5 };

        int randomIndex = Random.Range(0, spawnPoints.Count);

        Instantiate(boomb, spawnPoints[randomIndex].position, Quaternion.identity);
            count = 0;
        }

    }
}
