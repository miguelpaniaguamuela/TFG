using UnityEngine;
using System.Collections;

public class playerHud : MonoBehaviour {

	public Texture hudwood;
	public Texture hudiron;
	public Texture hudgold;
	public Texture huddiamond;
	public Texture hudwhite;

	public Texture attackbar1;
	public Texture attackbar2;
	public Texture attackbar3;
	public Texture attackbar4;
	public Texture attackbar5;
	public Texture attackbar52;

	public Texture blindedtext;

	public Font labelfont;

	private float timesprite=0.0f;

	void OnGUI()
	{

		GUIStyle mypeopleStyle2 = new GUIStyle ();
		mypeopleStyle2.fontSize = (int)(Screen.width * 0.019);
		mypeopleStyle2.normal.textColor = Color.white;
		mypeopleStyle2.font = labelfont;

		GUIStyle mypeopleStyle = new GUIStyle ();
		mypeopleStyle.fontSize = (int)(Screen.width * 0.026);
		mypeopleStyle.normal.textColor = Color.white;
		mypeopleStyle.font = labelfont;

		if (detectPlayer.id == 1) {
			///////////////////////////////SI SOY P1 HUD\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			if (Game.current.jabato.rank == 5) {
				GUI.DrawTexture (new Rect (0, 0, Screen.width / 4, Screen.height / 3.7f), hudwood);
			} else if (Game.current.jabato.rank == 4) {
				GUI.DrawTexture (new Rect (0, 0, Screen.width / 4, Screen.height / 3.7f), hudiron);
			} else if (Game.current.jabato.rank == 3) {
				GUI.DrawTexture (new Rect (0, 0, Screen.width / 4, Screen.height / 3.7f), hudgold);
			} else if (Game.current.jabato.rank == 2){
				GUI.DrawTexture (new Rect (0, 0, Screen.width / 4, Screen.height / 3.7f), huddiamond);
			} else{
				GUI.DrawTexture (new Rect (0, 0, Screen.width / 4, Screen.height / 3.7f), hudwhite);
			}

			if (MenuSelection.rankyours == 5) {
				GUI.DrawTextureWithTexCoords (new Rect (Screen.width / 1.333f, 0, Screen.width / 4, Screen.height / 3.7f), hudwood, new Rect (1, 0, -1, 1));
			} else if (MenuSelection.rankyours == 4) {
				GUI.DrawTextureWithTexCoords (new Rect (Screen.width / 1.333f, 0, Screen.width / 4, Screen.height / 3.7f), hudiron, new Rect (1, 0, -1, 1));
			} else if (MenuSelection.rankyours == 3) {
				GUI.DrawTextureWithTexCoords (new Rect (Screen.width / 1.333f, 0, Screen.width / 4, Screen.height / 3.7f), hudgold, new Rect (1, 0, -1, 1));
			} else if (MenuSelection.rankyours == 2) {
				GUI.DrawTextureWithTexCoords (new Rect (Screen.width / 1.333f, 0, Screen.width / 4, Screen.height / 3.7f), huddiamond, new Rect (1, 0, -1, 1));
			} else {
				GUI.DrawTextureWithTexCoords (new Rect (Screen.width / 1.333f, 0, Screen.width / 4, Screen.height / 3.7f), hudwhite, new Rect (1, 0, -1, 1));
			}

			if (detectPlayer.timerhability < Game.current.jabato.hability.cd / 5) {
				GUI.DrawTexture (new Rect (0, Screen.height / 3.9f, Screen.width / 8, Screen.height / 17f), attackbar1);
			}else if (detectPlayer.timerhability < (((Game.current.jabato.hability.cd)*2) / 5) && (detectPlayer.timerhability >= Game.current.jabato.hability.cd / 5)) {
				GUI.DrawTexture (new Rect (0, Screen.height / 3.9f, Screen.width / 8, Screen.height / 17f), attackbar2);
			} else if (detectPlayer.timerhability < ((Game.current.jabato.hability.cd)*3) / 5 && (detectPlayer.timerhability >= ((Game.current.jabato.hability.cd)*2) / 5)) {
				GUI.DrawTexture (new Rect (0, Screen.height / 3.9f, Screen.width / 8, Screen.height / 17f), attackbar3);
			} else if (detectPlayer.timerhability < ((Game.current.jabato.hability.cd)*4) / 5 && (detectPlayer.timerhability >= ((Game.current.jabato.hability.cd)*3) / 5)){
				GUI.DrawTexture (new Rect (0, Screen.height / 3.9f, Screen.width / 8, Screen.height / 17f), attackbar4);
			} else{
				if (timesprite > detectPlayer.timerhability)
					timesprite = 0.0f;
				if (timesprite < (detectPlayer.timerhability - 0.5f)) {
					GUI.DrawTexture (new Rect (0, Screen.height / 3.9f, Screen.width / 8, Screen.height / 17f), attackbar5);
					if(timesprite < (detectPlayer.timerhability - 1f)) timesprite = detectPlayer.timerhability;
				} else {
					GUI.DrawTexture (new Rect (0, Screen.height / 3.9f, Screen.width / 7.7f, Screen.height / 16f), attackbar52);
				}				

			}
			///////////////////////////////SI SOY P1 HUD FIN\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			/// 
			///////////////////////////////SI SOY P1 VALUES\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			GUI.Label (new Rect (Screen.width / 30, Screen.height / 40, Screen.width / 2, Screen.height / 2), Game.current.jabato.name, mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 19, Screen.height / 9.5f, Screen.width / 2, Screen.height / 2), "x" + Game.current.jabato.power.ToString (), mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 19, Screen.height / 6, Screen.width / 2, Screen.height / 2), "x" + Game.current.jabato.resistance.ToString (), mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 19, Screen.height / 4.6f, Screen.width / 2, Screen.height / 2), "x" + Game.current.jabato.agility.ToString (), mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 4.55f, Screen.height / 40, Screen.width / 2, Screen.height / 2), Game.current.jabato.rank.ToString (), mypeopleStyle);

			GUI.Label (new Rect (Screen.width / 3f, Screen.height / 40, Screen.width / 2, Screen.height / 2), timesprite.ToString(), mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 1.24f, Screen.height / 40, Screen.width / 2, Screen.height / 2), MenuSelection.nameyours, mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 1.1240f, Screen.height / 9.5f, Screen.width / 2, Screen.height / 2), MenuSelection.poweryours.ToString () + "x", mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 1.1240f, Screen.height / 6, Screen.width / 2, Screen.height / 2), MenuSelection.resistanceyours.ToString () + "x", mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 1.1240f, Screen.height / 4.6f, Screen.width / 2, Screen.height / 2), MenuSelection.agilityyours.ToString () + "x", mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 1.315f, Screen.height / 40, Screen.width / 2, Screen.height / 2), MenuSelection.rankyours.ToString (), mypeopleStyle);
		
		} else {
			///////////////////////////////SI SOY P2 HUD\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			if (Game.current.jabato.rank == 5) {
				GUI.DrawTextureWithTexCoords (new Rect (Screen.width / 1.333f, 0, Screen.width / 4, Screen.height / 3.7f), hudwood, new Rect (1, 0, -1, 1));
			} else if (Game.current.jabato.rank == 4) {
				GUI.DrawTextureWithTexCoords (new Rect (Screen.width / 1.333f, 0, Screen.width / 4, Screen.height / 3.7f), hudiron, new Rect (1, 0, -1, 1));
			} else if (Game.current.jabato.rank == 3) {
				GUI.DrawTextureWithTexCoords (new Rect (Screen.width / 1.333f, 0, Screen.width / 4, Screen.height / 3.7f), hudgold, new Rect (1, 0, -1, 1));
			} else if (Game.current.jabato.rank == 2) {
				GUI.DrawTextureWithTexCoords (new Rect (Screen.width / 1.333f, 0, Screen.width / 4, Screen.height / 3.7f), huddiamond, new Rect (1, 0, -1, 1));
			} else {
				GUI.DrawTextureWithTexCoords (new Rect (Screen.width / 1.333f, 0, Screen.width / 4, Screen.height / 3.7f), hudwhite, new Rect (1, 0, -1, 1));
			}

			if (MenuSelection.rankyours == 5) {
				GUI.DrawTexture (new Rect (0, 0, Screen.width / 4, Screen.height / 3.7f), hudwood);
			} else if (MenuSelection.rankyours == 4) {
				GUI.DrawTexture (new Rect (0, 0, Screen.width / 4, Screen.height / 3.7f), hudiron);
			} else if (MenuSelection.rankyours == 3) {
				GUI.DrawTexture (new Rect (0, 0, Screen.width / 4, Screen.height / 3.7f), hudgold);
			} else if (MenuSelection.rankyours == 2) {
				GUI.DrawTexture (new Rect (0, 0, Screen.width / 4, Screen.height / 3.7f), huddiamond);
			} else {
				GUI.DrawTexture (new Rect (0, 0, Screen.width / 4, Screen.height / 3.7f), hudwhite);
			}

			if (detectPlayer.timerhability < Game.current.jabato.hability.cd / 5) {
				GUI.DrawTextureWithTexCoords (new Rect (Screen.width/1.143f, Screen.height / 3.9f, Screen.width / 8, Screen.height / 17f), attackbar1, new Rect (1, 0, -1, 1));
			}else if (detectPlayer.timerhability < (((Game.current.jabato.hability.cd)*2) / 5) && (detectPlayer.timerhability >= Game.current.jabato.hability.cd / 5)) {
				GUI.DrawTextureWithTexCoords (new Rect (Screen.width/1.143f, Screen.height / 3.9f, Screen.width / 8, Screen.height / 17f), attackbar2, new Rect (1, 0, -1, 1));
			} else if (detectPlayer.timerhability < ((Game.current.jabato.hability.cd)*3) / 5 && (detectPlayer.timerhability >= ((Game.current.jabato.hability.cd)*2) / 5)) {
				GUI.DrawTextureWithTexCoords (new Rect (Screen.width/1.143f, Screen.height / 3.9f, Screen.width / 8, Screen.height / 17f), attackbar3, new Rect (1, 0, -1, 1));
			} else if (detectPlayer.timerhability < ((Game.current.jabato.hability.cd)*4) / 5 && (detectPlayer.timerhability >= ((Game.current.jabato.hability.cd)*3) / 5)){
				GUI.DrawTextureWithTexCoords (new Rect (Screen.width/1.143f, Screen.height / 3.9f, Screen.width / 8, Screen.height / 17f), attackbar4, new Rect (1, 0, -1, 1));
			} else{
				if (timesprite > detectPlayer.timerhability)
					timesprite = 0.0f;
				if (timesprite < (detectPlayer.timerhability - 0.5f)) {
					GUI.DrawTextureWithTexCoords (new Rect (Screen.width/1.143f, Screen.height / 3.9f, Screen.width / 8, Screen.height / 17f), attackbar5, new Rect (1, 0, -1, 1));
					if(timesprite < (detectPlayer.timerhability - 1f)) timesprite = detectPlayer.timerhability;
				} else {
					GUI.DrawTextureWithTexCoords (new Rect (Screen.width/1.143f, Screen.height / 3.9f, Screen.width / 7.7f, Screen.height / 16f), attackbar52, new Rect (1, 0, -1, 1));
				}				

			}
			///////////////////////////////SI SOY P2 HUD FIN\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			/// 
			///////////////////////////////SI SOY P2 VALUES\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			GUI.Label (new Rect (Screen.width / 1.24f, Screen.height / 40, Screen.width / 2, Screen.height / 2), Game.current.jabato.name, mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 1.1240f, Screen.height / 9.5f, Screen.width / 2, Screen.height / 2), Game.current.jabato.power.ToString () + "x", mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 1.1240f, Screen.height / 6, Screen.width / 2, Screen.height / 2), Game.current.jabato.resistance.ToString () + "x", mypeopleStyle2);

			GUI.Label (new Rect (Screen.width /1.1240f, Screen.height / 4.6f, Screen.width / 2, Screen.height / 2), Game.current.jabato.agility.ToString () + "x", mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 1.315f, Screen.height / 40, Screen.width / 2, Screen.height / 2), Game.current.jabato.rank.ToString (), mypeopleStyle);


			GUI.Label (new Rect (Screen.width / 30, Screen.height / 40, Screen.width / 2, Screen.height / 2), MenuSelection.nameyours, mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 19, Screen.height / 9.5f, Screen.width / 2, Screen.height / 2), "x" + MenuSelection.poweryours.ToString (), mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 19, Screen.height / 6, Screen.width / 2, Screen.height / 2), "x" + MenuSelection.resistanceyours.ToString (), mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 19, Screen.height / 4.6f, Screen.width / 2, Screen.height / 2), "x" +  MenuSelection.agilityyours.ToString (), mypeopleStyle2);

			GUI.Label (new Rect (Screen.width / 4.55f, Screen.height / 40, Screen.width / 2, Screen.height / 2),  MenuSelection.rankyours.ToString (), mypeopleStyle);

		}

		////////////////////////////TRATAMIENTO HABILIDADES\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		/// 
		if (detectPlayer.blinded) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), blindedtext);
		}

	}
	/*
	IEnumerator changeSprites(){
		primeraText = true;
		yield return new WaitForSeconds (.2f);
		primeraText = false;
		yield return new WaitForSeconds (.2f);
	}*/

}
