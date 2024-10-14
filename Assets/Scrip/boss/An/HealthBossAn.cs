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
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("atk"))
        {
            TakeDamage(2);
            
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
        if(currentHealth <= 0)
        {
            animator.SetTrigger("dead");
            Destroy(gameObject, 1.8f);
        }
       
    }
    
}
