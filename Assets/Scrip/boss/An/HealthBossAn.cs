using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBossAn : MonoBehaviour
{
    public Slider _slider;
    public float maxheal = 100f;
    public float currentHealth;
    Animator animator;
    public GameObject health;
    public GameObject spawn_boom, doow_wwin;
    public GameObject score;
    public float timer;
    public bool havscore = false;


    void Start()
    {
        _slider.maxValue = maxheal;
        currentHealth = maxheal;
        _slider.value = currentHealth;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        die();
        _slider.value = currentHealth;
        if (_slider.value == 29)
        {
            spawn_boom.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("atk"))
        {
            TakeDamage(1);

        }
        if (collision.gameObject.CompareTag("chieudacbiet"))
        {
            TakeDamage(5);

        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxheal);
        _slider.value = currentHealth;
    }
    public void die()
    {
        if (_slider.value == 0)
        {
            animator.SetTrigger("dead");
            StartCoroutine(Delay());
            spawn_boom.SetActive(false);
            doow_wwin.SetActive(true);

            //kiểm tra thời gian để tính score
            timer -= 5;//trừ đi để cân bằng thời gian
            if (timer <= 30f)
            {
                if (!havscore)
                {

                    for (int i = 0; i < 10; i++)
                    {
                        Instantiate(score, transform.position, Quaternion.identity);

                    }
                    havscore = true;

                }
            }
            else if (timer > 30 && timer <= 45)
            {
                if (!havscore)
                {

                    for (int i = 0; i < 9; i++)
                    {
                        Instantiate(score, transform.position, Quaternion.identity);

                    }
                    havscore = true;

                }
            }
            else if (timer > 35 && timer <= 40)
            {
                if (!havscore)
                {

                    for (int i = 0; i < 8; i++)
                    {
                        Instantiate(score, transform.position, Quaternion.identity);

                    }
                    havscore = true;

                }
            }
            else if (timer > 40 && timer <= 50)
            {
                if (!havscore)
                {

                    for (int i = 0; i < 7; i++)
                    {
                        Instantiate(score, transform.position, Quaternion.identity);

                    }
                    havscore = true;

                }
            }
            else if (timer > 50 && timer <= 55)
            {
                if (!havscore)
                {

                    for (int i = 0; i < 6; i++)
                    {
                        Instantiate(score, transform.position, Quaternion.identity);

                    }
                    havscore = true;

                }
            } else 
            {
                if (!havscore)
                {

                    for (int i = 0; i < 5; i++)
                    {
                        Instantiate(score, transform.position, Quaternion.identity);

                    }
                    havscore = true;

                }
            }


        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(2f);
            health.SetActive(false);
            this.gameObject.SetActive(false);
        }


    }

}
