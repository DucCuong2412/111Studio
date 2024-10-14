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
    public bool consong = true;
    public float speed = 5f;
    public GameObject laze, dacbiet, Item_lab, bulet_left, butlet_right;//prefab đạn
    public GameObject tranformAtk, tranformdacbiet, left, right;//position bắn đạn
    public Slider _slider;
    public float maxheal = 20;
    public GameObject panel, panel_boss_die;//boss
    public TextMeshProUGUI Panel_text;//trong pale boss
    public TextMeshProUGUI text_chat;//text in scren
    public TextMeshProUGUI text_chat_boss_die;//text when bos die
    public string text1 = "Ngươi có gan đến tận đây sao";
    public string text2 = "Ta có lời khen cho ngươi đó";
    public string text3 = "nhưng giờ ngươi sẽ bỏ mạng ở đây thôi";
    public string text4 = "Boss: Đi chết đi";
    public string textcc = "xem chiêu cuối mạnh nhất của ta đây";
    public string text5 = "ựa.... nhất định ta sẽ báo thù";
    public string text_none = "";
    private float coutText = 1;//đếm thay đổi khi bấm nút
    //count khi người chơi gặp boss lần đầu tiên
    public int landau = 1;

    public int count_dacbiet;
    public int count_chieucuoi;
    public int coubulet;
    public float timer;




    private void Start()
    {
        _slider.maxValue = maxheal;
        _slider.value = maxheal;
        maxheal = 10f;
        panel.SetActive(false);

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            coubulet++;
            count_chieucuoi++;
            count_dacbiet++;
            timer = 0;
            Debug.Log(coubulet);
        }
        if (consong == true)
        {
            LookatPlayer();
            FollowPlayer();


            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer > 10 & distanceToPlayer < 30)
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
                consong = false;
                Instantiate(Item_lab, transform.position, Quaternion.identity);
                panel_boss_die.SetActive(true);
                text_chat_boss_die.text = text5.ToString();
                text_chat.text = text_none.ToString();
                anim.SetTrigger("die");
                Destroy(gameObject, 3f);
            }

            if (distanceToPlayer < 20)//atk
            {
                /////////////////////
                if (coubulet >= 2)
                {
                    Instantiate(laze, tranformAtk.transform.position, Quaternion.identity);


                    anim.SetTrigger("atk");
                    coubulet = 0;
                }
                ///////////////////////
                if (count_dacbiet == 10)
                {


                    Instantiate(dacbiet, tranformdacbiet.transform.position, Quaternion.identity);
                    text_chat.text = text4.ToString();
                   

                }
                if (count_dacbiet ==11)
                {
                    Instantiate(dacbiet, tranformdacbiet.transform.position, Quaternion.identity);
                    

                    count_dacbiet = 0;

                }
                if (count_dacbiet >= 2)
                {
                    text_chat.text = text_none.ToString();

                }
                ////////////////////////
                if (count_chieucuoi >= 20)
                {
                    text_chat.text = textcc.ToString();
                    if (isFliped == false)
                    {
                        Instantiate(bulet_left, left.transform.position, Quaternion.identity);
                        Instantiate(butlet_right, right.transform.position, Quaternion.identity);

                    }
                    else
                    {
                        Instantiate(bulet_left, right.transform.position, Quaternion.identity);
                        Instantiate(butlet_right, left.transform.position, Quaternion.identity);

                    }
                    count_chieucuoi = 0;
                }
                if (count_chieucuoi >= 2)
                {
                    text_chat.text = text_none.ToString();
                }

            }
            else
            {
                Debug.Log("cheest");
            }
        }
    }
    public void next()
    {
        coutText++;

    }
    public void close_panel_boss_die()
    {
        panel_boss_die.SetActive(false);
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


        if (distanceToPlayer > 5 & distanceToPlayer < 20)
        {
            Vector3 direction = new Vector3(player.position.x - transform.position.x, 0, 0).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }


}
