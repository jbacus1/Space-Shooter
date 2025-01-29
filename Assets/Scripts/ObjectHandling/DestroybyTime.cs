using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyTime : MonoBehaviour 
{
	public float lifetime; // How long an object can be alive

	void Start ()
	{
		// Destroy an object after its lifetime
		Destroy (gameObject, lifetime);
	}
}
