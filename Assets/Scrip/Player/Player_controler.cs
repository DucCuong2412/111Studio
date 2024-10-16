﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using TMPro;
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
    private float maxheal = 20;
    public bool consong = true;
    public GameObject panelDead;
    public float count = 0;
    public data scriptable;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI wingame;


    // Thêm biến kiểm soát lướt
    public float countdash = 0;
    public float dashDistance = 10f;
    public float dashSpeed = 30f;
    private bool isDashing = false;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        _slider.maxValue = maxheal;
        _slider.value = maxheal;
        panelDead.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        flip();
        countdash += Time.deltaTime;

        scoreText.text = scriptable.scoreee.ToString();
        wingame.text = scriptable.scoreee.ToString();
        if (consong == true)
        {
            Vector2 vt = transform.localScale;
            trai_phai = Input.GetAxis("Horizontal");
            if (!isDashing) // Ngăn di chuyển bình thường khi đang lướt
            {
                rg.velocity = new Vector2(trai_phai * speed, rg.velocity.y);
            }
            anim.SetFloat("move", math.abs(trai_phai));

            onjump();
            atk();
            dash(); // Gọi hàm lướt
            die();
        }
        else
        {
            count += Time.deltaTime;
            if (count >= 2f)
            {
                panelDead.SetActive(true);
            }
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
        if (collision.gameObject.CompareTag("score"))
        {
            scriptable.scoreee++;
            Destroy(collision.gameObject);
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
        if (collision.gameObject.CompareTag("chieudacbiet"))
        {
            _slider.value -= 5;
        }
        if (collision.gameObject.CompareTag("atkboss"))
        {
            _slider.value -= 3;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tilemap"))
        {
            checkJump = false;
        }
        if (collision.gameObject.CompareTag("trap"))
        {
            checkJump = false;
        }
    }

    void atk()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("atk1");
            AudioManager.instance.sound_atk1();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("atk2");
            AudioManager.instance.sound_atk2();
        }
    }

    void die()
    {
        if (_slider.value == 0)
        {
            consong = false;
            AudioManager.instance.sound_die();
            anim.SetTrigger("die");


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
                AudioManager.instance.sound_jump();
                anim.SetTrigger("jump");
            }
        }
    }

    void dash()
    {
        if (Input.GetKeyDown(KeyCode.L) && !isDashing)
        {
            if (countdash >= 2)
            {

                isDashing = true;
                float dashDirection = isfacingRight ? 1 : -1;
                Vector2 dashVelocity = new Vector2(dashDirection * dashSpeed, rg.velocity.y);
                rg.velocity = dashVelocity;
                anim.SetTrigger("dash");
                AudioManager.instance.sounddash();
                Invoke("EndDash", dashDistance / dashSpeed);
                countdash = 0;
            }

        }
    }

    // Hàm kết thúc lướt
    void EndDash()
    {
        isDashing = false;
    }
}