using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {

	public string name;
	private Vector2 initpos;
	private Vector2 movementpos;
	private float ratio;

	public static bool winner;
	private float timer = 0;
	private bool run=false;

	private GameObject player1;
	private GameObject player2;

	private Animator animatorp1;
	private Animator animatorp2;

	private GameObject detector;

	// Use this for initialization
	void Start () {
		initpos = transform.position;
		movementpos = initpos;
		ratio = 0.175f; //distancia por pulso
		winner = false;
		timer = 0;
		run = false;
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
		detector = GameObject.Find ("Detector");

		animatorp1 = player1.GetComponent<Animator> ();
		animatorp2 = player2.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(run){
			timer += Time.deltaTime;
			if(timer>=0.2f){
				Application.LoadLevel ("ResultBattle");
			}
		}

		if (detectPlayer.id == 1) {
			if (detectPlayer.invisibleyours) {
				//spriteRendererp2.enabled = false;
			} else {
				//spriteRendererp2.enabled = true;
			}

			if (detectPlayer.invisiblemine) {
			//	spriteRendererp1.enabled = false;
			} else {
			//	spriteRendererp1.enabled = true;
			}

			/////////// SPRITE ATAQUE
			if (detectPlayer.disabledAttack) {
				animatorp1.SetBool ("swipe", true);
			} else if (detectPlayer.disabledDefense) {
				animatorp1.SetBool ("defense", true);
			} else {
				animatorp1.SetBool ("swipe", false);
				animatorp1.SetBool ("defense", false);
				animatorp1.SetBool ("tap", false);
			}

			if (detectPlayer.disabledAttackyours) {
				animatorp2.SetBool ("swipe", true);
			} else if(detectPlayer.disabledDefenseyours){
				animatorp2.SetBool ("defense", true);
			}else {
				animatorp2.SetBool ("swipe", false);
				animatorp2.SetBool ("defense", false);
				animatorp2.SetBool ("tap", false);
			}

		}
		if (detectPlayer.id == 2) {
			if (detectPlayer.invisibleyours) {
				//spriteRendererp1.enabled = false;
			} else {
				//spriteRendererp1.enabled = true;
			}

			if (detectPlayer.invisiblemine) {
				//spriteRendererp2.enabled = false;
			} else {
				//spriteRendererp2.enabled = true;
			}

			/////////// SPRITE ATAQUE
			if (detectPlayer.disabledAttack) {
				animatorp2.SetBool ("swipe", true);
			} else if (detectPlayer.disabledDefense) {
				animatorp2.SetBool ("defense", true);
			} else {
				animatorp2.SetBool ("swipe", false);
				animatorp2.SetBool ("defense", false);
				animatorp2.SetBool ("tap", false);
			}

			if (detectPlayer.disabledAttackyours) {
				animatorp1.SetBool ("swipe", true);
			}  else if(detectPlayer.disabledDefenseyours){
				animatorp2.SetBool ("defense", true);
			} else {
				animatorp1.SetBool ("swipe", false);
				animatorp1.SetBool ("defense", false);
				animatorp1.SetBool ("tap", false);
			}		
		}
	}

	void OnGUI(){
		//POSITIVO HACIA DERECHA
		if (detectPlayer.id == 1) {
			if (movementpos.x > 7.8f) { //P1 GANA
				winner = true;
				//Application.LoadLevel ("ResultBattle");
				run = true;
				/*if(timer>=0.5f){
					Application.LoadLevel ("ResultBattle");
				}*/
				//if() Application.LoadLevel ("ResultBattle");
			} /*else if (movementpos.x < -7.4f) {
				Application.LoadLevel ("ResultBattle");
			}*/

			movementpos.x = (detectPlayer.pulsos-detectPlayer.pulsosyours)*ratio + initpos.x;
			transform.position = movementpos;
			GUIStyle mypeopleStyle = new GUIStyle ();
			//mypeopleStyle.fontSize = 50;
			mypeopleStyle.fontSize = (int)(Screen.width*0.04629);
			mypeopleStyle.normal.textColor = Color.white;
			GUI.Label (new Rect (Screen.width / 1.5f, (Screen.height / 6f)+600, Screen.width / 6, Screen.height / 8), (detectPlayer.pulsosyours-detectPlayer.pulsos).ToString(), mypeopleStyle);

		}//POSITIVO HACIA IZQ
		else if(detectPlayer.id == 2){
			if (movementpos.x < -7.8f) { //P2 GANA
				winner = true;
				run = true;
				/*if(timer>=0.5f){
					Application.LoadLevel ("ResultBattle");
				}*/
				//Application.LoadLevel ("ResultBattle");
			}/*else if (movementpos.x > 7.4f) {
				Application.LoadLevel ("ResultBattle");
			}*/
			movementpos.x = initpos.x - (detectPlayer.pulsos - detectPlayer.pulsosyours)*ratio;
			transform.position = movementpos;
			GUIStyle mypeopleStyle = new GUIStyle ();
			//mypeopleStyle.fontSize = 50;
			mypeopleStyle.fontSize = (int)(Screen.width*0.04629);
			mypeopleStyle.normal.textColor = Color.white;
			GUI.Label (new Rect (Screen.width / 1.5f, (Screen.height / 6f)+600, Screen.width / 6, Screen.height / 8), (detectPlayer.pulsosyours-detectPlayer.pulsos).ToString(), mypeopleStyle);
		}
	}
	//HABILIDAD1
	public void habilityRotate(){
		if (detectPlayer.id == 1) {
			detectPlayer.id = 2;
		} else {
			detectPlayer.id = 1;
		}
	}

	public void tappingAttack(){
		if (detectPlayer.id == 1) {
			animatorp1.SetBool ("tap", true);
		} else {
			animatorp2.SetBool ("tap", true);
		}
	}
	public void tappingAttackYours(){
		if (detectPlayer.id == 1) {
			animatorp2.SetBool ("tap", true);
			//animatorp1.SetBool ("tap", false);
		} else {
			animatorp1.SetBool ("tap", true);
		}

	}

	public void stopTappingAttack(){
		
		if (detectPlayer.id == 1) {			
			animatorp1.SetBool ("tap", false);
			detector.GetComponent<detectPlayer> ().endTapYours ();
		} else {
			animatorp2.SetBool ("tap", false);
			detector.GetComponent<detectPlayer> ().endTapYours ();
		}

	}

	public void stopTappingAttackYours(){
		detectPlayer.transitioning = false;
		if (detectPlayer.id == 1) {			
			animatorp2.SetBool ("tap", false);
		} else {
			animatorp1.SetBool ("tap", false);
		}
	}


}
