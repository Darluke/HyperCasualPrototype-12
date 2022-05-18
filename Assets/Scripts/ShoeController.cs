using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeController : MonoBehaviour
{
	private int yMinLimit = 0, yMaxLimit = 80;
	private Quaternion currentRotation, desiredRotation, rotation;
	private float yDeg = 15, xDeg = 0.0f;
	private float currentDistance, desiredDistance = 3.0f, maxDistance = 6.0f, minDistance = 9.0f;
	private Vector3 position;
	public GameObject targetObject, camObject;
	float sensitivity = 1.25f;
	float direction;
	

	void Update()
    {
		Rotate(direction);
    }

	public void Rotate(float directionToRotate)
	{
		
		//xDeg -= Input.GetAxis("Horizontal") * sensitivity;   //keyboard input
		xDeg -= direction * sensitivity; //ui buttin input
		desiredRotation = Quaternion.Euler(0, xDeg, 0);
		rotation = Quaternion.Lerp(transform.rotation, desiredRotation, 0.05f);
		transform.rotation = desiredRotation;
		

	}

	public void SetRotationDirection(float direction)
    {
		this.direction = direction;
    }

	private static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp(angle, min, max);
	}
}
