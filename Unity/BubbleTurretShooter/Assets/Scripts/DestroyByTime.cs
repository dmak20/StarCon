using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float timeToDie = 3f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, timeToDie);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
