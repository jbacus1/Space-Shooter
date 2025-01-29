using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour 
{

	public float speed; //Speed of movement

	//Automatically moves something downward
	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
