using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AwayWall : MonoBehaviour {
	public GameObject[] walls;
	Rigidbody body;
	Vector3 m_thrust;
	BoxCollider collider;
	public float thrust;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
		collider = walls[0].GetComponent<BoxCollider> ();
		m_thrust = new Vector3 (0, 0, thrust);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void FixedUpdate () {
		Vector3 point = collider.ClosestPointOnBounds (body.transform.position);
		body.AddForce (m_thrust);
		Debug.Log (point);


	}
}

	