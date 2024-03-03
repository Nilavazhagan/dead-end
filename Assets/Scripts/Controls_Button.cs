using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Controls_Button : MonoBehaviour {
	public Image img;
	public Sprite bck1;
	public Sprite bck2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Toggle> ().isOn == true)
			img.sprite = bck2;
		else
			img.sprite = bck1;
	}
}
