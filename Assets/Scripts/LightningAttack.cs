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


        mySfx.PlayOneShot(fireSfx);//대충 총 쏘는 사운드 추가하려는데 아직미완성
        //enemy.hp -= data.Damage;  //Enemy의 hp가 0이 되면 아래로 처리할 부분.
        //if(enemy.hp <=0)

        Destroy(enemy.gameObject);
    }
}
