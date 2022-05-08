using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance { get; private set; }

    public GameObject waypoints;
    public Transform[] points;

    public Enemy enemyPrefab;
	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;

	private int waveIndex = 0;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        SetWayPoints();
    }

	private void Update ()
	{
		Spawn();
	}

    private void Spawn()
    {
        if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
		}

		countdown -= Time.deltaTime;
    }

	IEnumerator SpawnWave ()
	{
		waveIndex++;

		for (int i = 0; i < waveIndex; i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}
	}

	private void SpawnEnemy ()
	{
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}

    private void SetWayPoints()
    {
        points = new Transform[waypoints.transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = waypoints.transform.GetChild(i);
        }
    }
}
