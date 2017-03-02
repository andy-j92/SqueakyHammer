using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject[] enemies;

	// Use this for initialization
	public void Start ()
    {
        SpawnWaves();

    }
	
	void SpawnWaves()
    {
        GameObject enemy = enemies[Random.Range(0, enemies.Length)];
        Vector3 spawnPosition = gameObject.transform.position;
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(enemy, spawnPosition, spawnRotation);
    }
}
