using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riser : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        var moleholes = GameObject.FindGameObjectsWithTag("MoleHole");

        var randomHole = Random.Range(0, moleholes.Length-1);
        var characters = moleholes[randomHole];

	}
}
