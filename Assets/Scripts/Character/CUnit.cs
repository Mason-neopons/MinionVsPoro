using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUnit : MonoBehaviour
{
    public SUnitStatus sStatus;

    public int kills = 0;

    public void InitStatus(string _name, int _damage, int _attack_range, int _attack_speed, int _hp)
    {
        sStatus.name = _name;
        sStatus.damage = _damage;
        sStatus.attack_range = _attack_range;
        sStatus.attack_speed = _attack_speed;
        sStatus.hp = _hp;
    }

    public void MoveUnit(Vector3 vecTileLocation)
    {
        Vector3 movePosition = new Vector3(0.0f, 0.6f, 0.0f);
        this.transform.position = vecTileLocation + movePosition;
    }

    public void AttackUnit(CUnit cUnitEnemy)
    {
        if(cUnitEnemy.TakeDamage(sStatus.damage))
        {
            kills++;
            GameManager.Instance.money++;
        }
    }

    public bool TakeDamage(int nDamage)
    {
        sStatus.hp -= nDamage;

        if (sStatus.hp <= 0)
        {
            Dead();
            return true;
        }
        return false;
    }

    public void Dead()
    {
        Destroy(this.gameObject);
    }
}