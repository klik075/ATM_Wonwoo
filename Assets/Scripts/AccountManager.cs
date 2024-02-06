using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using static System.Net.WebRequestMethods;
[Serializable]
public class AccountInfo
{
    public string accountName;
    public string accountId;
    public string accountPassword;
    public int accountMoney;
    public AccountInfo()
    {
        this.accountName = "";
        this.accountId = "";
        this.accountPassword = "";
        this.accountMoney = 0;
    }
    public AccountInfo(string accountName,string accountId,string accountPassword ,int accountMoney)
    {
        this.accountName = accountName;
        this.accountId = accountId;
        this.accountPassword = accountPassword;
        this.accountMoney = accountMoney;
    }
}
[Serializable]
public class AccountList
{
    public Dictionary<string, AccountInfo> List;
    public AccountList()
    {
        List = new Dictionary<string, AccountInfo>();//이거를 해줘야 널 레퍼런스가 안 뜬다.
    }
}
public class AccountManager : MonoBehaviour
{
    public static AccountManager instance;

    public AccountList accountList;

    [HideInInspector]
    public Account curAccount;

    [SerializeField]
    private GameObject loginUI;
    [SerializeField]
    private GameObject depositUI;
    [SerializeField]
    private GameObject withdrawUI;
    [SerializeField]
    private GameObject remittanceUI;
    private void Awake()
    {
        instance = this;
        accountList = new AccountList();
        if(LoadData() != null)
            accountList = LoadData();
        Debug.Log($"저장된 계좌 수 : {accountList.List?.Count}");
        PrintAllTheAccounts();
    }
    public void Deposit() 
    {
        depositUI.GetComponent<Deposit>().Input(curAccount);
    }
    public void Withdraw()
    {
        withdrawUI.GetComponent<Withdraw>().Input(curAccount);
    }
    public void Remittance()
    {
        remittanceUI.GetComponent<Remittance>().Input(curAccount);
    }
    public void Login()
    {
        loginUI.GetComponent<Login>().LogInToMyId();
    }
    public void CreateAccount()
    {
        loginUI.GetComponent<SignUp>().CreateAccount();
    }
    public void SaveData()
    {
        var binaryFormatter = new BinaryFormatter();
        var memoryStream = new MemoryStream();
        binaryFormatter.Serialize(memoryStream, accountList);

        PlayerPrefs.SetString("AccountList", Convert.ToBase64String(memoryStream.GetBuffer()));
    }
    public AccountList LoadData()
    {
        AccountList loadList = null;
        string save = PlayerPrefs.GetString("AccountList", null);
        if (!string.IsNullOrEmpty(save))
        {
            var binaryFormatter = new BinaryFormatter();
            var memoryStream = new MemoryStream(Convert.FromBase64String(save));
            loadList = (AccountList)binaryFormatter.Deserialize(memoryStream);
        }
        return loadList;
    }
    public void PrintAllTheAccounts()
    {
        foreach (var account in accountList.List) 
        {
            Debug.Log($"등록된 ID : {account.Key}, 이름 : {account.Value.accountName}, 비밀번호 : {account.Value.accountPassword}, 잔액 :{account.Value.accountMoney}");
        }
    }
    public bool CheckTheID(string id)
    {
        if(accountList.List.TryGetValue(id, out AccountInfo accountInfo))
            return true;
        else
            return false;
    }
    public void BankRun()
    {
        PlayerPrefs.DeleteAll();
        accountList.List = new Dictionary<string, AccountInfo>();
        Debug.Log("은행이 파산했습니다.");
    }
}
