using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

	private Transform target;
	private int wavepointIndex = 0;

	private void Start ()
	{
		target = WaveManager.instance.points[0];
	}

	private void Update ()
	{
        Move();
	}

    private void Move()
    {
        Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}
    }

	private void GetNextWaypoint()
	{
		if (wavepointIndex >= WaveManager.instance.points.Length - 1)
		{
			Destroy(gameObject);
			return;
		}

		wavepointIndex++;
		target = WaveManager.instance.points[wavepointIndex];
	}
}
