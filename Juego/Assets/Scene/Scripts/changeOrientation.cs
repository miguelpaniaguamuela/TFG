using UnityEngine;
using System.Collections;

public class changeOrientation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Destroy(GameObject.Find("sound"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
