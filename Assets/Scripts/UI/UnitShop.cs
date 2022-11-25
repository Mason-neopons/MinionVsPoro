using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitShop : UI_Manager
{
    public int money = 0;

    public void Evolution(CUnit unit)
    {
        if(unit.kills >= 2 && GameManager.Instance.money >= 2)
        {
            unit.kills = 0;
            GameManager.Instance.money -= 2;
            Debug.Log("Evolution!");
        }
    }
}
