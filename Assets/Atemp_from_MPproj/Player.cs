using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	//settings
	public float speed = 10f;
		
	// Update is called once per frame
	void Update () {
		//InputMovement(); 
		//synchro
		if(GetComponent<NetworkView>().isMine) {
			InputMovement(); 	
		}
	}

	void InputMovement() {
		if (Input.GetKey(KeyCode.W))
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.forward * speed * Time.deltaTime);
		if (Input.GetKey(KeyCode.S))
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.forward * speed * Time.deltaTime);
		if (Input.GetKey(KeyCode.A))
			GetComponent<Rigidbody>().MovePosition (GetComponent<Rigidbody>().position + Vector3.left * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.D))
			GetComponent<Rigidbody>().MovePosition (GetComponent<Rigidbody>().position + Vector3.right * speed * Time.deltaTime);		
		if (Input.GetKey(KeyCode.Space))
			GetComponent<Rigidbody>().MovePosition (GetComponent<Rigidbody>().position + Vector3.up * speed * Time.deltaTime);					
	}

	/*
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		Debug.Log ("my synchro, data in/out");
		Vector3 syncPosition = Vector3.zero;
		if (stream.isWriting) {
			syncPosition = (GetComponent<Rigidbody>().position);
			stream.Serialize (ref syncPosition);
		} else {
			stream.Serialize (ref syncPosition);
			(GetComponent<Rigidbody>().position) = syncPosition;
		}
	}
	*/
}


