using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;

public class dash : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rg;
    private float trai_phai;
    private bool isfacingRight = true;
    public bool checkJump = true;
    public float speed; //defalt=10;
    public float jump = 20f;
    public Animator anim;
    public Slider _slider;
    private float maxheal; //defalt=20
    public bool consong = true;
    public GameObject panelDead;
    public float count = 0;
    public data scriptable;

    // Thêm biến kiểm soát lướt
    public float countdash = 0;
    public float dashDistance = 10f;
    public float dashSpeed = 30f;
    private bool isDashing = false;

    private void Awake()
    {
        maxheal = scriptable.heal;
        speed = scriptable.speed;
    }

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
        countdash += Time.deltaTime;

        if (consong == true)
        {
            Vector2 vt = transform.localScale;
            trai_phai = Input.GetAxis("Horizontal");
            if (!isDashing) // Ngăn di chuyển bình thường khi đang lướt
            {
                rg.velocity = new Vector2(trai_phai * speed, rg.velocity.y);
            }
            anim.SetFloat("move", math.abs(trai_phai));

            dash_player();
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
            AudioManager.instance.sound_score();
            Destroy(collision.gameObject);
        }
    }

    // Dừng lướt ngay khi chạm vào tilemap
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tilemap") && isDashing)
        {
            EndDash();
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

    void dash_player()
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
                Invoke("EndDash", dashDistance / dashSpeed);
                countdash = 0;
                AudioManager.instance.sounddash();
            }
        }
    }

    // Hàm kết thúc lướt
    void EndDash()
    {
        isDashing = false;
    }
}
