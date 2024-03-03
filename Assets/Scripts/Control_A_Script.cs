using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Control_A_Script : MonoBehaviour {
	public Toggle Control_B;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<Toggle> ().isOn == true) {
			PlayerPrefs.SetInt ("Controls", 0);
		}
	}
}
