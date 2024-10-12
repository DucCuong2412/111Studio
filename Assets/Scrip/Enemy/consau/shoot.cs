using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D Rigidbody2D;
    public  GameObject newhitball;
    public int rotate;
    

    float timer = 0;
    public float force;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        Rigidbody2D.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot +rotate);
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            if (newhitball != null)
            {
                Destroy(gameObject);
                GameObject spawnedHitball = Instantiate(newhitball, transform.position, transform.rotation);
                Destroy(spawnedHitball, 0.5f);
            }
           
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameObject spawnedHitball = Instantiate(newhitball, transform.position, transform.rotation);
            Destroy(spawnedHitball, 0.5f);
        }
        if (collision.gameObject.CompareTag("tilemap"))
        {
            Destroy(gameObject);
            GameObject spawnedHitball = Instantiate(newhitball, transform.position, transform.rotation);
            Destroy(spawnedHitball, 0.5f);
        }
    }

}
