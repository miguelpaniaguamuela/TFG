using UnityEngine;
using System.Collections;

	[System.Serializable]
	public class Entity{		
		public string name; 
		public int victories;
		public int defeats;
		public int agility;
		public int resistance;
		public int power;
		public int jabaticity;
		public int atributes;
		public int rank;
		public Habilities hability;



		public Entity(){
			this.name = "";
			this.victories = 0;
			this.defeats = 0;
			this.agility = 0;
			this.resistance = 0;
			this.power = 0;
			this.jabaticity = 99;
			this.atributes= 0;
			this.rank = 5;
			this.hability = new Habilities("Ninguna","No dispones de habilidad",0,0);
		}

	}


	/*
	 * Habilidad1 -> Rotar jugadores.
	 * Habilidad2 -> Enamorar.
	 * Habilidad3 -> Cegar.
	 * Habilidad4 -> Invisible.
	 * Habilidad5 -> Parar el tiempo.
	 */

