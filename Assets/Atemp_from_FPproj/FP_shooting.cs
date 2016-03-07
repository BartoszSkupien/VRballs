using UnityEngine;
using System.Collections;

public class FP_shooting : MonoBehaviour {

	public GameObject bullet_prefab;
	public float bulletSpeed = 100f;

	// Use this for initialization
	void Start () {
		Camera cam = Camera.main;
		cam.transform.Translate(0f, 1f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		
		if ( Input.GetButtonDown ("Fire1") ) { 
			
			Camera cam = Camera.main;

			//Camera camUpdated;

			//move down shootpoint
			//camUpdated.transform.position = cam.transform.position;
			//camUpdated.transform.position.y = camUpdated.transform.position.y-3f;

			//Camera camUpdated = new Camera();
			//camUpdated.y = camUpdated.y - 1f;
			//cam += camUpdated;

			//cam.transform.Translate (0, 1f, 0);
			//Vector3 newPosition = cam.transform.position.y;
			//newPosition.y += 1f;
			//cam.transform.position = newPosition;

			//camUpdated = cam.transform.position + camcam;

			GameObject thebullet = (GameObject)Instantiate(bullet_prefab, cam.transform.position, cam.transform.rotation);
			//GameObject thebullet = (GameObject)Instantiate(bullet_prefab, cam.transform.position + cam.transform.position, cam.transform.rotation);
			//GameObject thebullet = (GameObject)Instantiate(bullet_prefab, camUpdated.transform.position, cam.transform.rotation);

			//thebullet.rigidbody.AddForce( cam.transform.forward * bulletSpeed, ForceMode.Impulse );
			thebullet.GetComponent<Rigidbody>().AddForce( cam.transform.forward * bulletSpeed, ForceMode.Impulse );
		}
	}
}
