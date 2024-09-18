using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using UnityEngine;

public class Player_controler : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rg;
    private float trai_phai;
    private bool isfacingRight= true;

    public float speed = 5f;
    public float jump = 7f;
    public Animator anim;


    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vt = transform.localScale;

        //if (Input.GetKey(KeyCode.A))
        //{
        //    vt.x = -1;
        //    transform.Translate(Vector3.left * speed * Time.deltaTime * 2);
        //      anim.SetTrigger("run");
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    vt.x = 1;
        //    transform.Translate(Vector3.right * speed * Time.deltaTime * 2);
        //      anim.SetTrigger("run");
        //}
        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    anim.SetTrigger("ide");
        //}
        //if (!Input.GetKeyUp(KeyCode.D))
        //{
        //    anim.SetTrigger("ide");
        //}
        //transform.localScale = vt;
        trai_phai = Input.GetAxis("Horizontal");
        rg.velocity=new Vector2(trai_phai*speed, rg.velocity.y);
        //if (trai_phai < -0.1)
        //{
        //    vt.x = -1;
        //}
        //if (trai_phai > 0.1)
        //{
        //    vt.x = 1;
        //}
        //transform.localScale = vt;
        anim.SetFloat("move", math.abs(trai_phai));

        flip();
        onjump();

    }
    public void onjump()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rg.velocity += new Vector2(0f, jump);
            anim.SetTrigger("sjum");
        }

    }
    void flip()
    {
        if(isfacingRight && trai_phai <0 || !isfacingRight && trai_phai > 0)
        {
            isfacingRight = !isfacingRight;
            Vector3 scale= transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale=scale;
        }
    }
}
