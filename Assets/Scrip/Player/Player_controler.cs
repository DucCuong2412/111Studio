using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;

public class Player_controler : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rg;
    private float trai_phai;
    private bool isfacingRight = true;
    public bool checkJump = true;
    public float speed = 10f;
    public float jump = 20f;
    public Animator anim;
    public Slider _slider;
    public float maxheal;
    public GameObject saving;
    public bool consong = true;



    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        _slider.maxValue = maxheal;
        _slider.value = maxheal;
    }

    // Update is called once per frame
    void Update()
    {
        flip();
        if (consong == true)
        {
        Vector2 vt = transform.localScale;
        trai_phai = Input.GetAxis("Horizontal");
        rg.velocity = new Vector2(trai_phai * speed, rg.velocity.y);
        anim.SetFloat("move", math.abs(trai_phai));

        onjump();
        atk();
        die();
        }




    }
   
   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tilemap"))
        {
            checkJump = true;



        }
      
        else if (collision.gameObject.CompareTag("trap"))
        {
            checkJump = true;
         

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("atk"))
        {
            
            
                _slider.value--;
            
        }
        if (collision.gameObject.CompareTag("trap"))
        {
            _slider.value--;

        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("tilemap"))
        {
            checkJump = false;
        }
    }
    void atk()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("atk1");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("atk2");
        }
    }
    void die()
    {
        if (_slider.value == 0)
        {
            consong = false;
            anim.SetTrigger("die");
            Destroy(gameObject, 1.5f);
        }
    }

    void flip()
    {
        if (isfacingRight && trai_phai < 0 || !isfacingRight && trai_phai > 0)
        {
            isfacingRight = !isfacingRight;
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }
    public void onjump()
    {
        if (checkJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rg.velocity += new Vector2(0f, jump);
                anim.SetTrigger("jump");
            }
        }
    }   

}