using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class loithoai : MonoBehaviour
{
    float time = 0f,time1;
    public GameObject panel,Boss;
    public TextMeshProUGUI text;
    public HealthBossAn bossAn;
    public int count = 0;  // Bắt đầu với giá trị 0
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

    void Start()
    {
        
        panel.SetActive(false); 
    }

    void Update()
    {
        
        time += Time.deltaTime;
        
        if (Input.GetKeyUp(KeyCode.E) && isRuning )
        {
            count++;  
        }
        if (time >= 3f)
        {
            panel.SetActive(true);
            text.text = text1;  
            
        }

        if ((time >= 5f || count >= 1) )
        {
            text.text = text1a;
            count = 1;
            isRuning = true;
        }

        if ((time >= 7f || count >= 2) )
        {
            text.text = text2;  
            isRuning = true ;
            count=2; 
            
        }

        if ((time >= 9f || count >= 3) )
        {
            isRuning = false ;
            panel.SetActive(false);  
            count = 0;
        }


        if(bossAn.currentHealth == 0 && Boss != null)
        {
            time1 += Time.deltaTime;
            panel.SetActive(true);
            text.text = text6.ToString();
            if (time >= 3)
            {
                panel.SetActive(false);
            }
        }

        if ((bossAn.currentHealth / bossAn.maxheal) * 100 < 50 ) 
        {

        }
 
       
    }
}