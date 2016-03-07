using UnityEngine;
using System.Collections;

public class mousePointer : MonoBehaviour {


	public Texture2D cursorImage;

	private int cursorWidth = 32;
	private int cursorHeight = 32;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.DrawTexture (new Rect (Input.mousePosition.x, Screen.height - Input.mousePosition.y, cursorWidth, cursorHeight), cursorImage);
	}
}
