using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    GameObject Player;

    public float speed = 1f;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceX = Mathf.Abs(transform.position.x - Player.transform.position.x);
        float DistanceY = Mathf.Abs(transform.position.y - Player.transform.position.y);

        Vector3 targetPos = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        if (Player != null)
        {
           if (DistanceX >1 && DistanceX <=5 && DistanceY<5) 
            {
                LookatPlayer();

            }
        }
    }

    public void LookatPlayer()
    {
        Vector3 direction = Player.transform.position - transform.position;

        if (direction.x > 0)
        {
           
            transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
        else if (direction.x < 0)
        {
            
            transform.rotation = Quaternion.Euler(0, 180, 0); 
        }
    }
}
