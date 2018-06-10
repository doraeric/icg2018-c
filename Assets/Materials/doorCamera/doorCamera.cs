using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorCamera : MonoBehaviour {

	public Transform playerCamera;
	public Transform door;
	public Transform otherdoor; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Vector3 playerOffsetFromDoor = playerCamera.position - otherdoor.position;
		// transform.position = door.position + playerOffsetFromDoor;

		float angularDifferenceBetweenPortalRotations = Quaternion.Angle(door.rotation, otherdoor.rotation);

		Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
		Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
		transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}
