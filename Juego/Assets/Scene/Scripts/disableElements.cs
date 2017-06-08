using UnityEngine;
using System.Collections;

public class disableElements : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if (BluetoothMenu.playing) {
			GetComponent<SpriteRenderer> ().enabled = false;
		} else {
			GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}
