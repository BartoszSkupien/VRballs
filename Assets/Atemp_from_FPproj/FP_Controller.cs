using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]

public class FP_Controller : MonoBehaviour {

	CharacterController cc;

	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5.0f;
	public float viewUDrange = 60.0f;
	public float jumpSpeed = 5.0f; //7best

	float verticalVelocity = 0f;

	float rotationUD = 0f;
	// Use this for initialization
	void Start () {
		//game setup  
		Screen.lockCursor = true; //works
		// add custom cursor
		Screen.SetResolution (640, 480, true); //works

		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		CharacterController cc = GetComponent<CharacterController> ();

		//rotation
		float rotationLR = Input.GetAxis("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotationLR, 0);

		rotationUD -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		//float currentUD = Camera.main.transform.rotation.eulerAngles.x;
		//float desiredUD = currentUD - rotationUD;
		rotationUD = Mathf.Clamp (rotationUD, -viewUDrange, viewUDrange);

		Camera.main.transform.localRotation = Quaternion.Euler(rotationUD, 0, 0);



		//movement
		float forwardSpeed = Input.GetAxis ("Vertical")*movementSpeed; 
		float sideSpeed = Input.GetAxis ("Horizontal")*movementSpeed; 

		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		if (cc.isGrounded && Input.GetButtonDown ("Jump")) {
			verticalVelocity = jumpSpeed;
		}

		Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed);

		speed = transform.rotation * speed;

		//cc.SimpleMove (speed);
		cc.Move (speed * Time.deltaTime); //same speed nmo fps

	}
}
