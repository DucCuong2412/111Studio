using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class loithoai : MonoBehaviour
{

    float timer = 0f;
    public TextMeshProUGUI text;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

    }
}
