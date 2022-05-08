using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{    
    private Enemy               m_Target;//적 클래스가 완성되면 그 위치로 포탑 대가리 회전할 것
    public Data_Turret          data;//터렛의 데이터를 받아오는 변수

    [Header("General")]
    public Transform            rotatePos;//회전위치
    public Transform            muzzlePos;//파티클시스템 위치 잡아주는거

    public FindTargetStrategy   findTargetStrategy;
    public AttackCommand        attackCommand;

    private void Update() 
    {
        FindTarget();
        Shoot();
    }

    private void FindTarget()
    {
        m_Target = findTargetStrategy.FindTarget();
    }

    private void Shoot()
    {
        if (null == m_Target)
            return;
        
        attackCommand.Attack(m_Target);
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, data.Range);
    }
}
