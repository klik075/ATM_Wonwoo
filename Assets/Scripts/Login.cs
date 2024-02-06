using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField]
    private GameObject _errorUI;
    [SerializeField]
    private GameObject _bankUI;
    [SerializeField]
    private InputField _idInputField;
    [SerializeField]
    private InputField _passwordInputField;

    public void LogInToMyId()
    {
        if (!AccountManager.instance.CheckTheID(_idInputField.text))
        {
            _errorUI.SetActive(true);
            Debug.Log("아이디가 없습니다.");
            return;
        }

        string password = _passwordInputField.text;
        if (password == AccountManager.instance.accountList.List[_idInputField.text].accountPassword)
        {
            AccountManager.instance.curAccount = new Account(AccountManager.instance.accountList.List[_idInputField.text],100000);
            gameObject.SetActive(false);
            _bankUI.SetActive(true);
        }
        else
            _errorUI.SetActive(true);
    }
}
