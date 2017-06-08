using UnityEngine;
using System.Collections;

public class goToMenu : MonoBehaviour {

	public float timer;
	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 1) {
			if (Input.GetButtonDown ("Fire1")) {
				Bluetooth.Instance ().Stop ();
				Application.LoadLevel ("Menu");
			}	
		}
	}
}
