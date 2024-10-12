using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Thaylap : MonoBehaviour
{
    public Transform player;
    public Animator anim;
    public bool isFliped = false;
    public float speed = 5f;
    public float count_laze;
    public float count_dacbiet;
    public GameObject laze, dacbiet, Item_lab;
    public GameObject tranformAtk, tranformdacbiet;
    public Slider _slider;
    public float maxheal=20;
    public GameObject panel;
    public TextMeshProUGUI Panel_text;
    public TextMeshProUGUI text_chat;
    public string text1 = "Ngươi có gan đến tận đây sao";
    public string text2 = "Ta có lời khen cho ngươi đó";
    public string text3 = "nhưng giờ ngươi sẽ bỏ mạng ở đây thôi";
    public string text4 = "Boss: Đi chết đi";
    public string text5 = "ựa.... nhất định ta sẽ báo thù";
    public string text_none = "";
    public float coutText = 0;//đếm thay đổi khi bấm nút
    //count khi người chơi gặp boss lần đầu tiên
    public int landau = 1;






    private void Start()
    {
        _slider.maxValue = maxheal;
        _slider.value = maxheal;
        maxheal = 10f;
        panel.SetActive(false);

    }

    void Update()
    {
        LookatPlayer();
        FollowPlayer();
        count_dacbiet += Time.deltaTime;
        count_laze += Time.deltaTime;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > 10 & distanceToPlayer < 20)
        {
            landau++;
            panel.SetActive(true);
           



        }
        if (coutText == 1)
        {
            Panel_text.text = text1.ToString();
        }
        else if (coutText == 2)
        {
            Panel_text.text = text2.ToString();
        }
        else if (coutText == 3)
        {
            Panel_text.text = text3.ToString();
        }
        else if (coutText == 4)
        {
            panel.SetActive(false);

        }

        if (_slider.value == 0)
        {
            Instantiate(Item_lab, transform.position, Quaternion.identity);
            panel.SetActive(true);
            Panel_text.text = text5.ToString();
            text_chat.text = text_none.ToString();
            anim.SetTrigger("die");
            Destroy(gameObject,2f);
        }

        if ( distanceToPlayer < 15)//atk
        {
            if (count_laze >= 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    Instantiate(laze, tranformAtk.transform.position, Quaternion.identity);
                }
                anim.SetTrigger("atk");
                count_laze = 0;

            }
            if (count_dacbiet >= 10)
            {
                for (int i = 0; i < 10; i++)
                {

                    Instantiate(dacbiet, tranformdacbiet.transform.position, Quaternion.identity);
                    text_chat.text = text4.ToString();
                    count_dacbiet = 0;

                }

                count_dacbiet = 0;

            }
            if (count_dacbiet >= 2)
            {
                text_chat.text = text_none.ToString();

            }

        }
    }
    public void next()
    {
        coutText++;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("atk"))
        {
            _slider.value--;
        }
    }

    public void LookatPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < player.position.x && isFliped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFliped = false;
        }
        else if (transform.position.x > player.position.x && !isFliped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFliped = true;
        }
    }

    public void FollowPlayer()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);


        if (distanceToPlayer > 2 & distanceToPlayer < 15)
        {
            Vector3 direction = new Vector3(player.position.x - transform.position.x, 0, 0).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

}
