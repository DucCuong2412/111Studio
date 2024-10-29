using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab_asm1 : MonoBehaviour
{
    public data scrip;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scrip.scoreee++;
            AudioManager.instance.sound_score();
            Destroy(gameObject);
        }   
        if (collision.gameObject.CompareTag("dash"))
        {
            
            AudioManager.instance.sound_score();
            Destroy(gameObject);
        }
    }
}
