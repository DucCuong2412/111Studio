using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Boss_da : MonoBehaviour
{
    public GameObject player;
    public float khoangcach;
    public float speed = 5f;
    public Animator anim;
    public GameObject ScoreLab;
    public Slider _slider;
    public float maxheal=2;
    public bool have_score=false;
    public bool sound_die=false;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _slider.maxValue=maxheal;
        _slider.value = maxheal;

    }

    void Update()
    {
        if (player != null)
        {
            khoangcach = Vector3.Distance(transform.position, player.transform.position);

            if (khoangcach < 5f && khoangcach >= 2)
            {
                Vector3 targetPosition = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                transform.position = targetPosition;

                Vector3 direction = player.transform.position - transform.position;

              
                if (direction.x > 0)
                {
                  
                    transform.rotation = Quaternion.Euler(0, 180, 0); // Quay 180 độ quanh trục Y
                }
                else if (direction.x < 0)
                {
                 
                    transform.rotation = Quaternion.Euler(0, 0, 0); // Không quay
                }
            }
            else if (khoangcach < 2f)
            {
            
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
        die();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("atk"))
        {
            _slider.value--;
        }
    }
    public void die()
    {
        if (_slider.value == 0)
        {
            if (!sound_die)
            {
            anim.SetTrigger("die");
                AudioManager.instance.sound_bot_die();
                sound_die = true;

            }
            Destroy(gameObject, 2f);

            if (!have_score)
            {

                Vector2 scorePosition = new Vector2(transform.position.x , transform.position.y + 3f);
                Instantiate(ScoreLab, scorePosition, Quaternion.identity);
                have_score = true;
            }
        }
    }


}
