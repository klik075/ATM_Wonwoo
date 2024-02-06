using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class SignUp : MonoBehaviour
{
    [SerializeField]
    private Text errorText;
    [SerializeField]
    private GameObject ErrorUI;
    [SerializeField]
    private GameObject SingUpUI;
    [SerializeField]
    private InputField _idInputField;
    [SerializeField]
    private InputField _nameInputField;
    [SerializeField]
    private InputField _PsInputField;
    [SerializeField]
    private InputField _PsConfirmInputField;
    
    private List<string> errArr = new List<string>();

    public void OnClickButton()
    {
        SingUpUI.SetActive(true);
    }
    public void Cancel()
    {
        SingUpUI.SetActive(false);
    }
    public bool CheckId()
    {
        if (_idInputField.text.Length >= 3 && _idInputField.text.Length <= 10)
        {
            if (AccountManager.instance.accountList.List.TryGetValue(_idInputField.text,out AccountInfo accountInfo))
            {
                errArr.Add("ID가 중복되었습니다.");
                return false;
            }
            else
                return true;
        }
        else if (_idInputField.text.Length < 3)
        {
            errArr.Add("ID가 짧습니다.");
            return false;
        }
        else
        {
            errArr.Add("ID가 깁니다.");
            return false;
        }
    }
    public bool CheckName()
    {
        if (_nameInputField.text.Length >= 2 && _nameInputField.text.Length <= 5)
        {
            return true;
        }
        else if (_nameInputField.text.Length < 2)
        {
            errArr.Add("이름이 짧습니다.");
            return false;
        }
        else
        {
            errArr.Add("이름이 깁니다.");
            return false;
        }
    }
    public bool CheckPs()
    {
        if (_PsInputField.text.Length >= 5 && _PsInputField.text.Length <= 15)
        {
            return true;
        }
        else if(_PsInputField.text.Length < 5)
        {
            errArr.Add("비밀번호가 짧습니다."); 
            return false;
        }
        else
        {
            errArr.Add("비밀번호가 깁니다.");
            return false;
        }
    }
    public bool CheckPsConfirm()
    {
        if (_PsConfirmInputField.text == _PsInputField.text)
        {
            return true;
        }
        else 
        {
            errArr.Add("비밀번호가 다릅니다.");
            return false;
        }
    }
    public void CreateAccount()
    {
        errArr.Clear();
        if (CheckId() && CheckName() && CheckPs() && CheckPsConfirm())
        {
            AccountInfo newAccountInfo = new AccountInfo(_nameInputField.text, _idInputField.text, _PsInputField.text, 50000);
            AccountManager.instance.accountList.List.Add(newAccountInfo.accountId, newAccountInfo);
            AccountManager.instance.SaveData();
            Debug.Log("계정을 생성했습니다.");
            InitField();
            errorText.text = string.Empty;
            errArr.Clear();
            SingUpUI.SetActive(false);
        }
        else
        {
            errorText.text = errArr[0];
            ErrorUI.SetActive(true);
        }
    }
    public void InitField()
    {
        _idInputField.text = "";
        _nameInputField.text = "";
        _PsInputField.text = "";
        _PsConfirmInputField.text = "";
    }
}
