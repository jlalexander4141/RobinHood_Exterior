using UnityEngine;
using System.Collections;

public class winScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {

			Application.Quit();

		}
	
	}
}
