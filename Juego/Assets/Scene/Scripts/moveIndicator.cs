using UnityEngine;
using System.Collections;

public class moveIndicator : MonoBehaviour {

	private float topeBajo;
	private float topeAlto;
	private Vector2 startPosition;
	public Vector2 changePosition;
	private GameObject player;
	private Transform posPlayer;

	private bool up = false;
	private bool goingdown = false;

	private SpriteRenderer spriteRenderer;
	public Sprite indicator;
	// Use this for initialization
	void Start () {
		topeAlto = -2.65f;
		topeBajo = -2.85f;

		/*startPosition = new Vector2 (0, -2.7f);
		transform.position = startPosition;*/
		changePosition.y = -2.75f;

		spriteRenderer = this.GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (detectPlayer.started) {
			if (spriteRenderer.sprite == null)
				spriteRenderer.sprite = indicator;
		}

		//detectar que jugador eres
		if(detectPlayer.id == 1)
			player = GameObject.Find ("Player1");		
		else if(detectPlayer.id == 2)
			player = GameObject.Find ("Player2");


		if (transform.position.y >= topeAlto || goingdown) {	//ARRIBA DEL TODO	
			up = true;
									
			if (transform.position.y <= topeBajo) { //ABAJO DEL TODO
				up = false;
				goingdown = false;
			} else if(up){ //BAJANDO
				goingdown = true;
				changePosition.y -= 0.01f;
				transform.position = changePosition;
			}

		} else if(!up) { //SUBIENDO
			changePosition.y += 0.01f;
			transform.position = changePosition;
		}


		/*
		if (transform.position.y > topeAlto  ) {
			changePosition.y -= 0.05f;
			transform.position = changePosition;
		}

		if (transform.position.y < topeBajo) {
			changePosition.y += 0.05f;
			transform.position = changePosition;
		}*/

		changePosition.x = player.transform.position.x;
		transform.position = changePosition;



		
	}

	void OnGUI(){
	//	GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), topeAlto.ToString());

	}
}
