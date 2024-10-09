using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jsonLoginSystem : MonoBehaviour
{
    public TMP_InputField IDinputField;        // Trường nhập ID của người dùng
    public TMP_InputField PassInputField;      // Trường nhập mật khẩu của người dùng
    public GameObject loginSuccessPanel;       // Panel hiển thị khi đăng nhập thành công
    public GameObject loginFailPanel;          // Panel hiển thị khi đăng nhập thất bại

    private List<login> accounts = new List<login>(); // Danh sách tài khoản từ file JSON
    private string filePath;

    public data dataGame;
    private void Start()
    {
        filePath = Application.dataPath + "/fromlogin.json";
        LoadAccounts(); // Load danh sách tài khoản khi game bắt đầu
        loginSuccessPanel.SetActive(false); // Đảm bảo panel thành công tắt khi bắt đầu
        loginFailPanel.SetActive(false);    // Đảm bảo panel lỗi tắt khi bắt đầu
    }
   
    // Đăng nhập
    public void Login()
    {
        // Lấy ID và mật khẩu người dùng nhập
        string enteredID = IDinputField.text;
        string enteredPassword = PassInputField.text;


        // Kiểm tra tài khoản với ID và mật khẩu
        login matchingAccount = accounts.Find(account => account.id == enteredID && account.password == enteredPassword);

        if (matchingAccount != null)
        {
            // Đăng nhập thành công
            SceneManager.LoadScene("menu");
            dataGame.account = enteredID;
            dataGame.password = enteredPassword;
     
            loginFailPanel.SetActive(false);
            Debug.Log("Đăng nhập thành công!");
        }
        else
        {
            // Đăng nhập thất bại
            loginSuccessPanel.SetActive(false);
            loginFailPanel.SetActive(true);
            Debug.Log("Đăng nhập thất bại. Vui lòng kiểm tra lại thông tin.");
        }
    }

    // Đọc danh sách tài khoản từ file JSON
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
            Debug.LogWarning("File JSON chưa tồn tại, vui lòng đăng ký tài khoản trước.");
        }
    }
    public void exit()
    {
        loginSuccessPanel.SetActive(false);
        loginFailPanel.SetActive(false);
    }
    public void backLogin_signup()
    {
        SceneManager.LoadScene("dangki");

    }
    // Lớp dùng để chứa danh sách tài khoản
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
