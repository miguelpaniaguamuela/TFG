using UnityEngine;
using System.Collections;

public class profile : MonoBehaviour {

	public Texture bg;
	public Texture bg_profile;
	public Texture bg_profile2;

	public Texture backBtn;
	public Texture plusBtn;
	public Texture starBtn;
	public Texture upgradeBtn;
	public Texture medalBtnwood;
	public Texture medalBtniron;
	public Texture medalBtngold;
	public Texture medalBtndiamond;
	public Texture medalBtnwhite;
	public Texture javaticityprob100;
	public Texture javaticityprob80;
	public Texture javaticityprob60;
	public Texture javaticityprob40;
	public Texture javaticityprob20;

	//TEXTURAS JABALIES
	public Texture boarWood;
	public Texture boarIron;
	public Texture boarGold;
	public Texture boarDiamond;
	public Texture boarWhite;

	public Font labelfont;
	public Font labelfontnormal;
	private bool showlabel;
	private bool star;
	private int costupgrade;

	// Use this for initialization
	void Start () {
		showlabel = true;
		star = false;
		costupgrade = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{

		GUIStyle mypeopleStyle = new GUIStyle ();
		mypeopleStyle.fontSize = (int)(Screen.width * 0.04629);
		mypeopleStyle.normal.textColor = Color.white;
		mypeopleStyle.font = labelfont;

		GUIStyle mypeopleStyle2 = new GUIStyle ();
		mypeopleStyle2.fontSize = (int)(Screen.width * 0.08629);
		mypeopleStyle2.normal.textColor = Color.white;
		mypeopleStyle2.font = labelfont;
		//mypeopleStyle.fontStyle = FontStyle.Bold;

		GUIStyle mypeopleStyle3 = new GUIStyle ();
		mypeopleStyle3.fontSize = (int)(Screen.width * 0.04629);
		mypeopleStyle3.normal.textColor = Color.black;
		mypeopleStyle3.font = labelfont;

		GUIStyle mypeopleStylenormal = new GUIStyle ();
		mypeopleStylenormal.fontSize = (int)(Screen.width * 0.04);
		mypeopleStylenormal.normal.textColor = Color.white;
		mypeopleStylenormal.font = labelfontnormal;

		//////////////////////////////////////////////PERFIL-1\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
	if(!star){


		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), bg);

		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), bg_profile);

		// DIBUJADO DE JABALIES Y MEDALLAS
		if (Game.current.jabato.rank == 5) {
			GUI.DrawTexture (new Rect (Screen.width / 7.28f, Screen.height / 21.3f, Screen.width / 1.28f, Screen.height / 3.75f), boarWood);
			GUI.DrawTexture (new Rect (Screen.width / 1.2f, Screen.height / 3.1f, Screen.width / 10, Screen.height / 12), medalBtnwood);
		} else if (Game.current.jabato.rank == 4) {
			GUI.DrawTexture (new Rect (Screen.width / 7.28f, Screen.height / 21.3f, Screen.width / 1.28f, Screen.height / 3.75f), boarIron);
			GUI.DrawTexture (new Rect (Screen.width / 1.2f, Screen.height / 3.1f, Screen.width / 10, Screen.height / 12), medalBtniron);
		} else if (Game.current.jabato.rank == 3) {
			GUI.DrawTexture (new Rect (Screen.width / 7.28f, Screen.height / 21.3f, Screen.width / 1.28f, Screen.height / 3.75f), boarGold);
			GUI.DrawTexture (new Rect (Screen.width / 1.2f, Screen.height / 3.1f, Screen.width / 10, Screen.height / 12), medalBtngold);
		} else if (Game.current.jabato.rank == 2) {
			GUI.DrawTexture (new Rect (Screen.width / 7.28f, Screen.height / 21.3f, Screen.width / 1.28f, Screen.height / 3.75f), boarDiamond);
			GUI.DrawTexture (new Rect (Screen.width / 1.2f, Screen.height / 3.1f, Screen.width / 10, Screen.height / 12), medalBtndiamond);
		} else {
				GUI.DrawTexture (new Rect (Screen.width / 7.28f, Screen.height / 21.3f, Screen.width / 1.28f, Screen.height / 3.75f), boarWhite);
			GUI.DrawTexture (new Rect (Screen.width / 1.2f, Screen.height / 3.1f, Screen.width / 10, Screen.height / 12), medalBtnwhite);
		}

		if (Game.current.jabato.jabaticity == 99) {
			GUI.DrawTexture (new Rect (Screen.width / 3.9f, Screen.height / 2.1f, Screen.width / 1.8825f, Screen.height / 16), javaticityprob100);
		} else if (Game.current.jabato.jabaticity == 95) {
			GUI.DrawTexture (new Rect (Screen.width / 3.9f, Screen.height / 2.1f, Screen.width / 1.8825f, Screen.height / 16), javaticityprob80);
		} else if (Game.current.jabato.jabaticity == 85) {
			GUI.DrawTexture (new Rect (Screen.width / 3.9f, Screen.height / 2.1f, Screen.width / 1.8825f, Screen.height / 16), javaticityprob60);
		} else if (Game.current.jabato.jabaticity == 75) {
			GUI.DrawTexture (new Rect (Screen.width / 3.9f, Screen.height / 2.1f, Screen.width / 1.8825f, Screen.height / 16), javaticityprob40);
		} else {
			GUI.DrawTexture (new Rect (Screen.width / 3.9f, Screen.height / 2.1f, Screen.width / 1.8825f, Screen.height / 16), javaticityprob20);
		}
		//////////////////////////////////////////////TEXTFIELD\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		GUI.SetNextControlName ("username");
		Game.current.jabato.name = GUI.TextField (new Rect (Screen.width / 3, Screen.height / 2.35f, Screen.width / 2, Screen.height / 9), Game.current.jabato.name, 10, mypeopleStyle3);
		if (GUI.GetNameOfFocusedControl () == "username") {
			showlabel = false;
		}
		if (showlabel)
			GUI.Label (new Rect (Screen.width / 3, Screen.height / 2.35f, Screen.width / 2, Screen.height / 2), Game.current.jabato.name, mypeopleStyle3);


		GUI.Label (new Rect (Screen.width / 2.75f, Screen.height / 1.7f, Screen.width / 2, Screen.height / 2), "x" + Game.current.jabato.victories.ToString (), mypeopleStyle);

		GUI.Label (new Rect (Screen.width / 1.7f, Screen.height / 1.7f, Screen.width / 2, Screen.height / 2), Game.current.jabato.defeats.ToString () + "x", mypeopleStyle);

		GUI.Label (new Rect (Screen.width / 1.33f, Screen.height / 1.3f, Screen.width / 2, Screen.height / 2), "x" + Game.current.jabato.agility.ToString (), mypeopleStyle);

		GUI.Label (new Rect (Screen.width / 4, Screen.height / 1.3f, Screen.width / 2, Screen.height / 2), "x" + Game.current.jabato.power.ToString (), mypeopleStyle);

		GUI.Label (new Rect (Screen.width / 2, Screen.height / 1.3f, Screen.width / 2, Screen.height / 2), "x" + Game.current.jabato.resistance.ToString (), mypeopleStyle);

		//GUI.Label (new Rect(Screen.width / 3.3f, Screen.height / 1.95f, Screen.width/2, Screen.height / 2), "javaticidad "+Game.current.jabato.jabaticity.ToString(), mypeopleStyle);

		GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 1.45f, Screen.width / 2, Screen.height / 2), Game.current.jabato.atributes.ToString (), mypeopleStyle2);

		GUI.Label (new Rect (Screen.width / 1.155f, Screen.height / 2.95f, Screen.width / 2, Screen.height / 2), Game.current.jabato.rank.ToString (), mypeopleStyle);

		if (Game.current.jabato.atributes > 0) {
			//////////POWER
			///////////////////////////////////////PRIMER IF COMPRUEBA NO SOBREPASAR STATS\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			if ((Game.current.jabato.rank == 5 && Game.current.jabato.power < 15) || (Game.current.jabato.rank == 4 && Game.current.jabato.power < 40) || (Game.current.jabato.rank == 3 && Game.current.jabato.power < 80)
			   || (Game.current.jabato.rank == 2 && Game.current.jabato.power < 200) || (Game.current.jabato.rank == 1 && Game.current.jabato.power < 500)) {
				if (GUI.Button (new Rect (Screen.width / 5, Screen.height / 1.240f, Screen.width / 7.5f, Screen.height / 8), plusBtn, GUIStyle.none)) {
					Game.current.jabato.atributes = Game.current.jabato.atributes - 1;
					Game.current.jabato.power = Game.current.jabato.power + 1;
				} 
			}
			//////////RESISTANCE
			///////////////////////////////////////PRIMER IF COMPRUEBA NO SOBREPASAR STATS\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			if ((Game.current.jabato.rank == 5 && Game.current.jabato.resistance < 15) || (Game.current.jabato.rank == 4 && Game.current.jabato.resistance < 40) || (Game.current.jabato.rank == 3 && Game.current.jabato.resistance < 80)
			    || (Game.current.jabato.rank == 2 && Game.current.jabato.resistance < 200) || (Game.current.jabato.rank == 1 && Game.current.jabato.resistance < 500)) {
				if (GUI.Button (new Rect (Screen.width / 2.25f, Screen.height / 1.240f, Screen.width / 7.5f, Screen.height / 8), plusBtn, GUIStyle.none)) {
					Game.current.jabato.atributes = Game.current.jabato.atributes - 1;
					Game.current.jabato.resistance = Game.current.jabato.resistance + 1;
				} 
			}
			//////////AGILITY
			if ((Game.current.jabato.rank == 5 && Game.current.jabato.agility < 15) || (Game.current.jabato.rank == 4 && Game.current.jabato.agility < 40) || (Game.current.jabato.rank == 3 && Game.current.jabato.agility < 80)
			    || (Game.current.jabato.rank == 2 && Game.current.jabato.agility < 200) || (Game.current.jabato.rank == 1 && Game.current.jabato.agility < 500)) {
				if (GUI.Button (new Rect (Screen.width / 1.43f, Screen.height / 1.240f, Screen.width / 7.5f, Screen.height / 8), plusBtn, GUIStyle.none)) {
					Game.current.jabato.atributes = Game.current.jabato.atributes - 1;
					Game.current.jabato.agility = Game.current.jabato.agility + 1;
				} 
			}
		}

		if (GUI.Button (new Rect (Screen.width / 8, Screen.height / 1.10f, Screen.width / 7.5f, Screen.height / 8), backBtn, GUIStyle.none)) {
			SaveLoad.Save ();
			Application.LoadLevel ("Menu");
		} 

		if (GUI.Button (new Rect (Screen.width / 1.33f, Screen.height / 1.10f, Screen.width / 7.5f, Screen.height / 8), starBtn, GUIStyle.none)) {
				star = true;
		} 
			//////////////////////////////////////////////PERFIL-1 FIN\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
	}else{
			//////////////////////////////////////////////PERFIL-2\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), bg);

			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), bg_profile2);

			GUI.Label (new Rect (Screen.width / 2.3f, Screen.height / 2.20f, Screen.width / 2, Screen.height / 2), Game.current.jabato.atributes.ToString (), mypeopleStyle2);

			// DIBUJADO DE JABALIES Y MEDALLAS
			if (Game.current.jabato.rank == 5) {
				GUI.DrawTexture (new Rect (Screen.width / 7.28f, Screen.height / 21.3f, Screen.width / 1.28f, Screen.height / 3.75f), boarWood);
				GUI.DrawTexture (new Rect (Screen.width / 1.2f, Screen.height / 3.1f, Screen.width / 10, Screen.height / 12), medalBtnwood);
			} else if (Game.current.jabato.rank == 4) {
				GUI.DrawTexture (new Rect (Screen.width / 7.28f, Screen.height / 21.3f, Screen.width / 1.28f, Screen.height / 3.75f), boarIron);
				GUI.DrawTexture (new Rect (Screen.width / 1.2f, Screen.height / 3.1f, Screen.width / 10, Screen.height / 12), medalBtniron);
			} else if (Game.current.jabato.rank == 3) {
				GUI.DrawTexture (new Rect (Screen.width / 7.28f, Screen.height / 21.3f, Screen.width / 1.28f, Screen.height / 3.75f), boarGold);
				GUI.DrawTexture (new Rect (Screen.width / 1.2f, Screen.height / 3.1f, Screen.width / 10, Screen.height / 12), medalBtngold);
			} else if (Game.current.jabato.rank == 2) {
				GUI.DrawTexture (new Rect (Screen.width / 7.28f, Screen.height / 21.3f, Screen.width / 1.28f, Screen.height / 3.75f), boarDiamond);
				GUI.DrawTexture (new Rect (Screen.width / 1.2f, Screen.height / 3.1f, Screen.width / 10, Screen.height / 12), medalBtndiamond);
			} else {
				GUI.DrawTexture (new Rect (Screen.width / 7.28f, Screen.height / 21.3f, Screen.width / 1.28f, Screen.height / 3.75f), boarWhite);
				GUI.DrawTexture (new Rect (Screen.width / 1.2f, Screen.height / 3.1f, Screen.width / 10, Screen.height / 12), medalBtnwhite);
			}

			GUI.Label (new Rect (Screen.width / 1.155f, Screen.height / 2.95f, Screen.width / 2, Screen.height / 2), Game.current.jabato.rank.ToString (), mypeopleStyle);

			if ((Game.current.jabato.atributes >= 15 && Game.current.jabato.rank == 5) || (Game.current.jabato.atributes >= 50 && Game.current.jabato.rank == 4) || (Game.current.jabato.atributes >= 180 && Game.current.jabato.rank == 3)
			    || (Game.current.jabato.atributes >= 600 && Game.current.jabato.rank == 2)) {
				if (GUI.Button (new Rect (Screen.width / 2.2f, Screen.height / 1.95f, Screen.width / 2, Screen.height / 2), upgradeBtn, GUIStyle.none)) {
					if (Game.current.jabato.rank == 5)
						costupgrade = 15;
					if (Game.current.jabato.rank == 4)
						costupgrade = 50;
					if (Game.current.jabato.rank == 3)
						costupgrade = 180;
					if (Game.current.jabato.rank == 2)
						costupgrade = 600;

					Game.current.jabato.atributes = Game.current.jabato.atributes - costupgrade;
					Game.current.jabato.rank = Game.current.jabato.rank - 1;

				} 
			} else {

				string advice="";

				if (Game.current.jabato.rank == 5)
					advice = "Necesarios 15";
				if (Game.current.jabato.rank == 4)
					advice = "Necesarios 50";
				if (Game.current.jabato.rank == 3)
					advice = "Necesarios 180";
				if (Game.current.jabato.rank == 2)
					advice = "Necesarios 600";

				GUI.Label (new Rect (Screen.width / 3.2f, Screen.height / 1.9f, Screen.width / 2, Screen.height / 2), advice, mypeopleStyle);


			}

			GUI.Label (new Rect (Screen.width / 6, Screen.height / 1.47f, Screen.width / 2, Screen.height / 2), Game.current.jabato.hability.id, mypeopleStyle);
			GUI.Label (new Rect (Screen.width / 6, Screen.height / 1.40f, Screen.width / 2, Screen.height / 2), Game.current.jabato.hability.description, mypeopleStylenormal);//35 maximo


			GUI.Label (new Rect (Screen.width / 3.1f, Screen.height / 1.7f, Screen.width / 2, Screen.height / 2), "Subir de rango", mypeopleStyle);

			if (GUI.Button (new Rect (Screen.width / 5, Screen.height / 1.240f, Screen.width / 7.5f, Screen.height / 8), plusBtn, GUIStyle.none)) {
				Game.current.jabato.atributes = Game.current.jabato.atributes + 5;
			} 

			if (GUI.Button (new Rect (Screen.width / 8, Screen.height / 1.10f, Screen.width / 7.5f, Screen.height / 8), backBtn, GUIStyle.none)) {
				star = false;
			} 
	}
	}
}
