using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InOutUI : MonoBehaviour
{
    [SerializeField]
    private GameObject depositUI;
    [SerializeField]
    private GameObject withdrawUI;
    [SerializeField]
    private GameObject remittanceUI;

    private GameObject connectedUI;

    public void ShowConnectedUI()
    {
        gameObject.SetActive(false);
        connectedUI.SetActive(true);
    }
    public void SetDepositUI()
    {
        connectedUI = depositUI;
        ShowConnectedUI();
    }
    public void SetWithdrawUI()
    {
        connectedUI = withdrawUI;
        ShowConnectedUI();
    }
    public void SetRemittanceUI()
    {
        connectedUI = remittanceUI;
        ShowConnectedUI();
    }
}
