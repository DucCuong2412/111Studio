using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerSaving : MonoBehaviour
{
    private List<login> accounts = new List<login>();
    private string filePath;

    private void Start()
    {
        filePath = Application.dataPath + "/fromlogin.json"; // Đường dẫn đến file JSON
        LoadAccounts(); // Tải các tài khoản hiện có khi bắt đầu
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            UpdateHighScore("cuong2412", 24122005);
        }
    }

    // Cập nhật điểm cao cho tài khoản theo ID
    public void UpdateHighScore(string id, int newHighScore)
    {
        // Sử dụng LINQ để tìm tài khoản theo ID
        login accountToUpdate = accounts.Find(account => account.id == id);
        
        // Nếu tài khoản được tìm thấy, cập nhật điểm cao
        if (accountToUpdate != null)
        {
            accountToUpdate.hightScore1 = newHighScore.ToString(); // Cập nhật điểm cao
            SaveAccounts(); // Lưu danh sách tài khoản đã cập nhật vào file JSON
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
    }

    // Ghi danh sách tài khoản vào file JSON
    private void SaveAccounts()
    {
        AccountList dataToSave = new AccountList(accounts);
        string json = JsonUtility.ToJson(dataToSave, true);
        File.WriteAllText(filePath, json);
    }

    [System.Serializable]
    public class AccountList
    {
        public List<login> accounts;

        public AccountList(List<login> accounts)
        {
            this.accounts = accounts;
        }
    }
}
