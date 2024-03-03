using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hide : MonoBehaviour {
	float time = 5f;
	public GameObject[] Intro;
	public Text disp;
	public Toggle Control_A;
	public Toggle Control_B;
	// Use this for initialization

	void Start () {
		
		//if (PlayerPrefs.GetString ("Tutorial").Equals("No"))
		//	Hide_Intro ();
		if (SceneManager.GetActiveScene ().buildIndex != 1)
			Hide_Intro ();
		if (PlayerPrefs.GetInt ("Controls") == 0)
			Control_A.GetComponent<Toggle> ().isOn = true;
		if (PlayerPrefs.GetInt ("Controls") == 1)
			Control_B.GetComponent<Toggle> ().isOn = true;
		disp.text = "Level " + SceneManager.GetActiveScene ().buildIndex.ToString();
	}
	
	void Awake(){
		disp.text = "Level " + SceneManager.GetActiveScene ().buildIndex.ToString();
	}
	// Update is called once per frame
	void Update () {
		//timer
		time -= Time.deltaTime;
		if (time < 0) {
			Hide_Intro ();
			PlayerPrefs.SetString ("Tutorial", "No");
			disp.text = "";
		}
		//end_timer
		if (PlayerController.dead) {
			disp.text = "GAME OVER";
		}
	}
	void Hide_Intro(){
		for (int i = 0; i < Intro.Length; i++)
			Intro [i].SetActive (false);

	}
}
