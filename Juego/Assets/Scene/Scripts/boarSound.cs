using UnityEngine;
using System.Collections;

public class boarSound : MonoBehaviour {

	private static boarSound instance = null;
	public AudioClip myclip;

	public static boarSound Instance{
		get{ return instance; }
	}

	// Use this for initialization
	void Start () {

		this.gameObject.AddComponent<AudioSource> ();
		this.GetComponent<AudioSource> ().clip = myclip;
	
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

	public void soundshoot() {

		this.GetComponent<AudioSource> ().PlayOneShot (myclip);

	}
}
