using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BluetoothMenu : MonoBehaviour {
	//Variables de texturas de botones
	public Texture playBtn;
	public Texture exitBtn;
	public Texture titleSearching;
	public Texture titleSearched;
	public Texture discoverBtn;
	public Texture updateBtn;
	public Texture backBtn;
	public Texture labelPlayer;

	private bool searching = false;
	private bool pressed = false;
	private bool pressedVisible = false;
	private bool visible = false;

	private bool prueba=false;

	private bool connected = false;
	public static string Result = ""; //To show the plugin result

	public static bool playing = false;
	public Font labelfont;
	public Texture woodboar;
	public Texture ironboar;
	public Texture goldboar;
	public Texture diamondboar;
	public Texture whiteboar;

	private GameObject popup; 
	private GameObject popup_bt; 

	public static List<Habilities> habilities = new List<Habilities> ();

	void Start(){

		//METEMOS HABILIDADES A LA LISTA
		if (habilities.Count==0) {
			habilities.Add (new Habilities ("Rotar", "Cambia tu posición con el rival", 5, 5));
			habilities.Add (new Habilities ("Enamorar", "Tu rival se hiere a sí mismo", 5, 5));
			habilities.Add (new Habilities ("Cegar", "Entorpece la vision del rival", 5, 5));
			habilities.Add (new Habilities ("Invisibilidad", "Desapareces de la visión del rival", 5, 5));
			habilities.Add (new Habilities ("Confundir", "Cambia los controles del rival", 10, 5));
		}
		SaveLoad.Load ();
		if (SaveLoad.savedGames.Count == 0) {
			Game.current = new Game ();
			Game.current.jabato.name = Bluetooth.Instance ().DeviceName ();
			SaveLoad.Save ();
		} else {
			foreach (Game g in SaveLoad.savedGames) {				
				Game.current = g;
			}
		}

		popup = GameObject.Find ("Popup");
		popup_bt = GameObject.Find ("Popup-bluetooth");
		Screen.orientation = ScreenOrientation.Portrait;
	}

	void OnGUI()
	{

		//PRUEBAS
		/*
		GUI.enabled = false;
		GUI.TextField(new Rect(0, (Screen.height / 10) * 9, Screen.width, Screen.height / 10), Result);
		GUI.enabled = true;*/
		//comprobar siempre que esta activo
		if(Bluetooth.Instance().IsEnabled().ToString() == "True" && pressed) searching = true;	

		//Definir botones
		if (!searching) {		
			//DIBUJAR JABALI
			if (Game.current.jabato.rank == 5) {
				if (GUI.Button (new Rect (Screen.width / 30f, Screen.height / 1.45f, Screen.width / 2.8f, Screen.height / 8), woodboar, GUIStyle.none)) {
					GameObject.Find ("boar_sound").GetComponent<boarSound> ().soundshoot ();
					Application.LoadLevel ("Profile");
				}
			} else if (Game.current.jabato.rank == 4) {
				if (GUI.Button (new Rect (Screen.width / 30f, Screen.height / 1.45f, Screen.width / 2.8f, Screen.height / 8), ironboar, GUIStyle.none)) {
					GameObject.Find ("boar_sound").GetComponent<boarSound> ().soundshoot ();
					Application.LoadLevel ("Profile");
				}
			} else if (Game.current.jabato.rank == 3) {
				if (GUI.Button (new Rect (Screen.width / 30f, Screen.height / 1.45f, Screen.width / 2.8f, Screen.height / 8), goldboar, GUIStyle.none)) {
					GameObject.Find ("boar_sound").GetComponent<boarSound> ().soundshoot ();
					Application.LoadLevel ("Profile");
				}
			} else if (Game.current.jabato.rank == 2) {
				if (GUI.Button (new Rect (Screen.width / 30f, Screen.height / 1.45f, Screen.width / 2.8f, Screen.height / 8), diamondboar, GUIStyle.none)) {
					GameObject.Find ("boar_sound").GetComponent<boarSound> ().soundshoot ();
					Application.LoadLevel ("Profile");
				}
			} else {
				if (GUI.Button (new Rect (Screen.width / 30f, Screen.height / 1.45f, Screen.width / 2.8f, Screen.height / 8), whiteboar, GUIStyle.none)) {
					GameObject.Find ("boar_sound").GetComponent<boarSound> ().soundshoot ();
					Application.LoadLevel ("Profile");
				}
			}
			if (GUI.Button (new Rect (Screen.width / 1.9f, Screen.height / 1.95f, Screen.width / 2.4f, Screen.height / 9), playBtn, GUIStyle.none)) {
				Debug.Log ("PLAY BUTTON");
				playing = true;
				Result = Bluetooth.Instance().EnableBluetooth(); //para activar bluetooth
				pressed = true;
			}
			if (GUI.Button (new Rect (Screen.width / 1.9f, Screen.height / 1.65f, Screen.width / 2.4f, Screen.height /9), exitBtn, GUIStyle.none)) {
				Debug.Log ("EXIT BUTTON");
				Application.Quit ();
			}
		} else {
			pressed = false;
			GUIStyle mybtnGUI = new GUIStyle ();
			mybtnGUI.fontSize = 65;
			mybtnGUI.normal.textColor = Color.white;

			//YA ERES VISIBLE; BUSCANDO DISPOSITIVOS
			if (!connected) {
				//CONTROLAR QUE ESTE BT
				if(Bluetooth.Instance().IsEnabled().ToString() =="False") {
					popup_bt.GetComponent<popupAppear> ().ShowMessage ();
				}
				//DISCOVERABLE
				if (GUI.Button (new Rect (Screen.width / 1.6f, Screen.height / 1.12f, Screen.width / 7.5f, Screen.height / 8), discoverBtn, GUIStyle.none)) {
					Result = Bluetooth.Instance().Discoverable();
				}
				//BUSCAR
				if (GUI.Button (new Rect (Screen.width / 1.30f, Screen.height / 1.12f, Screen.width / 7.5f, Screen.height / 8), updateBtn, GUIStyle.none)) {
					Result = Bluetooth.Instance ().SearchDevice ();
				} 
				//VOLVER
				if (GUI.Button (new Rect (Screen.width / 8, Screen.height / 1.12f, Screen.width / 7.5f, Screen.height / 8), backBtn, GUIStyle.none)) {
					searching = false;
					playing = false;
				} 
				//buscando dispositivos
				GUI.DrawTexture (new Rect(Screen.width / 9.5f, Screen.height / 15, Screen.width / 1.25f, Screen.height / 10), titleSearching);

				GUIStyle mypeopleStyle = new GUIStyle ();
				//mypeopleStyle.fontSize = 50;
				mypeopleStyle.fontSize = (int)(Screen.width*0.04629);
				mypeopleStyle.normal.textColor = new Color (0.5098f, 0.215f, 0.0f, 1.0f);
				mypeopleStyle.font = labelfont;

				//Devices the Bluetooth found, so you can connect if you want
				//if(Bluetooth.Instance().MacAddresses.Count == 0)
				if (Result == "FoundZeroDeviceEvent") {
					GUI.Label (new Rect (Screen.width / 8f, (Screen.height / 2f), Screen.width / 2, Screen.height / 8), "No hay jugadores cerca tuya...", mypeopleStyle);
					GUI.DrawTexture (new Rect (Screen.width / 9.5f, Screen.height / 15, Screen.width / 1.25f, Screen.height / 10), titleSearched);
				}
				for (int i = 0; i < Bluetooth.Instance().MacAddresses.Count; i++)
				{
					
					if (GUI.Button(new Rect(Screen.width / 7, Screen.height*0.2083f + (i * (Screen.height / 8)), Screen.width / 1.2f, Screen.height / 6), labelPlayer, GUIStyle.none))
					{
						Bluetooth.Instance().Connect(Bluetooth.Instance().MacAddresses[i]);
					}
					GUI.Label (new Rect(Screen.width / 3.5f, Screen.height*0.23f + (i * (Screen.height / 8)), Screen.width / 1.2f, Screen.height / 8), Bluetooth.Instance().MacAddresses[i], mypeopleStyle);
					if(i == Bluetooth.Instance().MacAddresses.Count -1)
						GUI.DrawTexture (new Rect (Screen.width / 9.5f, Screen.height / 15, Screen.width / 1.25f, Screen.height / 10), titleSearched);
					else
						GUI.DrawTexture (new Rect (Screen.width / 9.5f, Screen.height / 15, Screen.width / 1.25f, Screen.height / 10), titleSearching);

				}

				if (Result == "UNABLE TO CONNECT") {
					popup.GetComponent<popupAppear> ().ShowMessage ();
				}
			}
			
		}

		//SI ESTAMOS CONECTADOS::: MANDA MENSAJE ::: CAMBIO ESCENA
		if (Bluetooth.Instance ().IsConnected ().ToString () == "True") {
			connected = true;

			var centeredStyle = GUI.skin.GetStyle ("Label");
			centeredStyle.alignment = TextAnchor.UpperCenter;
			centeredStyle.fontSize = 65;
			GUI.Label (new Rect (Screen.width / 4.8f, Screen.height / 8, Screen.width / 1.5f, Screen.height / 10), "Estás conectado a:", centeredStyle);
			GUI.Label (new Rect (Screen.width / 4.8f, Screen.height / 3.5f, Screen.width / 1.5f, Screen.height / 10), Bluetooth.Instance().GetDeviceConnectedName(), centeredStyle);

			//cambiamos a escena SELECCION
			Application.LoadLevel ("MenuSelection");
		}

	}
}
