using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account
{
    public AccountInfo accountInfo;//���࿡ ��ϵǾ��ִ� ����
    public int cash;//������ �ִ� ����
    public Account(AccountInfo accountInfo, int cash)
    {
        this.accountInfo = accountInfo;
        this.cash = cash;
    }
}
