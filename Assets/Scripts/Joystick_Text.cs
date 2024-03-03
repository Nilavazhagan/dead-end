using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Joystick_Text : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("Controls") == 1)
			this.GetComponent<Text> ().text = "Use Joystick to Move";
		if(PlayerPrefs.GetInt("Controls") == 0)
			this.GetComponent<Text> ().text = "Use Joystick to Look Around";		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("Controls") == 1)
			this.GetComponent<Text> ().text = "Use Joystick to Move";
		if(PlayerPrefs.GetInt("Controls") == 0)
			this.GetComponent<Text> ().text = "Use Joystick to Look Around";		
	}
}
