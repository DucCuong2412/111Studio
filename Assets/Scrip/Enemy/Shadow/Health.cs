using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Health : MonoBehaviour
{
    public Slider _slider;
    public float maxheal;
    Animator animator;
   
    void Start()
    {
  
        animator = GetComponent<Animator>();
        
    }
    void Update()
    {
        die();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("atk"))
        {
           _slider.value--;
        }
    }
  
    public void die()
    {
        if(_slider.value == 0)
        {
            animator.SetTrigger("die");
            Destroy(gameObject, 1.5f);
        }
    }
}
