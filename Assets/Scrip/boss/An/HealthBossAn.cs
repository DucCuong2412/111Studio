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
    void Start()
    {
        _slider.maxValue = maxheal;
        currentHealth = maxheal;
        _slider.value = currentHealth;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        die();
        _slider.value = currentHealth;
        if (_slider.value == 49)
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

        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(2f);
            health.SetActive(false);
            this.gameObject.SetActive(false);
        }
  

    }
    
}   
