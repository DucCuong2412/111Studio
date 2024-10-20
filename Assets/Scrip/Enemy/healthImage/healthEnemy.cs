using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthEnemy : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    [SerializeField] private float CurrentHealth;
    
    private Healthbar _healthBar;

    void Start()
    {
        CurrentHealth = MaxHealth;
        _healthBar = GetComponentInChildren<Healthbar>();
        
    }

    
    void Update()
    {
        
    }
    public void dame(float dameAmount)
    {
         CurrentHealth -= dameAmount;

        _healthBar.Updatehealthbar(MaxHealth, CurrentHealth);
        if (CurrentHealth <= 0)
        {
            die(); 
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("atk"))
        {
            dame(1);
        } 
    }

    public void die()
    {

    }
   
}
