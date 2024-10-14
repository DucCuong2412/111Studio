using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrigerBoom : MonoBehaviour
{
    public GameObject boomb;
    private void Update()
    {
        Destroy(gameObject, 4f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
             GameObject eb= Instantiate(boomb, spawnPosition, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
