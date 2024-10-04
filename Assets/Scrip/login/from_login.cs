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
        this.hightScore1 = "0"; // Điểm cao mặc định
        this.hightScore2 = "0"; // Điểm cao mặc định
        this.hightScore3 = "0"; // Điểm cao mặc định
        this.hightScore4 = "0"; // Điểm cao mặc định
        this.hightScoreASM = "0"; // Điểm cao mặc định
    }
}
