using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountInfoText : MonoBehaviour
{
    [SerializeField]
    private Text AccountName;
    [SerializeField]
    private Text cashText;
    [SerializeField]
    private Text balanceText;
    private void Start()
    {
        AccountName.text = AccountManager.instance.curAccount.accountInfo.accountName;
    }
    void Update()
    {
        cashText.text = AccountManager.instance.curAccount.cash.ToString("#,##0");
        balanceText.text = AccountManager.instance.curAccount.accountInfo.accountMoney.ToString("#,##0");
    }
}
