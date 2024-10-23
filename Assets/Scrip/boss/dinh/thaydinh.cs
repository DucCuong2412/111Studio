using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class thaydinh : MonoBehaviour
{
    public Transform player;
    public Animator anim;
    public bool isFliped = false;
    public bool consong = true;
    public float speed = 5f;
    public GameObject laze, dacbiet, Item_lab, bulet_left, butlet_right;
    public GameObject tranformAtk, tranformdacbiet, left, right;
    public Slider _slider;
    public GameObject _slider_heal;
    public float maxheal = 20;
    public GameObject panel, panel_boss_die;
    public TextMeshProUGUI Panel_text;
    public TextMeshProUGUI text_chat;
    public TextMeshProUGUI text_chat_boss_die;
    private string text1 = "Ngươi có vẻ có khởi đầu thuận lợi đó. khá lắm thằng nhóc";
    private string text2 = "nhưng đừng tự cao với nhưng gì ngươi đã đạt được trước đó";
    private string text3 = "nhưng giờ ngươi sẽ chết dưới tay ta thôi";
    public string text4 = "Boss: Đi chết đi";
    private string textcc = "xem chiêu cuối mạnh nhất của ta đây";
    private string text5 = "không thể tin nổi ta đã thua thằng nhóc này";
    public string text_none = "";
    public float coutText = 0;
    public int landau = 0;
    public int count_dacbiet;
    public int count_chieucuoi;
    public int coubulet;
    public float timer;
    public GameObject boom, door_wingame;
    private bool hasPlayedSound1 = false;
    private bool hasPlayedSound2 = false;
    private bool hasPlayedSound3 = false;
    private bool hasPlayedSound4 = false;
    private bool hasPlayedSound5 = false;
    private bool hasPlayedSound_cc = false;

    
    public float sound4 = 0;
    public float sound__cc = 0;


    private void Start()
    {
        _slider.maxValue = maxheal;
        _slider.value = maxheal;
        panel.SetActive(false);
        _slider_heal.SetActive(false);
        
    }

    void Update()
    {
    
        if (consong == true)
        {
            LookatPlayer();
           

            float distanceX = Mathf.Abs(transform.position.x - player.transform.position.x);
            float distancey = Mathf.Abs(transform.position.y - player.transform.position.y);
            Debug.Log($"disstance X: {distanceX}");

            if (distanceX < 30 && distancey<4)
            {
                _slider_heal.SetActive(true);
                FollowPlayer();
                
                timer += Time.deltaTime;
                sound4 += Time.deltaTime;
                sound__cc = 0;
                landau++;
                if (landau == 1)
                {
                    coutText = 1;

                }
                if (sound4 > 8)
                {
                    hasPlayedSound4 = false;

                }
                if(sound__cc > 10)
                {
                    hasPlayedSound_cc= false;   
                }

                if (timer > 1)
                {
                    coubulet++;
                    count_chieucuoi++;
                    count_dacbiet++;
                    timer = 0;
                    Debug.Log(coubulet);
                }

             

                landau++;
                
                panel.SetActive(true);
                boom.SetActive(true);
                _slider_heal.SetActive(true);
                if (coubulet == 3)
                {
                    Instantiate(laze, tranformAtk.transform.position, Quaternion.identity);
                    anim.SetTrigger("atk");
                    coubulet = 0;
                }

                if (count_dacbiet >= 10)
                {
                    Instantiate(dacbiet, tranformdacbiet.transform.position, Quaternion.identity);
                    text_chat.text = text4.ToString();
                    if (!hasPlayedSound4)
                    {
                        AudioManager.instance.sound_dinh4();
                        sound4 = 0; 
                        hasPlayedSound4=true;
                    }
                    count_dacbiet = 0;
                }

                if (count_dacbiet >= 2)
                {
                    text_chat.text = text_none.ToString();
                }

                if (count_chieucuoi >= 20)
                {
                    if (!hasPlayedSound_cc)
                    {
                        hasPlayedSound4=true;
                        text_chat.text = textcc.ToString();
                        sound__cc = 0;
                        AudioManager.instance.sound_dinhcc();
                        hasPlayedSound_cc=true;
                        sound4 = 0;


                    }
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

           
                if (coutText == 1 && !hasPlayedSound1)
                {
                    Panel_text.text = text1.ToString();
                    AudioManager.instance.sound_dinh1();
                    hasPlayedSound1 = true;
                    Time.timeScale = 0;


                }
                else if (coutText == 2&!hasPlayedSound2)
                {

                    AudioManager.instance.sound_dinh2();
                    Panel_text.text = text2.ToString();
                    hasPlayedSound2 = true;
                }
                else if (coutText == 3&!hasPlayedSound3)
                {
                    AudioManager.instance.sound_dinh3();
                    Panel_text.text = text3.ToString();
                    hasPlayedSound3 = true;
                }
                else if (coutText == 4)
                {
                    panel.SetActive(false);
                    Time.timeScale = 1;

                }
            

            if (_slider.value == 0)
            {
                consong = false;
                Instantiate(Item_lab, transform.position, Quaternion.identity);
                panel_boss_die.SetActive(true);
                if(!hasPlayedSound_cc)
                {
                text_chat_boss_die.text = text5.ToString();
                    AudioManager.instance.sound_dinh5();
                    hasPlayedSound5=true;
                }
                text_chat.text = text_none.ToString();
                anim.SetTrigger("die");
                Destroy(gameObject, 3f);
                AudioManager.instance.sound_die();
                boom.SetActive(false);
                door_wingame.SetActive(true);
                _slider_heal.SetActive(false);


            }

            
        }
    }

    public void next()
    {
        coutText++;
        hasPlayedSound1 = false;
        hasPlayedSound2 = false;
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
        if (collision.gameObject.CompareTag("chieudacbiet"))
        {
            _slider.value -= 5;
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
        if (distanceToPlayer > 5 && distanceToPlayer < 30)
        {
            Vector3 direction = new Vector3(player.position.x - transform.position.x, 0, 0).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
