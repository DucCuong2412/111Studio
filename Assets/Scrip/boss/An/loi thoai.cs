using JetBrains.Annotations;
using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

public class loithoai : MonoBehaviour
{
    float time = 0f, time1;
    public GameObject panel;
    public TextMeshProUGUI text;
    public HealthBossAn bossAn;
    public int count = 0;
    private bool isRuning = false;

    [Header("thoại")]
    public string text1 = " Ngươi đã đến rồi à!";
    public string text1a = "Ngươi đã đánh bại lập và đĩnh rồi sao";
    public string text2 = " Xem ngươi có thể bước qua của ải này được không... ";

    [Header("danhnau")]
    public string text3 = "Cái chết chính là sự giải thoát cho ngươi";
    public string text4 = "Thực lực của ngươi cũng chỉ là con kiến trong mắt ta";
    public string text5 = "Có lẽ ta đã già thật rồi";

    [Header("chet")]
    public string text6 = "Ngươi đã thắng";
    public string text7 = "Ngươi cũng nên tỉnh lại thôi";

    private bool hasPlayedSound1 = false;
    private bool hasPlayedSound2 = false;
    private bool hasPlayedSound3 = false;
    private bool hasPlayedSound4 = false;
    private bool hasPlayedSound5 = false;

    private bool hasPlayedSound6 = false;
    private bool hasPlayedSound7 = false;
    private bool hasPlayedSound8 = false;

    private bool hasPlayerSound3Angain = false;
    private bool hasPlayerSound4Angain = false;
    private bool hasPlayerSound5Angain = false;





    public int count_text_die = 0;

    void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        time += Time.deltaTime;
  

        if (Input.GetKeyUp(KeyCode.E) && isRuning)
        {
            count++;
        }

        if (time >= 2f && !hasPlayedSound1)
        {
            panel.SetActive(true);
            text.text = text1;
            AudioManager.instance.sound_an1();
            hasPlayedSound1 = true;
        }

        if ((time >= 5f || count == 1) && !hasPlayedSound2)
        {
            text.text = text1a;
            count = 1;
            isRuning = true;
            AudioManager.instance.sound_an2();
            hasPlayedSound2 = true;
        }

        if ((time >= 10f || count == 2) && !hasPlayedSound3)
        {
            text.text = text2;
            isRuning = true;
            count = 2;
            AudioManager.instance.sound_an3();
            hasPlayedSound3 = true;
        }

        if ((time >= 15f || count == 3) && !hasPlayedSound4)
        {
            isRuning = false;
            panel.SetActive(false);
            time = Time.deltaTime;
            AudioManager.instance.sound_an4();
            hasPlayedSound4 = true;
        }
        
        if (bossAn.currentHealth == 0)
        {
            time1 += Time.deltaTime;
            if ((time > 1f) && !hasPlayedSound6)
            {
                text.text = text6.ToString();
                hasPlayedSound6 = true;
                AudioManager.instance.sound_an6();

            }
            if ((time>4f)&& !hasPlayedSound7)
            {
                text.text = text6.ToString();
                hasPlayedSound7=true;
                AudioManager.instance.sound_an7();

            }
            if (time > 7f && !hasPlayedSound8){
                text.text = text7.ToString();
                AudioManager.instance.sound_an8();
                hasPlayedSound8 = true;
            }
   
            if (time1 >= 9)
            {
                panel.SetActive(false);
            }
        }

        if (bossAn.currentHealth>=40||bossAn.currentHealth<=45  && !hasPlayerSound4Angain)
        {
            AudioManager.instance.sound_an4();
            hasPlayerSound4Angain = true;
        }
        if (bossAn.currentHealth==30 || bossAn.currentHealth <= 35 && !hasPlayerSound3Angain)
        {
            AudioManager.instance.sound_an3();
            hasPlayerSound3Angain = true;
        }
        if (bossAn.currentHealth==20 || bossAn.currentHealth <= 25 && !hasPlayerSound5Angain)
        {
            AudioManager.instance.sound_an5();
            hasPlayerSound5Angain = true;
        }
      
    }
}
