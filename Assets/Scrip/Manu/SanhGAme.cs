using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SanhGAme : MonoBehaviour
{
    private List<login> accounts = new List<login>();
    private string filePath;
    public data data;
    public GameObject panelloi;

    private void Start()
    {
        filePath = Application.dataPath + "/fromlogin.json"; 
        LoadAccounts(); // Tải các tài khoản hiện có khi bắt đầu
    }
    public void gamelab1()
    {

        login accountToCheck = accounts.Find(account => account.id == data.account);
        Debug.Log("loadacc");

        if (accountToCheck != null)
        {
            Debug.Log("timacc");
            if (accountToCheck.checklevel1 >= 2)
            {
                Debug.Log("Level quá cao, xin thử lại level khác.");
                panelloi.SetActive(true);
            }
            else
            {
                Debug.Log("Level hợp lệ.");
                data.level = 1;
                SceneManager.LoadScene(3);
                data.scoreee = 0;
            }
        }
        else
        {
            Debug.Log("Không tìm thấy tài khoản với ID: " + data.account);
        }
    }
    public void gamelab2()
    {

        login accountToCheck = accounts.Find(account => account.id == data.account);

        if (accountToCheck != null)
        {
            if (accountToCheck.checklevel2 >= 2)
            {
                Debug.Log("Level quá cao, xin thử lại level khác.");
                panelloi.SetActive(true);
            }
            else
            {
                Debug.Log("Level hợp lệ.");
                data.level = 2;
                SceneManager.LoadScene(4);
                data.scoreee = 0;
            }
        }
        else
        {
            Debug.Log("Không tìm thấy tài khoản với ID: " + data.account);
        }
    }




    public void gamelab3()
    {

        login accountToCheck = accounts.Find(account => account.id == data.account);

        if (accountToCheck != null)
        {
            if (accountToCheck.checklevel3 >= 2)
            {
                Debug.Log("Level quá cao, xin thử lại level khác.");
                panelloi.SetActive(true);
            }
            else
            {
                Debug.Log("Level hợp lệ.");
                data.level = 3;
                SceneManager.LoadScene(5);
                data.scoreee = 0;
            }
        }
        else
        {
            Debug.Log("Không tìm thấy tài khoản với ID: " + data.account);
        }
    }
    public void gamelab4()
    {

        login accountToCheck = accounts.Find(account => account.id == data.account);

        if (accountToCheck != null)
        {
            if (accountToCheck.checklevel4 >= 2)
            {
                Debug.Log("Level quá cao, xin thử lại level khác.");


                panelloi.SetActive(true);
            }
            else
            {
                Debug.Log("Level hợp lệ.");
                data.level = 4;
                SceneManager.LoadScene(6);
                data.scoreee = 0;
            }
        }
        else
        {
            Debug.Log("Không tìm thấy tài khoản với ID: " + data.account);
        }
    }
    public void gameasm()
    {

        login accountToCheck = accounts.Find(account => account.id == data.account);

        if (accountToCheck != null)
        {
            if (accountToCheck.asm >= 3)
            {
                Debug.Log("Level quá cao, xin thử lại level khác.");
                panelloi.SetActive(true);
            }
            else
            {
                Debug.Log("Level hợp lệ.");
                data.level = 5;
                SceneManager.LoadScene(7);
                data.scoreee = 0;
            }
        }
        else
        {
            Debug.Log("Không tìm thấy tài khoản với ID: " + data.account);
        }
    }

    public void backpanelLoi()
    {
        panelloi.SetActive (false);
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

    // Lưu danh sách tài khoản vào file JSON
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
            this.accounts = accounts; // Khởi tạo danh sách tài khoản
        }
    }
}
