using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speedMove = 2f;
    public GameObject check1, check2;
    float distance;
    Rigidbody2D rb;
    Animator animator;
    private Transform currentPoint;
    Vector2 point;

    GameObject player;
    private bool Isfliped = false;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = check2.transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        point = currentPoint.position - transform.position;

      if (currentPoint == check2.transform)
        {
           flip(1);
            rb.velocity = new Vector2(speedMove,0 );
        }
      else
        {
           flip(-1);
            rb.velocity = new Vector2(-speedMove, 0);
        }

      if( Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == check2.transform)
        {
           
            currentPoint = check1.transform;
        }
        if ( Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == check1.transform)
        {
            
            currentPoint = check2.transform;
        }
        CheckPlayer();
        RotateTowardsPlayer();
    }
    public void flip(float direction)
    {
        Vector3 localScale = transform.localScale;
        if (direction > 0)
            localScale.x = 1; 
        if (direction < 0)
            localScale.x = -1; 
        transform.localScale = localScale;
    }
    public void CheckPlayer()
    {
        
        if (distance <= 7)
        {
            
            speedMove = 0;
            point = transform.position;
            
        }
        else
        {
            speedMove = 2f;
            point = currentPoint.position - transform.position;
            Vector3 direction = (currentPoint.position - transform.position).normalized;
        }
     
    }
    private void RotateTowardsPlayer()
    {

        if (player != null && distance < 7)
        {
            // Tính hướng từ quái vật đến người chơi
            Vector3 direction1 = player.transform.position - transform.position;

            // Chỉ lấy hướng theo chiều ngang (x) để quay trái và phải
            float horizontalDirection = direction1.x;

            // Cập nhật flip để quay theo chiều x
            flip(horizontalDirection);

            // Đặt quái vật quay về hướng người chơi
            if (horizontalDirection > 0) // Nếu người chơi bên phải
            {
                transform.rotation = Quaternion.Euler(0, 0, 0); 
            }
             if (horizontalDirection < 0) // Nếu người chơi bên trái
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }


    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(check1.transform.position, 0.5f);
        Gizmos.DrawWireSphere(check2.transform.position, 0.5f);

    }

}
