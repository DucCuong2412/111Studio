using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controler : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rg;
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

        if (Input.GetKey(KeyCode.A))
        {
            vt.x = -1;
            transform.Translate(Vector3.left * speed * Time.deltaTime * 2);
            anim.SetTrigger("run");

        }
        if (Input.GetKey(KeyCode.D))
        {
            vt.x = 1;
            transform.Translate(Vector3.right * speed * Time.deltaTime * 2);
            anim.SetTrigger("run");

        }

        transform.localScale = vt;
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
}
