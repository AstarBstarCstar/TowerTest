using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackCommand : MonoBehaviour
{
    protected float lastAttackTime = 0f;
    public abstract void Attack(Enemy enemy);
}