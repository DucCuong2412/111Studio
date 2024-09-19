using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss_da : MonoBehaviour
{
    public GameObject player;
    public float khoangcach;
    public float speed = 5f;
    public Animator anim;
    public float groundHeight = 2.5f;  // Độ cao cố định của Boss từ mặt đất

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            khoangcach = Vector3.Distance(transform.position, player.transform.position);

            if (khoangcach < 5f && khoangcach >= 2)
            {
                Vector3 targetPosition = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                targetPosition.y = groundHeight;
                transform.position = targetPosition;

                Vector3 direction = player.transform.position - transform.position;

                // Lật quái vật theo hướng di chuyển của player
                if (direction.x > 0)
                {
                    // Quái vật quay trái
                    transform.rotation = Quaternion.Euler(0, 180, 0); // Quay 180 độ quanh trục Y
                }
                else if (direction.x < 0)
                {
                    // Quái vật quay phải
                    transform.rotation = Quaternion.Euler(0, 0, 0); // Không quay
                }
            }
            else if (khoangcach < 2f)
            {
                // Xử lý hành vi khi gần
                anim.SetTrigger("atk");
            }
            else
            {
                anim.SetTrigger("idle");
            }
        }
        else
        {
            Debug.LogWarning("Không tìm thấy đối tượng Player!");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("atk"))
        {
            anim.SetTrigger("die");
            Destroy(gameObject, 2f);
        }
    }
   
}
