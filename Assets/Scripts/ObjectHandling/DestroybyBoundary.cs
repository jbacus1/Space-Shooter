using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyBoundary : MonoBehaviour 
{
	// Destroy an object if it exits a boundary
	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}
}
