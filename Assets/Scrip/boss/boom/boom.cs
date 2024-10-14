using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private GameObject player;
    private GameObject boss;
    private Rigidbody2D Rigidbody2D;
    public GameObject newhitball;
    public int rotate;

    float timer = 0;
    public float force = 20f;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        boss = GameObject.FindGameObjectWithTag("boss");

        // Di chuyển bom về hướng boss ngay từ đầu
        MoveTowardsBoss();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 7)
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
        if (collision.gameObject.CompareTag("player"))
        {
            // Khi chạm vào player, di chuyển về hướng boss
            MoveTowardsBoss();
        }
        else if (collision.gameObject.CompareTag("boss"))
        {
            Destroy(gameObject);
            GameObject spawnedHitball = Instantiate(newhitball, transform.position, transform.rotation);
            Destroy(spawnedHitball, 0.5f);
        }
    }

    private void MoveTowardsBoss()
    {
        if (boss != null)
        {
            Vector3 direction = boss.transform.position - transform.position;
            Rigidbody2D.velocity = new Vector2(direction.x, direction.y).normalized * force;

            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + rotate);
        }
    }
}
