using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomAttack : AttackCommand
{
    public AudioSource      mySfx;
    public AudioClip        fireSfx;
    public Data_Turret      data;
    public Transform        MuzzlePos;
    public ParticleSystem   Effect;
    public GameObject       Shell;

    public override void Attack(Enemy enemy)
    {
        if (Time.time < lastAttackTime + data.FireRate)
            return;

        /*적 위치로 날라가는 폭탄의 프리팹 생성*/
        Transform Firing = GetComponent<Transform>();
        lastAttackTime = Time.time;
        Instantiate(Shell, MuzzlePos);//TODO:포탄이 머즐 포지션에서 생성되는건 되지만, 몬스터 위치로 어떻게 날라가게 할지 모르겠음.
        //Debug.Log("공격BOOM"); //공격이 여기로 들어오는지 테스트 하는 목적의 코드


        ParticleSystem particleEffect = Instantiate(Effect, MuzzlePos);
        Destroy(particleEffect, 1f);


        mySfx.PlayOneShot(fireSfx);//대충 총 쏘는 사운드 추가하려는데 아직미완성

    }
}
