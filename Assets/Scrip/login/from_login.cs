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
    }
}
