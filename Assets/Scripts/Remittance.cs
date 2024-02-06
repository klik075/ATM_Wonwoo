using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class Remittance : MonoBehaviour
{
    [SerializeField]
    private GameObject inOutUI;
    [SerializeField]
    private InputField targetInputField;
    [SerializeField]
    private InputField ammountInputField;
    [SerializeField]
    private GameObject errorUI;
    [SerializeField]
    private Text errText;

    private List<string> errArr = new List<string>();

    private int remittanceMoney = 0;
    public void FieldUpdate()
    {
        if (ammountInputField.text != "")//값이 있을 때
            remittanceMoney = int.Parse(ammountInputField.text);
        else //값이 없을 때
            remittanceMoney = 0;
    }
    public void Back()
    {
        gameObject.SetActive(false);
        inOutUI.SetActive(true);
        InitField();
        remittanceMoney = 0;
    }
    public void Input(Account account)
    {
        errArr.Clear();
        if (targetInputField.text == "" && ammountInputField.text == "")
            errArr.Add("입력 정보를 확인해주세요.");
        else
        {
            if (AccountManager.instance.CheckTheID(targetInputField.text))
            {
                if (account.cash >= remittanceMoney && remittanceMoney > 0)
                {
                    account.cash -= remittanceMoney;
                    AccountManager.instance.accountList.List[targetInputField.text].accountMoney += remittanceMoney;
                    AccountManager.instance.SaveData();
                    return;
                }
                else
                {
                    errArr.Add("잔액이 부족합니다.");
                }
            }
            else
            {
                errArr.Add("대상이 없습니다.");
            }
        }
        errText.text = errArr[0];
        errorUI.SetActive(true);
    }
    public void InitField()
    {
        targetInputField.text = "";
        ammountInputField.text = "";
    }
}
