using UnityEngine;
using System.Collections;

public class jabatotouch : MonoBehaviour {

	public AudioClip myclip;

	// Use this for initialization
	void Start () {
		this.gameObject.AddComponent<AudioSource> ();
		this.GetComponent<AudioSource> ().clip = myclip;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		this.GetComponent<AudioSource> ().PlayOneShot (myclip);
	}
}
