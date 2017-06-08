using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string name;
	private Vector2 initpos;
	private Vector2 movementpos;
	private float ratio;

	public static bool winner;

	public Sprite spritenormalp1;
	public Sprite spriteswipeattackp1;
	public Sprite spriteswipedefensep1;

	public Sprite spritenormalp2;
	public Sprite spriteswipeattackp2;
	public Sprite spriteswipedefensep2;

	private SpriteRenderer spriteRendererp1;
	private SpriteRenderer spriteRendererp2;

	public Sprite boarWood;
	public Sprite boarIron;
	public Sprite boarGold;
	public Sprite boarDiamond;
	public Sprite boarWhite;

	private float timer = 0;
	private bool run=false;

	private GameObject player1;
	private GameObject player2;

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



		spriteRendererp1 = player1.GetComponent<SpriteRenderer> ();	
		if(spriteRendererp1.sprite==null) spriteRendererp1.sprite = spritenormalp1;
		spriteRendererp2 = player2.GetComponent<SpriteRenderer> ();	
		if(spriteRendererp2.sprite==null) spriteRendererp2.sprite = spritenormalp2;

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
				spriteRendererp2.enabled = false;
			} else {
				spriteRendererp2.enabled = true;
			}

			if (detectPlayer.invisiblemine) {
				spriteRendererp1.enabled = false;
			} else {
				spriteRendererp1.enabled = true;
			}

			if (Game.current.jabato.rank == 5) {
				spritenormalp1 = boarWood;
			} else if (Game.current.jabato.rank == 4) {
				spritenormalp1 = boarIron;
			} else if (Game.current.jabato.rank == 3) {
				spritenormalp1 = boarGold;
			} else if (Game.current.jabato.rank == 2) {
				spritenormalp1 = boarDiamond;
			} else {
				spritenormalp1 = boarWhite;
			}
			if (MenuSelection.rankyours == 5) {
				spritenormalp2 = boarWood;
			} else if (MenuSelection.rankyours == 4) {
				spritenormalp2 = boarIron;
			} else if (MenuSelection.rankyours == 3) {
				spritenormalp2 = boarGold;
			} else if (MenuSelection.rankyours == 2) {
				spritenormalp2 = boarDiamond;
			} else {
				spritenormalp2 = boarWhite;
			}


			/////////// SPRITE ATAQUE
			if (detectPlayer.disabledAttack) {
				spriteRendererp1.sprite = spriteswipeattackp1;
			} else if (detectPlayer.disabledDefense) {
				spriteRendererp1.sprite = spriteswipedefensep1;
			} else {
				spriteRendererp1.sprite = spritenormalp1;
			}

			if (detectPlayer.disabledAttackyours) {
				spriteRendererp2.sprite = spriteswipeattackp2;
			} else if(detectPlayer.disabledDefenseyours){
				spriteRendererp2.sprite = spriteswipedefensep2;
			}else {
				spriteRendererp2.sprite = spritenormalp2;
			}

		}
		if (detectPlayer.id == 2) {

			if (detectPlayer.invisibleyours) {
				spriteRendererp1.enabled = false;
			} else {
				spriteRendererp1.enabled = true;
			}

			if (detectPlayer.invisiblemine) {
				spriteRendererp2.enabled = false;
			} else {
				spriteRendererp2.enabled = true;
			}

			if (Game.current.jabato.rank == 5) {
				spritenormalp2 = boarWood;
			} else if (Game.current.jabato.rank == 4) {
				spritenormalp2 = boarIron;
			} else if (Game.current.jabato.rank == 3) {
				spritenormalp2 = boarGold;
			} else if (Game.current.jabato.rank == 2) {
				spritenormalp2 = boarDiamond;
			} else {
				spritenormalp2 = boarWhite;
			}

			if (MenuSelection.rankyours == 5) {
				spritenormalp1 = boarWood;
			} else if (MenuSelection.rankyours == 4) {
				spritenormalp1 = boarIron;
			} else if (MenuSelection.rankyours == 3) {
				spritenormalp1 = boarGold;
			} else if (MenuSelection.rankyours == 2) {
				spritenormalp1 = boarDiamond;
			} else {
				spritenormalp1 = boarWhite;
			}


			/////////// SPRITE ATAQUE
			if (detectPlayer.disabledAttack) {
				spriteRendererp2.sprite = spriteswipeattackp2;
			} else if (detectPlayer.disabledDefense) {
				spriteRendererp2.sprite = spriteswipedefensep2;
			} else {
				spriteRendererp2.sprite = spritenormalp2;
			}

			if (detectPlayer.disabledAttackyours) {
				spriteRendererp1.sprite = spriteswipeattackp1;
			}  else if(detectPlayer.disabledDefenseyours){
				spriteRendererp1.sprite = spriteswipedefensep1;
			} else {
				spriteRendererp1.sprite = spritenormalp1;
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

	}
	
