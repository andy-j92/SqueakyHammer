using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour
{
    public GameObject explosion;
    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(Instantiate(explosion, transform.position, transform.rotation), 2.0f);
            Destroy(gameObject);
            gameController.AddScore(scoreValue);
        }
    }
}
