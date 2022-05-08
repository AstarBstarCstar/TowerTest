using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFindTarget : FindTargetStrategy
{
    public override Enemy FindTarget()
    {
        Collider[] targets = Physics.OverlapSphere(turret.transform.position, turret.data.Range, mask);

        if (targets.Length <= 0)
            return null;
        else
        {
            RotateHead(targets[0].transform);
            return targets[0].GetComponent<Enemy>();
        }
    }

    private void RotateHead(Transform target)
    {
        Transform headTransform = turret.rotatePos;
        headTransform.LookAt(target.position);
    }
}
