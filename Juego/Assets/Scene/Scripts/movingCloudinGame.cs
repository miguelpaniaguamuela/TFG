using UnityEngine;
using System.Collections;

public class movingCloudinGame : MonoBehaviour {

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
		if (detectPlayer.started) {
			if (transform.position.x <= -14) {
				float posY = Random.Range (1.4f, 3.8f);
				startPosition.x = initposX;	
				startPosition.y = posY;
				transform.position = startPosition;
			}
			startPosition.x -= speedX; 
			transform.position = startPosition;
		}
	}
}
