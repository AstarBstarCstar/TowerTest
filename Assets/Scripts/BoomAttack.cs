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

        /*�� ��ġ�� ���󰡴� ��ź�� ������ ����*/
        Transform Firing = GetComponent<Transform>();
        lastAttackTime = Time.time;
        Instantiate(Shell, MuzzlePos);//TODO:��ź�� ���� �����ǿ��� �����Ǵ°� ������, ���� ��ġ�� ��� ���󰡰� ���� �𸣰���.
        //Debug.Log("����BOOM"); //������ ����� �������� �׽�Ʈ �ϴ� ������ �ڵ�


        ParticleSystem particleEffect = Instantiate(Effect, MuzzlePos);
        Destroy(particleEffect, 1f);


        mySfx.PlayOneShot(fireSfx);//���� �� ��� ���� �߰��Ϸ��µ� �����̿ϼ�

    }
}
