using UnityEngine;
using System.Collections;

public class resultBattle : MonoBehaviour {

	public Texture bg;
	public Texture victory;
	public Texture defeat;

	public int winattributes;
	public int loseattributes;

	public Font labelfont;

	private int dificulty = 0;
	private string diff = "Normal";
	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.Portrait;
		int difference = (Game.current.jabato.power + Game.current.jabato.agility + Game.current.jabato.resistance) - (MenuSelection.poweryours + MenuSelection.agilityyours + MenuSelection.resistanceyours);

		if (difference > 50 && difference <= 200) {
			
			dificulty = -1;
			winattributes = -2;
			diff = "Fácil";
		} else if (difference > 200) {
			dificulty = -2;
			winattributes = -5;
			diff = "Muy fácil";
		} else if (difference < (-50) && difference >= -200) {
			dificulty = 1;
			winattributes = 2;
			diff = "Diicil";
		} else if (difference < -200) {
			dificulty = 2;
			winattributes = 5;
			diff = "Muy difícil";
		}
		if (Player.winner) {
			if(Game.current.jabato.rank==5) winattributes+=3;
			if(Game.current.jabato.rank==4) winattributes+=5;
			if(Game.current.jabato.rank==3) winattributes+=10;
			if(Game.current.jabato.rank==2) winattributes+=20;
			if(Game.current.jabato.rank==1) winattributes+=20;

			Game.current.jabato.atributes = Game.current.jabato.atributes + winattributes;
			Game.current.jabato.victories = Game.current.jabato.victories + 1;

		} else {
			Game.current.jabato.defeats = Game.current.jabato.defeats + 1;
			if(Game.current.jabato.rank==5) loseattributes=0;
			if(Game.current.jabato.rank==4) loseattributes=1;
			if(Game.current.jabato.rank==3) loseattributes=2;
			if(Game.current.jabato.rank==2) loseattributes=4;
			if(Game.current.jabato.rank==1) loseattributes=5;
			if (Game.current.jabato.defeats == 10) {
				Game.current.jabato.jabaticity = 95;
			} else if (Game.current.jabato.defeats == 20) {
				Game.current.jabato.jabaticity = 85;
			} else if (Game.current.jabato.defeats == 28) {
				Game.current.jabato.jabaticity = 75;
			} else if (Game.current.jabato.defeats == 35) {
				Game.current.jabato.jabaticity = 60;
			} 

			Game.current.jabato.atributes = Game.current.jabato.atributes + loseattributes;
		}
		SaveLoad.Save ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUIStyle mypeopleStyle = new GUIStyle ();
		mypeopleStyle.fontSize = (int)(Screen.width*0.04629);
		mypeopleStyle.normal.textColor = Color.white;
		mypeopleStyle.font = labelfont;
		//mypeopleStyle.fontStyle = FontStyle.Bold;

		GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height ), bg);

		int timeG = (int)detectPlayer.timeGame;

		if (Player.winner) {
			//Bluetooth.Instance ().Stop ();
			BluetoothMenu.playing = false;
			GUI.DrawTexture (new Rect (Screen.width / 12, Screen.height / 12, Screen.width / 1.2f , Screen.height / 1.2f), victory);
			GUI.Label (new Rect (Screen.width / 4, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 8), "HAS REVENTADO A", mypeopleStyle);
			GUI.Label (new Rect (Screen.width / 3.5f, Screen.height /2.7f, Screen.width / 1.5f, Screen.height / 8), detectPlayer.nameyours, mypeopleStyle);
			mypeopleStyle.fontSize = (int)(Screen.width * 0.11111);
			//EXPERIENCIA
			GUI.Label (new Rect (Screen.width / 2.4f, Screen.height /2f, Screen.width / 1.5f, Screen.height / 8), winattributes.ToString(), mypeopleStyle);

			//STATS
			mypeopleStyle.fontSize = (int)(Screen.width*0.04729);
			GUI.Label (new Rect (Screen.width / 4, Screen.height /1.4f, Screen.width / 1.5f, Screen.height / 8), "DURACIÓN: "+timeG.ToString() + "s", mypeopleStyle);
			GUI.Label (new Rect (Screen.width / 4, Screen.height /1.32f, Screen.width / 1.5f, Screen.height / 8), "DIFICULTAD: "+diff, mypeopleStyle);
		} else {
			//Bluetooth.Instance ().Stop ();
			BluetoothMenu.playing = false;
			GUI.DrawTexture (new Rect (Screen.width /12, Screen.height / 12, Screen.width / 1.2f, Screen.height / 1.2f), defeat);
			mypeopleStyle.fontSize = (int)(Screen.width * 0.11111);
			//EXPERIENCIA
			GUI.Label (new Rect (Screen.width / 2.4f, Screen.height /2f, Screen.width / 1.5f, Screen.height / 8), loseattributes.ToString(), mypeopleStyle);
			//STATS
			mypeopleStyle.fontSize = (int)(Screen.width*0.04729);
			GUI.Label (new Rect (Screen.width / 4, Screen.height /1.4f, Screen.width / 1.5f, Screen.height / 8), "DURACIÓN: "+timeG.ToString() + "s", mypeopleStyle);

			GUI.Label (new Rect (Screen.width / 4, Screen.height /1.32f, Screen.width / 1.5f, Screen.height / 8), "DIFICULTAD: "+ diff, mypeopleStyle);
		}
	}
}
