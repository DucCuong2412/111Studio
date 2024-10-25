using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using System.Linq;

using UnityEngine.SceneManagement;

public class PlayerSaving : MonoBehaviour
{
    private List<login> accounts = new List<login>();
    private string filePath; // Đường dẫn đến file JSON
    public data data;

    public TMP_Text idTexts1;
    public TMP_Text scoreTexts1;

    public TMP_Text idTexts2;
    public TMP_Text scoreTexts2;

    public TMP_Text idTexts3;
    public TMP_Text scoreTexts3;

    public TMP_Text heal;
    public TMP_Text speed;
    public TMP_Text score;

    private void Start()
    {
        filePath = Application.dataPath + "/fromlogin.json"; // Đường dẫn đến file JSON
        LoadAccounts(); // Tải các tài khoản hiện có khi bắt đầu
        DisplayHighScores(); // Hiển thị bảng điểm khi bắt đầu


    }
    private void Awake()
    {
        data.level = data.level;
        UpdateCheckLevel(data.account);

        
    }

    private void Update()
    {
        foreach(var i in accounts)
        {
            heal.text = i.heal.ToString();
            speed.text = i.speed.ToString();
            score.text = i.count.ToString();
            data.heal =i.heal;
            data.speed= i.speed;    


        }

       

      


    }
    public void menu()
    {
        SceneManager.LoadScene(2);

        UpdateHighScore(data.account, data.scoreee);

        UpdateCheckLevel(data.account);

        SaveAccounts();
    }

    // Hàm cập nhật checklevel cho tài khoản theo ID
    private void UpdateCheckLevel(string id)
    {
        login accountToUpdate = accounts.Find(account => account.id == id);

        if (accountToUpdate != null)
        {

                if (data.level == 1)
                {
                    accountToUpdate.checklevel1 += 1;
                    Debug.Log("checklevel1 đã được tăng thêm 1 cho tài khoản: " + id);
                }
                else if (data.level == 2)
                {
                    accountToUpdate.checklevel2 += 1;
                    Debug.Log("checklevel2 đã được tăng thêm 1 cho tài khoản: " + id);
                }
                else if (data.level == 3)
                {
                    accountToUpdate.checklevel3 += 1;
                    Debug.Log("checklevel3 đã được tăng thêm 1 cho tài khoản: " + id);
                }
                else if (data.level == 4)
                {
                    accountToUpdate.checklevel4 += 1;
                    Debug.Log("checklevel4 đã được tăng thêm 1 cho tài khoản: " + id);
                }
                else if (data.level == 5)
                {
                    accountToUpdate.asm += 1;
                    Debug.Log("asm đã được tăng thêm 1 cho tài khoản: " + id);
                }
            
           
        }
        else
        {
            Debug.Log("Không tìm thấy tài khoản với ID: " + id);
        }
    }

    public void _update_speed()
    {
        update_speed(data.account);
    }

    public void _update_heal()
    {
        update_heal(data.account);
    }


    public void again(string index)
    {
        UpdateHighScore(data.account, data.scoreee); 
        SceneManager.LoadScene(index);
        UpdateCheckLevel(data.account);
        SaveAccounts();
        data.scoreee = 0;

    }
    public void update_speed(string accountId)
    {
        // Tìm tài khoản cần cập nhật theo ID
        login accountToUpdate = accounts.Find(account => account.id == accountId);

        if (accountToUpdate != null)
        {
            if (accountToUpdate.count > 0) 
            {
            accountToUpdate.speed += 1;
                accountToUpdate.count -= 1;
            }
            else if(accountToUpdate.count == 0)
            {
                Debug.Log($"score={accountToUpdate.count} <0");
            }
            SaveAccounts();
        }
        else
        {
            Debug.Log("Không tìm thấy tài khoản với ID: " + accountId);
        }
    }
    public void update_heal(string accountID)
    {
        login account = accounts.Find(account => account.id == accountID);
        if(account != null)
        {
            if(account.count > 0)
            {
                account.heal += 1;
                account.count -= 1;
            }
            else
            {
                Debug.Log($"score={account.count} <0");
            }
            SaveAccounts();
        }
    }

    public void UpdateHighScore(string id, int newHighScore)
    {
        login accountToUpdate = accounts.Find(account => account.id == id);

        if (accountToUpdate != null)
        {
            data.checklevel1 = accountToUpdate.checklevel1;//gọi để test
            data.checklevel2 = accountToUpdate.checklevel2;
            data.checklevel3 = accountToUpdate.checklevel3;
            data.checklevel4 = accountToUpdate.checklevel4;

            int currentHighScore = 0; // Biến lưu hightscoree hiện tại

   
            if (data.level == 1)
            {
                currentHighScore = int.Parse(accountToUpdate.hightScore1);
            }
            else if (data.level == 2)
            {
                currentHighScore = int.Parse(accountToUpdate.hightScore2);
            }
            else if (data.level == 3)
            {
                currentHighScore = int.Parse(accountToUpdate.hightScore3);
            }
            else if (data.level == 4)
            {
                currentHighScore = int.Parse(accountToUpdate.hightScore4);
            }

            // So sánh điểm mới và điểm hiện tại
            if (newHighScore > currentHighScore)
            {
                // Cập nhật điểm  cho cấp độ
                if (data.level == 1)
                {
                    accountToUpdate.hightScore1 = newHighScore.ToString(); 
                }
                else if (data.level == 2)
                {
                    accountToUpdate.hightScore2 = newHighScore.ToString(); 
                }
                else if (data.level == 3)
                {
                    accountToUpdate.hightScore3 = newHighScore.ToString();
                }
                else if (data.level == 4)
                {
                    accountToUpdate.hightScore4 = newHighScore.ToString(); 
                }

                SaveAccounts();
                Debug.Log("Điểm cao đã được cập nhật!");
            }
            else
            {
                Debug.Log("Điểm mới không cao hơn điểm cũ. Không cập nhật.");
            }
        }
        else
        {
            Debug.Log("Không tìm thấy tài khoản với ID: " + id);
        }
    }

    // Đọc danh sách các tài khoản từ file JSON
    private void LoadAccounts()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            AccountList loadedData = JsonUtility.FromJson<AccountList>(json);
            accounts = loadedData.accounts;
        }
        else
        {
            Debug.LogWarning("File JSON không tồn tại. Vui lòng đăng ký tài khoản trước."); // Thông báo nếu file JSON không tồn tại
        }
    }

    private void SaveAccounts()
    {
        AccountList dataToSave = new AccountList(accounts);
        string json = JsonUtility.ToJson(dataToSave, true);
        File.WriteAllText(filePath, json);
    }

    // Hiển thị higscore
    private void DisplayHighScores()
    {
        List<(string id, float tongall)> scores = new List<(string, float)>();

        foreach (var account in accounts)
        {
            float totalScore = 0;
            float tonglab = 0;
            float tongasm = 0;

            totalScore += float.Parse(account.hightScore1);
            totalScore += float.Parse(account.hightScore2);
            totalScore += float.Parse(account.hightScore3);
            totalScore += float.Parse(account.hightScore4);

            tonglab = (totalScore / 4) * 0.6f;
            tongasm = float.Parse(account.hightScoreASM)*0.4f;


            float tongall = tonglab + tongasm;

            scores.Add((account.id, tongall));
        }
        var sapxep = scores.OrderByDescending(u => u.tongall).ToList();
        int index = 0;
        foreach (var i in sapxep)
        {
            if (index == 0)
            {
                Debug.Log($"id:{i.id}  score:{i.tongall} ");
                idTexts1.text = i.id.ToString();
                scoreTexts1.text = i.tongall.ToString();

                index++;

            }
            else if (index == 1)
            {
                Debug.Log($"id:{i.id}  score:{i.tongall} ");
                idTexts2.text = i.id.ToString();
                scoreTexts2.text = i.tongall.ToString();
                index++;
            }
            else if (index == 2)
            {
                Debug.Log($"id:{i.id}  score:{i.tongall} ");
                idTexts3.text = i.id.ToString();
                scoreTexts3.text = i.tongall.ToString();
                index++;
            }
        }

    }

    [System.Serializable]
    public class AccountList
    {
        public List<login> accounts;

        public AccountList(List<login> accounts)
        {
            this.accounts = accounts; // Khởi tạo danh sách tài khoản
        }
    }
}
