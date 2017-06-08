using UnityEngine;
using System.Collections;

[System.Serializable]

public class Habilities{		
	public string id; 
	public string description; 
	public float cd;
	public int rarity;



	public Habilities(string name, string desc, int cold, int rare){
		this.id = name;
		this.cd = cold;
		this.rarity = rare;
		this.description = desc;
	}

}


/*
	 * Habilidad1 -> Rotar jugadores.
	 * Habilidad2 -> Enamorar.
	 * Habilidad3 -> Cegar.
	 * Habilidad4 -> Invisible.
	 * Habilidad5 -> Confundir.
	 */