using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public float startWait;
    public float spawnWait;
    public int enemyCount;
    public GameObject[] holes;
    public GameObject[] enemies;

    private List<MoleHole> _moleHoles;
    private List<MoleHole> _activeHoles = new List<MoleHole>();

	// Use this for initialization
	void Start () {
        _moleHoles = new List<MoleHole>();
        for (int i = 0; i < holes.Length; i++)
        {
            _moleHoles.Add(new MoleHole(holes[i], null, false));
        }
        StartCoroutine(SpawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < _activeHoles.Count; i++)
        {
            if(_activeHoles[i].enemy == null)
            {
                _activeHoles[i].isActive = false;
                _activeHoles.Remove(_activeHoles[i]);
            }
        }
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                var hole = GetInActiveHole();

                GameObject enemy = enemies[Random.Range(0, enemies.Length)];
                Quaternion spawnRotation = Quaternion.identity;
                Vector3 spawnPosition = hole.GetHole().transform.position;
                spawnPosition.y -= 1.1f;

                hole.enemy = Instantiate(enemy, spawnPosition, spawnRotation);
                hole.isActive = true;
                _activeHoles.Add(hole);

                yield return new WaitForSeconds(Random.Range(0, spawnWait));
            }
        }
    }

    MoleHole GetInActiveHole()
    {
        var hole = _moleHoles[Random.Range(0, holes.Length)];
        if (hole.isActive)
        {
            while (true)
            {
                hole = _moleHoles[Random.Range(0, holes.Length)];
                if (hole.isActive == false)
                    break;
            }
        }
        return hole;
    }
}

class MoleHole
{
    private GameObject _hole;
    public GameObject enemy;
    public bool isActive;

    public MoleHole(GameObject hole, GameObject enemy, bool isActive)
    {
        _hole = hole;
        this.enemy = enemy;
        this.isActive = isActive;
    }

    public GameObject GetHole()
    {
        return _hole;
    }

    public void SpawnEnemy()
    {
        EnemyController ec = new EnemyController();
        ec.Start();
    }
}
