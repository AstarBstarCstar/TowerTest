using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningAttack : AttackCommand
{
    public Data_Turret       data;
    public AudioSource       mySfx;
    public AudioClip         fireSfx;
    public Transform         MuzzlePos;
    public Transform         MonsterPos;
    public ParticleSystem    Effect;
    public override void Attack(Enemy enemy)
    {
        if (Time.time < lastAttackTime + data.FireRate)
            return;


        lastAttackTime = Time.time;

        ParticleSystem particleEffect = Instantiate(Effect, MonsterPos);
        Destroy(particleEffect, 1f);


        mySfx.PlayOneShot(fireSfx);//���� �� ��� ���� �߰��Ϸ��µ� �����̿ϼ�
        //enemy.hp -= data.Damage;  //Enemy�� hp�� 0�� �Ǹ� �Ʒ��� ó���� �κ�.
        //if(enemy.hp <=0)

        Destroy(enemy.gameObject);
    }
}
