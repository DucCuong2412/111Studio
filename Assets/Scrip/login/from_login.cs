using UnityEngine;
[System.Serializable]
public class login
{
    public string id;
    public string password;
    public string againpasss;
    public string hightScore1;
    public string hightScore2;
    public string hightScore3;
    public string hightScore4;
    public string hightScoreASM;

    public int checklevel1;
    public int checklevel2;
    public int checklevel3;
    public int checklevel4;
    public int asm;

    public int heal;
    public int speed;
    public int count;
    public login(string id, string password, string againpass)
    {
        this.id = id;
        this.password = password;
        this.againpasss = againpass;
        this.hightScore1 = "0"; // fixx cứng higtScore lúc mới tạo tài khoản
        this.hightScore2 = "0";
        this.hightScore3 = "0";
        this.hightScore4 = "0";
        this.hightScoreASM = "0";
        this.checklevel1 = 0;
        this.checklevel2 = 0;
        this.checklevel3 = 0;
        this.checklevel4 = 0;
        this.asm = 0;
        this.heal = 25;
        this.speed = 10;
        this.count = 5;

    }
}
