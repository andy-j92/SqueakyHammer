using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public float startWait;
    public float spawnWait;
    public int enemyCount;
    public GameObject[] holes;
    public GameObject[] enemies;
    private MoleHole[] _moleHole;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                GameObject hole = holes[Random.Range(0, holes.Length)];
                MoleHole moleHole = new MoleHole(hole, true);
                while ()
                {

                }

                GameObject enemy = enemies[Random.Range(0, enemies.Length)];
                Vector3 spawnPosition = hole.transform.position;
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(enemy, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(Random.Range(0, spawnWait));
            }
        }
    }
}

class MoleHole
{
    private GameObject _hole;
    private bool _isActive;

    public MoleHole(GameObject hole, bool isActive)
    {
        _hole = hole;
        _isActive = isActive;
    }

    public bool GetIsActive()
    {
        return _isActive;
    }

    public void SetIsActive(bool active)
    {
        _isActive = active;
    }
}
