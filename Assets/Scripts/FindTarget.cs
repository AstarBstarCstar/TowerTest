using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FindTargetStrategy : MonoBehaviour
{
    public Turret turret;
    public LayerMask mask;

    public abstract Enemy FindTarget();
}
