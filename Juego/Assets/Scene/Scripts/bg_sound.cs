using UnityEngine;
using System.Collections;

public class bg_sound : MonoBehaviour {

	private static bg_sound instance = null;

	public static bg_sound Instance{
		get{ return instance; }
	}
	void Awake(){

		if(instance != null && instance !=this){
			Destroy (this.gameObject);
			return;

		}else{
			instance = this;
		}

		DontDestroyOnLoad (this.gameObject);

	}

}
