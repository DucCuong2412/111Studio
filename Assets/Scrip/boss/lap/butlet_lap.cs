using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butlet_lap : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D Rigidbody2D;
    public GameObject newhitball;
    public int rotate;

    float timer = 0;
    public float force;
    public float upwardForce = 10f; // Lực đẩy lên trên
    private bool isFalling = false; // Kiểm tra xem viên đạn có đang rơi xuống không

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player_givedame");

        // Đẩy viên đạn lên trên trước khi rơi xuống
        Rigidbody2D.velocity = new Vector2(0, upwardForce);

        transform.rotation = Quaternion.Euler(0, 0, 90 + rotate);
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Sau một thời gian, cho viên đạn rơi xuống nhắm vào nhân vật
        if (timer > 1 && !isFalling)
        {
            Vector3 direction = player.transform.position - transform.position;
            Rigidbody2D.velocity = new Vector2(direction.x, direction.y).normalized * force;

            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + rotate);
            isFalling = true;
        }

        // Nếu viên đạn tồn tại quá 3 giây thì tự hủy và tạo ra newhitball
        if (timer > 4)
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
