using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab_asm1 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           //Destroy(collision.gameObject);
        }
    }
}
