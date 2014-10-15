using UnityEngine;
using System.Collections;

public class DamageFadeInOut : MonoBehaviour {

	public float fadeSpeed = 1.5f;

	private bool starting = true;


	void Awake()
	{
		guiTexture.pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);
		//StartScene ();

	}

	void Update()
	{
		//if (sceneStarting)
		//	StartScene ();
	}

	public void DamageFade()
	{
		print ("Damage fade starting...");
		guiTexture.enabled = true;
		guiTexture.color = new Color (225, 0, 0, 0.55f);
		StartCoroutine (FadeToClear ());
	}

	IEnumerator FadeToClear()
	{
		while (guiTexture.color != Color.clear) {
			guiTexture.color = Color.Lerp (guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
			yield return null;
		}

		guiTexture.color = Color.clear;
		guiTexture.enabled = false;
	}

	IEnumerator FadeToColor()
	{
		guiTexture.color = Color.Lerp (guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);

		yield return null;

	}

	void StartScene()
	{
		FadeToClear ();

		if (guiTexture.color.a <= 0.05f) 
		{
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
			//sceneStarting = false;
		}
	}

	public void EndScene()
	{
		guiTexture.enabled = true;
		//FadeToBlack ();

		if (guiTexture.color.a >= 0.95f) 
		{
			// end effect
		}

	}
}
