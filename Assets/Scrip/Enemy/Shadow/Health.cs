using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Health : MonoBehaviour
{
    public Slider healthSlider;
    public float maxhealth;
    public float currentHealth;
    Animator animator;
   
    void Start()
    {
        healthSlider.maxValue = maxhealth;
        currentHealth = maxhealth;
        healthSlider.value = currentHealth;
        animator = GetComponent<Animator>();
        
    }

   
    void Update()
    {
        healthSlider.value = currentHealth;
        die();

        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("atk"))
        {
            TakeDamage(1);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxhealth);
        healthSlider.value = currentHealth;
    }
    public void die()
    {
        if(currentHealth <= 0)
        {
            animator.SetTrigger("die");
            Destroy(gameObject, 1.5f);
        }
    }
}
