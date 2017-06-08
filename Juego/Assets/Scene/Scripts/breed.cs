using UnityEngine;
using System.Collections;

public class breed : MonoBehaviour {

	public Texture bg;

	public Texture breedBtn;

	private int rankmine;
	private int powermine;
	private int resistancemine;
	private int agilitymine;
	private int namemine;

	private float range1 = 20;
	private float range2 = 20;
	private float range3 = 20;

	private float throwDice;
	private float multiplier;
	private int indicator;

	public Font labelfont;
	// Use this for initialization
	void Start () {
		Destroy(GameObject.Find("sound"));
		///OPERACIONES\\\
		rankmine=5;
		/// 
		int halfpower = (Game.current.jabato.power+MenuSelection.poweryours)/2;
		int halfagility = (Game.current.jabato.agility+MenuSelection.agilityyours)/2;
		int halfresistance = (Game.current.jabato.resistance+MenuSelection.resistanceyours)/2;

		indicator = (Game.current.jabato.victories + MenuSelection.victoriesyours) / (Game.current.jabato.defeats + MenuSelection.defeatsyours);

		if (indicator == 0) {
			range1 = 60;
			range2 = 20;
			range3 = 20;
		} else if (indicator == 1 || indicator == 2) {
			range2 = 60;
			range1 = 20;
			range3 = 20;
		} else if (indicator >= 3) {
			range3 = 60;
			range2 = 20;
			range1 = 20;
		}

		throwDice = Random.Range (0, 100);
		multiplier = 0.0f;
		if (throwDice >= 0.0f && throwDice < range1) {
			multiplier = (throwDice - 0) / (range1 - 0);
		}else if (throwDice >= range1 && throwDice < (range2+range1)){
			multiplier = 1.0f+((throwDice - range1) / (range2));
		}else if (throwDice >= (range2+range1) && throwDice <= 100){
			multiplier = 2.0f+((throwDice - (range2+range1)) / (range3));

		}

		float powermine2 = (multiplier * halfpower);
		float resistancemine2 = (multiplier * halfresistance);
		float agilitymine2 = (multiplier * halfagility);

		powermine = (int)powermine2;
		resistancemine = (int)resistancemine2;
		agilitymine = (int)agilitymine2;

		if ((powermine > 15 && powermine <= 40) || (resistancemine > 15 && resistancemine <= 40) ||(agilitymine > 15 && agilitymine <= 40)) rankmine = 4;
		else if ((powermine > 40 && powermine <= 80) || (resistancemine > 40 && resistancemine <= 80) ||(agilitymine > 40 && agilitymine <= 80)) rankmine = 3;
		else if ((powermine > 80 && powermine <= 200) || (resistancemine > 80 && resistancemine <= 200) ||(agilitymine > 80 && agilitymine <= 200)) rankmine = 2;
		else if ((powermine > 200) || (resistancemine > 200) ||(agilitymine > 200)) rankmine = 1;

		//PONER HABILIDAD

	}



	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUIStyle mypeopleStyle = new GUIStyle ();
		//mypeopleStyle.fontSize = 50;
		mypeopleStyle.fontSize = (int)(Screen.width * 0.04629);
		mypeopleStyle.normal.textColor = Color.white;
		mypeopleStyle.font = labelfont;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), bg);

		GUI.Label (new Rect (Screen.width / 1.9f, (Screen.height / 6f)-200, Screen.width / 6, Screen.height / 8),  indicator.ToString(), mypeopleStyle);
		GUI.Label (new Rect (Screen.width / 1.9f, (Screen.height / 6f), Screen.width / 6, Screen.height / 8), throwDice.ToString(), mypeopleStyle);
		GUI.Label (new Rect (Screen.width / 1.9f, (Screen.height / 6f) + 200, Screen.width / 6, Screen.height / 8), "multiplier..."+multiplier.ToString(), mypeopleStyle);
		GUI.Label (new Rect (Screen.width / 1.9f, (Screen.height / 6f) + 400, Screen.width / 6, Screen.height / 8),((Game.current.jabato.victories + MenuSelection.victoriesyours) / (Game.current.jabato.defeats + MenuSelection.defeatsyours)).ToString(), mypeopleStyle);

		if (GUI.Button (new Rect (Screen.width / 4, Screen.height / 2.5f, Screen.width / 2, Screen.height / 4), breedBtn, GUIStyle.none)) {
			Game.current = new Game ();
			Game.current.jabato.name = MenuSelection.nameyours+"Baby";
			Game.current.jabato.power = powermine;
			Game.current.jabato.resistance = resistancemine;
			Game.current.jabato.agility = agilitymine;
			Game.current.jabato.rank = rankmine;
			Game.current.jabato.hability = BluetoothMenu.habilities [4];
			SaveLoad.Save ();
			Bluetooth.Instance ().Stop ();
			BluetoothMenu.playing = false;
			Application.LoadLevel ("Profile");
		} 
	}
}
