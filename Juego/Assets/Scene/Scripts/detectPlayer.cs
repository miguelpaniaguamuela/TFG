using UnityEngine;
using System.Collections;

public class detectPlayer : MonoBehaviour {


	public static float pulsos;
	public static float pulsosyours;

	public static string nameyours;

	public Font labelfont;
	public Font labelfontbold;
	public static string Result = ""; //To show the plugin result
	public static string Read = ""; //To show the plugin result

	public float idplayermine;
	public float idplayeryours;
	public static float id;

	public Texture goBtn;

	public static bool started=false;
	private bool asigned=false;

	private bool toAsign = false;

	public float timer;
	public bool timeStarted = false;
	public bool goin=false;
	public bool goin2=false;

	public bool firsttime=true;

	public static float timeGame;

	public static bool final = false;

	public AudioClip myclip;

	public static float timerhability;
	//SWIPE

	public float minSwipeDistY;
	public float minSwipeDistX;
	private Vector2 startPos;
	public static bool disabledAttack;
	public static bool disabledDefense;
	public static bool disabledAttackyours;
	public static bool disabledDefenseyours;
	private float timeAttack;
	private float timeDefense;

	private bool quit;

	public int swipes=0;
	private float attackSwipeTimeRatio;
	private float powerSwipeEquation;
	private float powerTapEquation;
	private float resistancePercEquation;

	private GameObject Player1;
	private GameObject Player2;
	// Use this for initialization

	//VARIABLES HABILIDADES
	public static bool inlove;
	private float lovetime = 0.0f;

	public static bool blinded;
	private float blindedtime = 0.0f;

	public static bool invisibleyours;
	private float invisibletime = 0.0f;
	public static bool invisiblemine;
	private float invisibletimemine = 0.0f;
	private int[] movements;
	public static bool confused;
	private float confusedtime = 0.0f;

	public static bool transitioning;


	void Start () {
		this.gameObject.AddComponent<AudioSource> ();
		this.GetComponent<AudioSource> ().clip = myclip;
		Player1 = GameObject.Find ("Player1");
		Player2 = GameObject.Find ("Player2");
		idplayermine = -1.0f;
		idplayeryours = -1.0f;
		pulsos = 0.0f;
		pulsosyours = 0.0f;
		timer = 0.0f;
		timeGame = 0.0f;
		goin = false;
		goin2 = false;
		final = false;
		started = false;
		toAsign = false;
		nameyours = "";
		minSwipeDistX = 200.0f;
		minSwipeDistY = 200.0f;
		disabledAttack=false;
		disabledDefense = false;
		disabledAttackyours=false;
		disabledDefenseyours = false;
		timeAttack=0.0f;
		timeDefense = 0.0f;
		quit = false;
		attackSwipeTimeRatio = 0.0f;
		powerSwipeEquation = 0.0f;
		powerTapEquation = 0.0f;
		resistancePercEquation = 0.0f;
		timerhability = 0.0f;
		inlove = false;
		blinded = false;
		invisibleyours = false;
		invisiblemine = false;
		movements = new int[] {0,1,2,3}; 
		confused = false;
		transitioning = false;
	}

	void Awake(){
		idplayermine = -1.0f;
		idplayeryours = -1.0f;
		Read = "";
		pulsos = 0.0f;
		pulsosyours = 0.0f;
		started = false;
		toAsign = false;
		id = -1;
		timer = 0.0f;
		timeGame = 0.0f;
		goin2 = false;
		final = false;
		nameyours = "";
		minSwipeDistX = 200.0f;
		minSwipeDistY = 200.0f;
		disabledAttack=false;
		disabledDefense = false;
		disabledAttackyours=false;
		disabledDefenseyours = false;
		timeAttack=0.0f;
		timeDefense = 0.0f;
		attackSwipeTimeRatio = 0.0f;
		powerSwipeEquation = 0.0f;
		powerTapEquation = 0.0f;
		resistancePercEquation = 0.0f;
		Player1 = GameObject.Find ("Player1");
		Player2 = GameObject.Find ("Player2");
		timerhability = 0.0f;
		inlove = false;
		blinded = false;
		invisibleyours = false;
		invisiblemine = false;
		movements = new int[] {0,1,2,3}; 
		confused = false;
		transitioning = false;
	}
	
	// Update is called once per frame
	void Update () {



		if (firsttime) {
			idplayermine = -1.0f;
			idplayeryours = -1.0f;
			pulsos = 0.0f;
			pulsosyours = 0.0f;
			timer = 0.0f;
			timeGame = 0.0f;
			goin = false;
			goin2 = false;
			started = false;
			toAsign = false;
			firsttime = false;
			final = false;
			nameyours = "";
			minSwipeDistX = 200.0f;
			minSwipeDistY = 200.0f;
			disabledAttack=false;
			disabledDefense = false;
			disabledAttackyours=false;
			disabledDefenseyours = false;
			timeAttack=0.0f;
			timeDefense = 0.0f;
			attackSwipeTimeRatio = 0.0f;
			powerSwipeEquation = 0.0f;
			powerTapEquation = 0.0f;
			resistancePercEquation = 0.0f;
			Player1 = GameObject.Find ("Player1");
			Player2 = GameObject.Find ("Player2");
			timerhability = 0.0f;
			inlove = false;
			blinded = false;
			invisibleyours = false;
			invisiblemine = false;
			movements = new int[] {0,1,2,3}; 
			confused = false;
			transitioning = false;
		} else {
			if (Bluetooth.Instance ().IsConnected ().ToString () == "False" || Bluetooth.Instance ().GetDeviceConnectedName () == "") {
				Bluetooth.Instance ().Stop ();
				BluetoothMenu.playing = false;
				Application.LoadLevel ("Menu");
			}
			////// variables a tener en cuenta
			/// POWER Game.current.jabato.POWER
			/// AGILITY Game.current.jabato.AGILITY
			/// RESISTANCE Game.current.jabato.RESISTANCE
			/// 

			//ECUACION DE REDUCCION DE DAÑO - RESISTENCIA
			resistancePercEquation = 1 / ((2 * (1 + Mathf.Sqrt((MenuSelection.resistanceyours+15)*170))) / 100);

			//ATAQUE SWIPE
			if (disabledAttack) {
				timeAttack += Time.deltaTime;
				attackSwipeTimeRatio = (1.2f - ((Mathf.Sqrt (Game.current.jabato.agility * 700)) / 1000));
				if (timeAttack >= attackSwipeTimeRatio) {					
					if (!disabledDefenseyours && !quit) {
						//////// SWIPE POWER
						powerSwipeEquation = 15 / (100 / (2 * (1 + Mathf.Sqrt((Game.current.jabato.power+15)*170))));
						if(!inlove) pulsos = pulsos + (powerSwipeEquation * resistancePercEquation);
						else pulsos = pulsos - (powerSwipeEquation * resistancePercEquation);
						quit=true;
					}

					Result = Bluetooth.Instance ().Send (pulsos.ToString () + " ataquefin");
					if (timeAttack >= attackSwipeTimeRatio+0.2f) {
						disabledAttack = false;
						timeAttack = 0.0f;
						quit=false;
					}
				}
			}

			//DEFENSA SWIPE
			if(disabledDefense){
				timeDefense += Time.deltaTime;
				//float defenseTimeRatio = 0.6f + (Game.current.jabato.resistance/350); //MINIMO 0.6 SEGUNDOS MAXIMO 2.0 SEGUNDOS

				if (timeDefense >= 0.6) {
					Result = Bluetooth.Instance ().Send (pulsos.ToString ()+" defensafin");
					if (timeDefense >= 0.8f) {
						disabledDefense = false;
						timeDefense = 0.0f;
					}

				}
			}


			if (started) {
				//INICIAMOS TIEMPO TRANSCURRIDO DE JUEGO
				timeGame += Time.deltaTime;
				timerhability += Time.deltaTime;
				////////////////////////////////////////////////////// PULSO Y SWIPE \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
				//if UNITY_ANDROID SWIPE
				if (!disabledAttack && !disabledDefense) {
					float swipeValue1 = 0;
					float swipeValue2 = 0;

					if (Input.touchCount > 0) {
						Touch touch = Input.touches [0];	
						switch (touch.phase) {

						case TouchPhase.Began:
							startPos = touch.position;
							break;

						case TouchPhase.Ended:
							float swipeDistVertical = (new Vector3 (0, touch.position.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;
							if (swipeDistVertical > minSwipeDistY) {
								float swipeValue = Mathf.Sign (touch.position.y - startPos.y);
								swipeValue1 = swipeValue;
								if (swipeValue > 0) { //up swipe ***********DEFENSA**********
									if (!confused) {
										disabledDefense = true;
										Result = Bluetooth.Instance ().Send ("Defensa: swipe");
									} else confusedmovements (0);
									
								} else if (swipeValue < 0) {//down swipe *********ATAQUE ESPECIAL*********
									if (Game.current.jabato.hability.id != "" && timerhability>=Game.current.jabato.hability.cd) {
										if (!confused) {
											switch (Game.current.jabato.hability.id) {
											case "Rotar":
												if (id == 1) {
													Player1.GetComponent<Player> ().habilityRotate ();
												} else {
													Player2.GetComponent<Player> ().habilityRotate ();
												}
												Result = Bluetooth.Instance ().Send ("Habilidad1");
												break;
											case "Enamorar":
												Result = Bluetooth.Instance ().Send ("Habilidad2");
												break;
											case "Cegar":
												Result = Bluetooth.Instance ().Send ("Habilidad3");
												break;
											case "Invisibilidad":
												invisibletimemine = timeGame;
												invisiblemine = true;
												Result = Bluetooth.Instance ().Send ("Habilidad4");
												break;
											case "Confundir":
												
												Result = Bluetooth.Instance ().Send ("Habilidad5");
												break;
											}
											timerhability = 0.0f;
										} else confusedmovements (3);								


									}
								}
							}

							float swipeDistHorizontal = (new Vector3 (touch.position.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;
							if (swipeDistHorizontal > minSwipeDistX) {
								float swipeValue = Mathf.Sign (touch.position.x - startPos.x);
								swipeValue2 = swipeValue;
								if (swipeValue > 0) {//right swipe
									//Hacer algo
									if (id == 1) { //SI ES JUGADOR 1
										if (!confused) {
											disabledAttack = true;
											Result = Bluetooth.Instance ().Send ("Ataque: swipe");
										} else confusedmovements (1);
									}
								} else if (swipeValue < 0) {//left swipe
									//Hacer algo
									if (id == 2) { //SI ES JUGADOR 2
										if (!confused) {
											disabledAttack = true;
											Result = Bluetooth.Instance ().Send ("Ataque: swipe");
										} else confusedmovements (1);
									}
								}
							}
							//ATAQUE TAP
							if (swipeValue1 == 0 && swipeValue2 == 0) {
								if (!disabledDefenseyours) {
									if (!confused) {
										powerTapEquation = (2 * (1 + Mathf.Sqrt ((Game.current.jabato.power + 15) * 170))) / 100;
										if (!inlove)
											pulsos = pulsos + (powerTapEquation * resistancePercEquation);
										else
											pulsos = pulsos - (powerTapEquation * resistancePercEquation);
										//Send Button
										Result = Bluetooth.Instance ().Send (pulsos.ToString () + " ataquenormal");
										if (id == 1) {
											Player1.GetComponent<playerControl> ().tappingAttack ();
										} else {
											Player2.GetComponent<playerControl> ().tappingAttack ();
										}
									} else confusedmovements (2);
								}
							}
								//FINAL CASE 2
							break;
						}
					}		
				}
			}

			////////////////////////////////////////////////////// PULSO Y SWIPE FIN\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

			//////////////////////////////////////////////////////Asignacion de PLAYERS\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			if (toAsign && !asigned) {
				if (idplayermine != -1 && idplayeryours != -1) {
					if (idplayermine > idplayeryours) {
						id = 1;
					} else {
						id = 2;
					}
					nameyours = Bluetooth.Instance ().GetDeviceConnectedName ();
					asigned = true;
					toAsign = false;
				}
			}

			//////////////////////////////////////////////////////Asignacion de PLAYERS FIN\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

			//////////////////////////////////////////////////////LEER PULSOS DEL OTRO\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			if (started && asigned) {
				float readint = -1;
				if (Read != "" && Read != "DERROTA" && Read != "Ataque: swipe" && Read!="Habilidad1" && Read!="Habilidad2" && Read!="Habilidad3" && Read!="Habilidad4" && Read!="Habilidad5" && Read != "tapfin") {
					string[] mensaje = Read.Split (' ');
					//Si mensaje fin swipe
					if (mensaje [1] == "ataquefin") {
						disabledAttackyours = false;
						float.TryParse (mensaje[0], out readint);
					} else if(mensaje [1] == "ataquenormal"){
						float.TryParse (mensaje[0], out readint);
						if (!transitioning) {
							if (id == 1) {
								transitioning = true;
								Player1.GetComponent<playerControl> ().tappingAttackYours ();
							} else {
								transitioning = true;
								Player2.GetComponent<playerControl> ().tappingAttackYours ();
							}
						}
					} else if (mensaje [1] == "defensafin") {
						disabledDefenseyours = false;
					}else if (mensaje [1] == "inicial") {
						//disabledDefenseyours = false;
					}
				//	int.TryParse (mensaje[0], out readint);

				}
				if (readint != -1 && pulsosyours != readint) {
					pulsosyours = readint;
				}
			}

			//////////////////////////////////////////////////////LEER PULSOS DEL OTRO FIN\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

			//////////////////////////////////////////////////////TEMPORIZAR COMENZAR A JUGAR\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			if (goin2) {
				timer += Time.deltaTime;
				if (timer > 3) {
					goin = true;
				}
			}
			//////////////////////////////////////////////////////TEMPORIZAR COMENZAR A JUGAR FIN\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
				
			//////////////////////////////////////////////////////HAS GANADO?\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

			if (Player.winner) {
				Result = Bluetooth.Instance ().Send ("DERROTA");
			}
			//////////////////////////////////////////////////////HAS GANADO? FIN\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		
			//////////////////////////////////////////////////////ENVIO DERROTA\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			if (Read=="DERROTA") {
				final = true;
				Application.LoadLevel("ResultBattle");
			}
			//////////////////////////////////////////////////////ENVIO DERROTA FIN\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			/// 
			/// //////////////////////////////////////////////////////ENVIO AT SWIPE\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			if (Read=="Ataque: swipe") {
				disabledAttackyours = true;
			}

			if (Read == "Defensa: swipe") {
				disabledDefenseyours = true;
			}

			//////////////////////////////////////////////////////ENVIO AT SWIPE FIN\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			//////////////////////////////////////////////////////LEER SI OTRO TAP FIN\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			if (Read == "tapfin") {
				if (id == 1) {
					Player1.GetComponent<playerControl> ().stopTappingAttackYours ();
				} else {
					Player2.GetComponent<playerControl> ().stopTappingAttackYours ();
				}
			}
			//////////////////////////////////////////////////////LEER HABILIDADES\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			if (Read == "Habilidad1") {
				if (id == 1) {
					id = 2;
				} else {
					id = 1;
				}
				Read = "";
			}

			if (Read == "Habilidad2") {
				inlove = true;
				lovetime = timeGame;
				Read = "";
			}

			if (inlove && lovetime < timeGame - 5.0f) {
				inlove = false;
			}

			if (Read == "Habilidad3") {
				blinded = true;
				blindedtime = timeGame;
				Read = "";
			}

			if (blinded && blindedtime < timeGame - 5.0f) {
				blinded = false;
			}

			if (Read == "Habilidad4") {
				invisibleyours = true;
				invisibletime = timeGame;
				Read = "";
			}

			if (invisibleyours && invisibletime < timeGame - 5.0f) {
				invisibleyours = false;
			}

			if (invisiblemine && invisibletimemine < timeGame - 5.0f) {
				invisiblemine = false;
			}

			if (Read == "Habilidad5") {
				shufflearray (movements); //randomizamos los movimientos
				confused=true;
				confusedtime = timeGame;
				Read = "";
			}

			if (confused && confusedtime < timeGame - 10.0f) {
				confused = false;
				movements = new int[] {0,1,2,3}; 
			}
		}
	}

	void OnGUI(){
		if (!firsttime) {
			if (!started) {
				if (!goin2) {
					if (GUI.Button (new Rect (Screen.width / 4, Screen.height / 8, Screen.width / 2, Screen.height / 1.5f), goBtn, GUIStyle.none)) {
						RandomId (); // ASIGNAMOS IDPLAYERMINE
						Result = Bluetooth.Instance ().Send (idplayermine.ToString ());
					}
				}
			}

			GUIStyle mypeopleStyle = new GUIStyle ();
			//mypeopleStyle.fontSize = 50;
			mypeopleStyle.fontSize = (int)(Screen.width * 0.04629);
			mypeopleStyle.normal.textColor = Color.white;
			mypeopleStyle.font = labelfont;
			//FUENTE CUENTA ATRAS
			GUIStyle countdown = new GUIStyle ();
			//mypeopleStyle.fontSize = 50;
			countdown.fontSize = (int)(Screen.width * 0.2629);
			countdown.normal.textColor = Color.white;
			countdown.font = labelfontbold;

			if (!started) {
				float readfloat = -1.0f;
				if (Read != "" && Read!= "DERROTA" && Read!="Ataque: swipe" && Read != "Ataque: swipe terminado")
					float.TryParse (Read, out readfloat);
				// COMPROBAR SI AMBOS HAN PULSADO
				if (readfloat != -1.0f && idplayermine != -1) {
					idplayeryours = readfloat;
					toAsign = true;
					goin2 = true;
					if(timer<1) GUI.Label (new Rect (Screen.width / 2.5f, (Screen.height / 3f), Screen.width / 2, Screen.height / 2), "3", countdown);
					if(timer<2 && timer>1) GUI.Label (new Rect (Screen.width / 2.5f, (Screen.height / 3f), Screen.width / 2, Screen.height / 2), "2", countdown);
					if(timer<3 && timer >2) GUI.Label (new Rect (Screen.width / 2.5f, (Screen.height / 3f), Screen.width / 2, Screen.height / 2), "1", countdown);
					if (goin) {
						//idplayeryours = readfloat;
						Result = Bluetooth.Instance ().Send (pulsos.ToString () + " inicial");
						started = true;
						battlesound ();
						//GUI.Label (new Rect (Screen.width / 1.5f, (Screen.height / 6f) + 400, Screen.width / 6, Screen.height / 8), Read, mypeopleStyle);
					}
				}
			}

			GUI.Label (new Rect (Screen.width / 1.9f, (Screen.height / 6f), Screen.width / 6, Screen.height / 8), Read, mypeopleStyle);
			GUI.Label (new Rect (Screen.width / 1.9f, (Screen.height / 6f) + 200, Screen.width / 6, Screen.height / 8), Result, mypeopleStyle);
			GUI.Label (new Rect (Screen.width / 1.9f, (Screen.height / 6f) + 400, Screen.width / 6, Screen.height / 8),"timeH->"+ timerhability.ToString(), mypeopleStyle);
			GUI.Label (new Rect (Screen.width / 1.9f, (Screen.height / 6f) + 600, Screen.width / 6, Screen.height / 8),"confused->"+ confused.ToString(), mypeopleStyle);
		}
	}

	void RandomId(){
		if(idplayermine == -1)
			idplayermine = Random.Range (0.0f, 100.0f);
	}

	void battlesound(){
		this.GetComponent<AudioSource> ().Play (0);
	}

	void confusedmovements(int mov){
		int aux = -1;
		aux = movements [mov];
		if (aux == 0) { //cambio por habilidad defensa
			disabledDefense = true;
			Result = Bluetooth.Instance ().Send ("Defensa: swipe");
		} else if (aux == 1) { //cambio por habilidad atq swipe
			disabledAttack = true;
			Result = Bluetooth.Instance ().Send ("Ataque: swipe");
		} else if (aux == 2) { //cambio por habilidad tap
			powerTapEquation = (2 * (1 + Mathf.Sqrt ((Game.current.jabato.power + 15) * 170))) / 100;
			if (!inlove)
				pulsos = pulsos + (powerTapEquation * resistancePercEquation);
			else
				pulsos = pulsos - (powerTapEquation * resistancePercEquation);			
			Result = Bluetooth.Instance ().Send (pulsos.ToString () + " ataquenormal");
		} else { //cambio por habilidad especial
			switch (Game.current.jabato.hability.id) {
				case "Rotar":
					if (id == 1) {
						Player1.GetComponent<Player> ().habilityRotate ();
					} else {
						Player2.GetComponent<Player> ().habilityRotate ();
					}
					Result = Bluetooth.Instance ().Send ("Habilidad1");
					break;
				case "Enamorar":
					Result = Bluetooth.Instance ().Send ("Habilidad2");
					break;
				case "Cegar":
					Result = Bluetooth.Instance ().Send ("Habilidad3");
					break;
				case "Invisibilidad":
					invisibletimemine = timeGame;
					invisiblemine = true;
					Result = Bluetooth.Instance ().Send ("Habilidad4");
					break;
				case "Confundir":
					shufflearray (movements); //randomizamos los movimientos
					Result = Bluetooth.Instance ().Send ("Habilidad5");
					break;
				}
			timerhability = 0.0f;
		}
	}

	void shufflearray (int[] arr){
		for (int i = arr.Length - 1; i > 0; i--) {
			int r = Random.Range (0, i);
			int tmp = arr [i];
			arr [i] = arr [r];
			arr [r] = tmp;
		}
	}

	public void endTapYours(){
		Result = Bluetooth.Instance ().Send ("tapfin");
	}



}

