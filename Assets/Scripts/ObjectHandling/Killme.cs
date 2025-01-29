using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killme : MonoBehaviour {

	public int health; // Number of hits an object can take

	void Start () {
		// Initialize health
		health = 2;
	} 

	public void hit () {
		// Decrement health, destroying object if health is 0
		health -= 1;
		if (health <= 0) {
			Destroy (gameObject);
		}
	}
}
