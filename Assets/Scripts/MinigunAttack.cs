using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunAttack : AttackCommand
{
    public AudioSource      mySfx;      //사운드의소스          
    public AudioClip        fireSfx;    //사운드클립(사운드)
    public Data_Turret      data;       
    public Transform        MuzzlePos;
    public ParticleSystem   Effect;

    public bool             playAura;
    public float            particletime;
    public override void Attack(Enemy enemy)
    {
        Debug.Log($"{data.FireRate}, {Time.time}, {lastAttackTime}");   //$ "{원하는변수},{원하는변수}" 사용하면 원하는 포맷대로 디버그로그 출력됨.

        if (Time.time < lastAttackTime + data.FireRate)
            return;

        lastAttackTime = Time.time;
        
        Debug.Log("ParticleEffect");
        ParticleSystem particleEffect = Instantiate(Effect, MuzzlePos);
        Destroy(particleEffect, 1f);


        mySfx.PlayOneShot(fireSfx);//대충 총 쏘는 사운드 추가하려는데 아직미완성
        //enemy.hp -= data.Damage;  //Enemy의 hp가 0이 되면 아래로 처리할 부분.
        //if(enemy.hp <=0)
        Destroy(enemy.gameObject);
    }
}

//lastAttackTime = Time.time;
//Instantiate(Effect, MuzzlePos);
//particletime += Time.deltaTime;
//if(particletime<=1)
//{
//    Destroy(Effect);//TODO:하위 프리팹 클론을 지우고 싶은데 이렇게 하면 안됨.
//    Debug.Log("as");
//    particletime = 0;
//} 하다 망한것들 