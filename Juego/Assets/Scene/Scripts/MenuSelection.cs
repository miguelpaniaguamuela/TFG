using UnityEngine;
using System.Collections;

public class MenuSelection : MonoBehaviour {

	public static string Result = ""; //To show the plugin result
	public static string Read = ""; //To show the plugin result

	public bool firsttime=true;

	public Texture bg;

	public Texture breedBtn;
	public Texture fightBtn;
	public Texture medalBtnwood;
	public Texture medalBtniron;
	public Texture medalBtngold;
	public Texture medalBtndiamond;
	public Texture medalBtnwhite;

	public Font labelfont;

	public string petition;
	public string petitionyours;

	public static string nameyours;
	public static int poweryours;
	public static int resistanceyours;
	public static int agilityyours;
	public static int rankyours;
	public static int victoriesyours;
	public static int defeatsyours;


	// Use this for initialization
	void Start () {

		Result = Bluetooth.Instance ().Send (Game.current.jabato.name+" "+Game.current.jabato.power+" "+Game.current.jabato.resistance+" "+Game.current.jabato.agility+" "+Game.current.jabato.rank+" "+Game.current.jabato.victories+" "+Game.current.jabato.defeats);

		petitionyours = "";
		petition = "";
		nameyours = "";
		poweryours = -1;
		resistanceyours = -1;
		agilityyours = -1;
		victoriesyours = -1;
		defeatsyours = -1;
		Result = "";
		Read = "";
	}


	void Awake(){
		petitionyours = "";
		petition = "";
		nameyours = "";
		poweryours = -1;
		resistanceyours = -1;
		agilityyours = -1;
		victoriesyours = -1;
		defeatsyours = -1;
		Result = "";
		Read = "";
	}
	// Update is called once per frame
	void Update () {

		if (firsttime) {
			petitionyours = "";
			petition = "";
			nameyours = "";
			poweryours = -1;
			resistanceyours = -1;
			agilityyours = -1;
			victoriesyours = -1;
			defeatsyours = -1;
			firsttime = false;
			Result = "";
			Read = "";
		} else {
			//////////////////////////VOLVER A MENU SI DESCONECTA\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			if (Bluetooth.Instance ().IsConnected ().ToString () == "False" || Bluetooth.Instance ().GetDeviceConnectedName () == "") {
				Bluetooth.Instance ().Stop ();
				BluetoothMenu.playing = false;
				Application.LoadLevel ("Menu");
			}

			//////////////////////////VOLVER A MENU SI DESCONECTA FIN\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			//////////////////////////////////////////////////////LEER PASO DE DATOS\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			if (Read != "" && Read != "CRIAR" && Read != "LUCHAR") {
				string[] mensaje = Read.Split (' ');

				//Si mensaje fin swipe
				nameyours=mensaje[0];

				int.TryParse (mensaje [1], out poweryours);
				int.TryParse (mensaje [2], out resistanceyours);
				int.TryParse (mensaje [3], out agilityyours);
				int.TryParse (mensaje [4], out rankyours);
				int.TryParse (mensaje [5], out victoriesyours);
				int.TryParse (mensaje [6], out defeatsyours);


			}
				
			//////////////////////////////////////////////////////LEER PASO DE DATOS FIN\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

			if (Read == "LUCHAR") {
				//Application.LoadLevel ("ResultBattle");
				petitionyours="LUCHAR";
			}

			if (Read == "CRIAR") {
				//Application.LoadLevel ("ResultBattle");
				petitionyours="CRIAR";
			}

			if (petition == "LUCHAR" && petition == petitionyours) {
				petition = "";
				petitionyours = "";
				Result = "";
				Read = "";
				Application.LoadLevel ("Battle");

			}

			if (petition == "CRIAR" && petition == petitionyours) {
				petition = "";
				petitionyours = "";
				Result = "";
				Read = "";
				Application.LoadLevel ("Breed");
			}

		}
	
	}

	void OnGUI(){

		GUIStyle mypeopleStyle2 = new GUIStyle ();
		mypeopleStyle2.fontSize = (int)(Screen.width * 0.04629);
		mypeopleStyle2.normal.textColor = Color.white;
		mypeopleStyle2.font = labelfont;

		GUIStyle mypeopleStyle3 = new GUIStyle ();
		mypeopleStyle3.fontSize = (int)(Screen.width * 0.04629);
		mypeopleStyle3.normal.textColor = Color.black;
		mypeopleStyle3.font = labelfont;

		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), bg);

		if (rankyours == 5) {
			GUI.DrawTexture (new Rect (Screen.width / 2.2f, Screen.height / 30, Screen.width / 10, Screen.height / 12), medalBtnwood);
		} else if (rankyours == 4) {
			GUI.DrawTexture (new Rect (Screen.width / 2.2f, Screen.height / 30, Screen.width / 10, Screen.height / 12), medalBtniron);
		} else if (rankyours == 3) {
			GUI.DrawTexture (new Rect (Screen.width / 2.2f, Screen.height / 30, Screen.width / 10, Screen.height / 12), medalBtngold);
		} else if (rankyours == 2) {
			GUI.DrawTexture (new Rect (Screen.width / 2.2f, Screen.height / 30, Screen.width / 10, Screen.height / 12), medalBtndiamond);
		} else {
			GUI.DrawTexture (new Rect (Screen.width / 2.2f, Screen.height / 30, Screen.width / 10, Screen.height / 12), medalBtnwhite);
		}

		//LABEL NUMERO RANGO
		GUI.Label (new Rect(Screen.width / 2.05f, Screen.height / 19.6f, Screen.width/2, Screen.height /2), rankyours.ToString(), mypeopleStyle2);



		if (GUI.Button (new Rect (Screen.width / 4, Screen.height / 2.5f, Screen.width / 2, Screen.height / 4), fightBtn, GUIStyle.none)) {
			//Application.LoadLevel ("Menu");
			petition="LUCHAR";
			Result = Bluetooth.Instance ().Send ("LUCHAR");
		} 

		if (GUI.Button (new Rect (Screen.width / 4, Screen.height / 1.45f, Screen.width / 2, Screen.height / 4), breedBtn, GUIStyle.none)) {
			//Application.LoadLevel ("Battle");
			petition="CRIAR";
			Result = Bluetooth.Instance ().Send ("CRIAR");
		} 

		GUI.Label (new Rect(Screen.width / 3, Screen.height / 6.5f, Screen.width/2, Screen.height / 8), nameyours, mypeopleStyle3);

		GUI.Label (new Rect(Screen.width / 1.33f, Screen.height / 3.5f, Screen.width/2, Screen.height / 2),"x"+agilityyours.ToString(), mypeopleStyle2);

		GUI.Label (new Rect(Screen.width / 4, Screen.height / 3.5f, Screen.width/2, Screen.height / 2),"x"+poweryours.ToString(), mypeopleStyle2);

		GUI.Label (new Rect(Screen.width / 2, Screen.height / 3.5f, Screen.width/2, Screen.height / 2),"x"+resistanceyours.ToString(), mypeopleStyle2);

	}


}