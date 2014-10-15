using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour {
	public GameObject normalCam;
	public GameObject cardboardCam;
	public GameObject turret;
	public GameObject enemySpawner;
	public GUIText screenText;
	public GUIText scoreText;

	private bool start = true;
	private int level = 1;
	private int score = 0;
	
	public enum GameState {
		intro,
		playing,
		paused,
		death,
		restart
	};

	public GameState state = GameState.intro;

	void Awake() {
		Debug.Log ("Running mode script");

		if (PlayerPrefs.GetInt ("cardboard") == 0) {
			Debug.Log ("Cardboard Off");
			// Set the camera system to use "MinimalSensorCamera"
			normalCam.SetActive(true);
			cardboardCam.SetActive(false);

			// Tell the TurretPivot which transform to follow
			SmoothFollow_Rotation sft = turret.GetComponent<SmoothFollow_Rotation>();
			sft.target = normalCam.transform;
		} else {
			Debug.Log ("Cardboard On");
			// Set the camera system to use "Dive_Camera"
			normalCam.SetActive(false);
			cardboardCam.SetActive(true);

			// Tell the TurretPivot which transform to follow
			SmoothFollow_Rotation sft = turret.GetComponent<SmoothFollow_Rotation>();
			sft.target = cardboardCam.transform;
		}
	}

	public void addScore(int inScore)
	{
		score += inScore;
		scoreText.text = score.ToString ();
	}

	void Update() {
		// Do something depending on our game state -- just using a plain old switch here
		//print (state.ToString ());
		switch (state) {
		case GameState.intro:
			// play intro sequence
			// right now just display intro text for a start
			if (start) {
				//print ("inside intro case");
				StartCoroutine(IntroSequence());
				start = false;
			}
			break;

		case GameState.playing:
			if (start)
			{
				StartCoroutine(Playing ());

				start = false;
			}
			break;
		case GameState.death:

			break;

		case GameState.restart:

			break;

		// user pressed the pause button
		case GameState.paused:
			Time.timeScale = 0;
			break;
		}

	}

	IEnumerator IntroSequence()
	{
		//print ("running intro");
		screenText.text = "Level " + level + "!";
		screenText.enabled = true;

		yield return new WaitForSeconds (3f);

		screenText.text = "Go!";

		yield return new WaitForSeconds (2f);

		screenText.enabled = false;
		// switch gamestate to playing
		state = GameState.playing;
		start = true;
	}

	IEnumerator Playing()
	{

		while (GameObject.FindGameObjectsWithTag ("Enemy").Length > 0)
		{
			yield return new WaitForSeconds(1);
		}

		level++;
		state = GameState.intro;
		Instantiate (enemySpawner, Vector3.zero, Quaternion.identity);



		yield return new WaitForSeconds(0.1f);
	}
}
