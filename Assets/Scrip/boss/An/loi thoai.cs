using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class loithoai : MonoBehaviour
{
    float time = 0f;
    public GameObject panel;
    public TextMeshProUGUI text;
    public HealthBossAn healthBoss;
    public int count = 0;  // Bắt đầu với giá trị 0
    bool isRunning = false;
    bool hasShownText1 = false;
    bool hasShownText1a = false;
    bool hasShownText2 = false;
    bool hasShownHealthUnder50 = false;

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

    void Start()
    {
        
        panel.SetActive(false); 
    }

    void Update()
    {
        time += Time.deltaTime;

        
        if (Input.GetKeyUp(KeyCode.E) && isRunning)
        {
            count++;  
        }
        if (time >= 3f && !hasShownText1)
        {
            panel.SetActive(true);
            text.text = text1;  
            hasShownText1 = true;  
        }

        if ((time >= 6f || count >= 1) && !hasShownText1a)
        {
            text.text = text1a;  
            hasShownText1a = true;  
            isRunning = true;  
        }

        if ((time >= 9f || count >= 2) && !hasShownText2)
        {
            text.text = text2;  
            hasShownText2 = true;  
            count++; 
            isRunning = true;
        }

        if ((time >= 12f || count >= 3) && hasShownText2)
        {
            panel.SetActive(false);  
            isRunning = false;  
        }

        
        if ((healthBoss.currentHealth / healthBoss.maxheal) * 100 < 50 && !hasShownHealthUnder50)
        {
            panel.SetActive(true);
            text.text = text4;  
            hasShownHealthUnder50 = true; 
            isRunning = true;
        }
        if ((healthBoss.currentHealth / healthBoss.maxheal) * 100 < 80 )
        {
            panel.SetActive(true);
            text.text = text5; 
            hasShownHealthUnder50 = true;  
            isRunning = true;
        }
        if ((healthBoss.currentHealth / healthBoss.maxheal) * 100 < 1 )
        {
            panel.SetActive(true);
            text.text = text6;  
            hasShownHealthUnder50 = true; 
            isRunning = true;
        }
    }
}