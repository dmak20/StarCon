using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	void OnGUI() {

		if (GUI.Button (new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 30, 130, 60), "Cardboard Mode")) {
			PlayerPrefs.SetInt ("cardboard", 1);
			Application.LoadLevel ("mainGame");
		}

		if (GUI.Button (new Rect((Screen.width / 2) + 20, (Screen.height / 2) - 30, 130, 60), "Normal Mode")) {
			PlayerPrefs.SetInt ("cardboard", 0);
			Application.LoadLevel ("mainGame");
		}

	}
}
