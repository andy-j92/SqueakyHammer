using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public float startWait;
    public float spawnWait;
    public int enemyCount;
    public GameObject[] holes;
    public GameObject[] enemies;

    public GUIText scoreText;
    public GUIText gameOverText;

    private List<MoleHole> _moleHoles = new List<MoleHole>();
    private List<MoleHole> _activeHoles = new List<MoleHole>();
    private int score;
    private bool gameOver;
    private float playTime;

	// Use this for initialization
	void Start () {

        score = 0;
        UpdateScore();
        for (int i = 0; i < holes.Length; i++)
        {
            _moleHoles.Add(new MoleHole(holes[i], null, false));
        }
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnWaitManager());
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
                if (_activeHoles.Count == 9)
                {
                    yield return new WaitForSeconds(0.1f);
                    Debug.Log("HIT");
                }
                var hole = GetInActiveHole();

                GameObject enemy = enemies[Random.Range(0, enemies.Length)];
                Quaternion spawnRotation = Quaternion.identity;
                Vector3 spawnPosition = hole.GetHole().transform.position;

                if(enemy.tag == "SpecialEnemy")
                    spawnPosition.y -= 0.65f;
                else
                    spawnPosition.y -= 1.1f;

                hole.enemy = Instantiate(enemy, spawnPosition, spawnRotation);
                hole.isActive = true;
                _activeHoles.Add(hole);

                yield return new WaitForSeconds(Random.Range(0, spawnWait));
            }

            if (gameOver)
            {
                gameOverText.text = "GAME OVER";
            }
        }
    }


    IEnumerator SpawnWaitManager()
    {
        while(spawnWait > 0.0f)
        {
            yield return new WaitForSeconds(5);
            spawnWait -= 0.25f;
        }


    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
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
