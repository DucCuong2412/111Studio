using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jsonReadWriteSystem : MonoBehaviour
{
    public TMP_InputField IDinputField;
    public TMP_InputField PassInputField;
    public TMP_InputField againOutputField; // Đổi tên thành ConfirmPassInputField cho rõ ràng hơn
    public GameObject loi, tontai;

    // Danh sách các tài khoản
    private List<login> accounts = new List<login>();
    private string filePath;

    private void Start()
    {
        filePath = Application.dataPath + "/fromlogin.json";
        LoadAccounts(); // Load các tài khoản hiện có khi bắt đầu
    }

    // Lưu tài khoản mới vào danh sách và ghi vào file
    public void StartToJson() // Đăng ký
    {
        if (PassInputField.text == againOutputField.text)
        {
            // Tạo đối tượng login mới từ dữ liệu nhập
            login newAccount = new login(IDinputField.text, PassInputField.text, againOutputField.text);

            // Kiểm tra nếu ID đã tồn tại
            if (accounts.Exists(account => account.id == newAccount.id))
            {
                tontai.SetActive(true); // Hiển thị thông báo lỗi nếu ID đã tồn tại
            }
            else
            {
                accounts.Add(newAccount); // Thêm tài khoản mới vào danh sách
                SaveAccounts(); // Ghi danh sách vào file JSON

                // Reset lại các trường nhập
                IDinputField.text = "";
                PassInputField.text = "";
                againOutputField.text = "";
                SceneManager.LoadScene("login"); // Chuyển sang scene đăng nhập
            }
        }
        else
        {
            loi.SetActive(true); // Hiển thị thông báo lỗi nếu mật khẩu không khớp
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

    // Đặt lại lỗi đăng ký
    public void loidangki()
    {
        tontai.SetActive(false);
        loi.SetActive(false);
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
