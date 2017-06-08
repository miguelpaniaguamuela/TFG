using UnityEngine;
using System.Collections;

public class disableOpacity : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (detectPlayer.started) {
			GetComponent<SpriteRenderer> ().enabled = false;
		} else {
			GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}
