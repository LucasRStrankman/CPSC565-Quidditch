using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnitchFlight : MonoBehaviour
{
	public float speed = 1.5f;
	public float rotateSpeed = 5.0f;
	public float minX = 0f;
	public float maxX = 500f;
	public float minY = 5;
	public float maxY = 100f;
	public float minZ = 0f;
	public float maxZ = 500f;

	Vector3 newPosition;

	void Start ()
	{
		PositionChange();
	}

	void PositionChange()
	{
		newPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY,maxY), Random.Range(minZ, maxZ));
	}

	void Update ()
	{
		if(Vector3.Distance(transform.position, newPosition) < 1)
			PositionChange();

		transform.position=Vector3.Lerp(transform.position,newPosition,Time.deltaTime*speed);

		LookAt2D(newPosition);
	}

	void LookAt2D(Vector3 lookAtPosition)
	{
		float distanceX = lookAtPosition.x - transform.position.x;
		float distanceY = lookAtPosition.y - transform.position.y;
		float angle = Mathf.Atan2(distanceX, distanceY) * Mathf.Rad2Deg;

		Quaternion endRotation = Quaternion.AngleAxis(angle, Vector3.back);
		transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, Time.deltaTime * rotateSpeed);
	}
}
