using UnityEngine;
using System.Collections;

public class RightJustifyGUITexture : MonoBehaviour {
	public GUITexture joystick;

	void Update()
	{
		/*joystick.pixelInset = new Rect ((Screen.width - 120) - joystick.pixelInset.x,
		                                joystick.pixelInset.y,
		                                joystick.pixelInset.width,
		                                joystick.pixelInset.height);*/
		float px = 0.75f - ((Screen.width / 4) / Screen.width);
		float py = ((Screen.height / 4) / Screen.height);

		transform.position = new Vector3(px, py, transform.position.z);
	}


}
