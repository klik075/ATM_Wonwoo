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
        if (ammountInputField.text != "")//���� ���� ��
            remittanceMoney = int.Parse(ammountInputField.text);
        else //���� ���� ��
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
            errArr.Add("�Է� ������ Ȯ�����ּ���.");
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
                    errArr.Add("�ܾ��� �����մϴ�.");
                }
            }
            else
            {
                errArr.Add("����� �����ϴ�.");
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
