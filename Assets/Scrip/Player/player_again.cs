using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using System.Linq;

using UnityEngine.SceneManagement;

public class player_again : MonoBehaviour
{
    private List<login> accounts = new List<login>();
    private string filePath; // Đường dẫn đến file JSON
    public data data;
    public GameObject panel_again;
    private login login_data;



    private void Start()
    {
        filePath = Application.dataPath + "/fromlogin.json"; // Đường dẫn đến file JSON
        LoadAccounts(); // Tải các tài khoản hiện có khi bắt đầu
        check_level(data.account); //gọi check level

    }
    private void Awake()
    {
        data.level = data.level;
        UpdateCheckLevel(data.account);
        check_level(data.account);


    }

    private void Update()
    {
        foreach (var i in accounts)
        {

            data.heal = i.heal;
            data.speed = i.speed;


        }


    }

    //chơi nút đồng í chơi lại
    public void dongy()
    {

        login accountToUpdate = accounts.Find(account => account.id == data.account);
        Debug.Log("accc:::::::"+accountToUpdate.id);
        if (accountToUpdate != null)
        {
            //level
            accountToUpdate.checklevel1 = 0;
            accountToUpdate.checklevel2 = 0;
            accountToUpdate.checklevel3 = 0;
            accountToUpdate.checklevel4 = 0;
            accountToUpdate.asm = 0;    
            //higscore
            accountToUpdate.hightScore1 = "0";
            accountToUpdate.hightScore2 = "0";
            accountToUpdate.hightScore3 = "0";
            accountToUpdate.hightScore4 = "0";
            accountToUpdate.hightScoreASM = "0";
            //update
            accountToUpdate.heal = 25;
            accountToUpdate.speed = 10;
            accountToUpdate.count = 5;


            SaveAccounts();
            panel_again.SetActive(false);

        }
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





    public void update_heal(string accountID)
    {
        login account = accounts.Find(account => account.id == accountID);
        if (account != null)
        {
            if (account.count > 0)
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

    public void check_level(string id)
    {
        login accountToUpdate = accounts.Find(account => account.id == id);

        if (accountToUpdate != null)
        {
            if (accountToUpdate.checklevel1 >= 2 && accountToUpdate.checklevel2 >= 2 && accountToUpdate.checklevel3 >= 2 && accountToUpdate.checklevel4 >= 2 && accountToUpdate.asm >= 2)
            {
                CheckPlayerScore();
            }
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
    private void CheckPlayerScore()
    {
        // Lấy ID từ script data
        string currentAccountID = data.account;

        // Tìm tài khoản trong danh sách accounts theo ID
        login currentAccount = accounts.Find(account => account.id == currentAccountID);

        if (currentAccount != null)
        {
            // Tính toán tổng điểm
            float totalScore = float.Parse(currentAccount.hightScore1)
                             + float.Parse(currentAccount.hightScore2)
                             + float.Parse(currentAccount.hightScore3)
                             + float.Parse(currentAccount.hightScore4);

            float tonglab = (totalScore / 4) * 0.6f;
            float tongasm = float.Parse(currentAccount.hightScoreASM) * 0.4f;
            float tongall = tonglab + tongasm;

            // Kiểm tra nếu tổng điểm < 5
            if (tongall < 5)
            {
                panel_again.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Không tìm thấy tài khoản với ID: " + currentAccountID);
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
