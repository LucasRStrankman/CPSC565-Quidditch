using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Forward : MonoBehaviour {
	public float thrust;
	public GameObject[] walls;
	Rigidbody body;
	Vector3 m_thrust;
	Vector3 wall1;
	Vector3 wall2;
	Vector3 wall3;
	Vector3 wall4;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
		m_thrust = new Vector3 (0, 0, thrust);
	}

	void FixedUpdate () {
		wall1 = body.transform.position - walls [0].transform.position;
		float distance = Vector3.Distance (body.transform.position, walls [0].transform.position);
		wall1 = wall1 / distance;
		wall1 = wall1 * 10;

		body.AddForce (m_thrust);
		body.AddForce (wall1);
	}
}
