using UnityEngine;
using System.Collections;

	[System.Serializable]
public class Game{

	public static Game current;
	public Entity jabato;

	public Game(){

		jabato = new Entity ();

	}

}
