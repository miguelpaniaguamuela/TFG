using UnityEngine;
using System.Collections;

public class movingClouds : MonoBehaviour {

	public float speedX;
	public float initposX;

	private Vector2 initial;
	private Vector2 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		initial = startPosition;
	
	}
	
	// Update is called once per frame
	void Update () {
		//si estamos jugando
		if (BluetoothMenu.playing) {
			GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (transform.position.x <= -7) {
			float posY = Random.Range (0.65f, 3.9f);
			startPosition.x = initposX;	
			startPosition.y = posY;
			transform.position = startPosition;
		}
		startPosition.x -= speedX; 
		transform.position = startPosition;
	
	}
}
