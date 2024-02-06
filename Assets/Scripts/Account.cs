using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account
{
    public AccountInfo accountInfo;//은행에 등록되어있는 정보
    public int cash;//가지고 있는 현금
    public Account(AccountInfo accountInfo, int cash)
    {
        this.accountInfo = accountInfo;
        this.cash = cash;
    }
}
