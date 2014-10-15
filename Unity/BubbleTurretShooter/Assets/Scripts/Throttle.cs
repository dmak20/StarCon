using UnityEngine;
using System.Collections;

public class Throttle : MonoBehaviour {

	GUITexture gui;

	// Use this for initialization
	void Start () {
		gui = GetComponent<GUITexture> ();
	}
	
	// Update is called once per frame
	void Update () {

		// get the current mouse/finger position, check if we hit our texture
		if (gui.HitTest (Input.mousePosition) && Input.GetButton ("Fire1")) {
			//print (Input.mousePosition.ToString ());
			// move our gui element to the mouse position
			transform.position = new Vector3(transform.position.x,
			                                 Mathf.Clamp((Input.mousePosition.y / Screen.height) - ((gui.pixelInset.height / 2) / Screen.height), 0.01f, 0.2f),
			                                 0f);
			//gui.pixelInset = new Rect(gui.pixelInset.x, Input.mousePosition.y,
			//                          gui.pixelInset.width, gui.pixelInset.height);
			/*gui.pixelInset.x = Input.mousePosition.x;
			gui.pixelInset.y = Input.mousePosition.y;*/
		}
	
	}
}
