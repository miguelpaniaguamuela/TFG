using UnityEngine;
using System.Collections;

public class popupAppear : MonoBehaviour {

	public float speed;
	private Vector2 startPosition;
	private Vector2 initial;
	private bool appear = false;

	private float timer = 0;
	public bool timeStarted = false;
	private bool up = false;
	private bool goingdown = false;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		initial = startPosition;
	}

	
	// Update is called once per frame
	void Update () {
		if (appear) {
			if (transform.position.y >= -3.3 || goingdown) {	//ARRIBA DEL TODO	
				up = true;
				timer += Time.deltaTime;
				if (timer >= 2) {					
					if (transform.position.y <= -6.61) { //ABAJO DEL TODO
						up = false;
						appear = false;
						goingdown = false;
						timer = 0;
						BluetoothMenu.Result = "Success";
					} else if(up){ //BAJANDO
						goingdown = true;
						startPosition.y -= speed; 
						transform.position = startPosition;
					}
				}

			} else if(!up) { //SUBIENDO
				startPosition.y += speed; 
				transform.position = startPosition;
			}
		}
	}

	public void ShowMessage(){
		appear = true;
		//BluetoothMenu.Result = "Exit";
	}
}
