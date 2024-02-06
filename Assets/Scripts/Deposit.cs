using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deposit : MonoBehaviour
{
    [SerializeField]
    private GameObject inOutUI;
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private GameObject errorUI;
    private int depositMoney = 0;
    public void FieldUpdate()
    {
        if (inputField.text != "")//값이 있을 때
        {
            depositMoney = int.Parse(inputField.text);
        }
        else //값이 없을 때
            depositMoney = 0;
    }
    public void Back()
    {
        gameObject.SetActive(false);
        inOutUI.SetActive(true);
        inputField.text = "";
        depositMoney = 0;
    }
    public void OnClickPlusButton(int money)
    {
        depositMoney += money;
        inputField.text = depositMoney.ToString();
    }    
    public void Input(Account account)
    {
        if (account.cash >= depositMoney && depositMoney > 0)
        {
            account.cash -= depositMoney;
            account.accountInfo.accountMoney += depositMoney;
            AccountManager.instance.SaveData();
        }
        else
        {
            errorUI.SetActive(true);
        }
    }
}
