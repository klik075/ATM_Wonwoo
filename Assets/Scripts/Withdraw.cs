using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Withdraw : MonoBehaviour
{
    [SerializeField]
    private GameObject inOutUI;
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private GameObject errorUI;
    private int withdrawMoney = 0;
    public void FieldUpdate()
    {
        if (inputField.text != "")//값이 있을 때
            withdrawMoney = int.Parse(inputField.text);
        else //값이 없을 때
            withdrawMoney = 0;
    }
    public void Back()
    {
        gameObject.SetActive(false);
        inOutUI.SetActive(true);
        inputField.text = "";
        withdrawMoney = 0;
    }
    public void OnClickPlusButton(int money)
    {
        withdrawMoney += money;
        inputField.text = withdrawMoney.ToString();
    }
    public void Input(Account account)
    {
        if (account.accountInfo.accountMoney >= withdrawMoney && withdrawMoney > 0)
        {
            account.accountInfo.accountMoney -= withdrawMoney;
            account.cash += withdrawMoney;
            AccountManager.instance.SaveData();
        }
        else
        {
            errorUI.SetActive(true);
        }
    }
}
