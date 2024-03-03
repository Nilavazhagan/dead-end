using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class Life_Script : MonoBehaviour {
	public GameObject[] Lives;
	public static int count = 5;
	bool done = false;
	bool done1;
	DateTime curTime;
	DateTime oldTime;
	string s;
	long temp;
	public Text disp;
	TimeSpan t;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("count") && (PlayerPrefs.GetInt ("game_start") == 1)) {
			count = PlayerPrefs.GetInt ("count");
			PlayerPrefs.SetInt ("game_start", 0);
		}
		else if (!PlayerPrefs.HasKey ("first_time")) {
			count = 5;
			PlayerPrefs.SetInt ("first_time", 0);
		}
		for (int i = 0; i < count; i++)
			Lives [i].SetActive(true);
		if (count == 0) {
			disp.text = "You Have No Lives Left.\nCome Back later.";
			oldTime  = DateTime.Parse(PlayerPrefs.GetString("time"));
			curTime = System.DateTime.Now;
			//t = curTime - oldTime;
			if (curTime.CompareTo(oldTime)==0) {
				count = 5;
				for (int i = 0; i < count; i++)
					Lives [i].SetActive (true);
			}
		}
	}

	void Awake(){
		DontDestroyOnLoad (this);
		/*done = false;
		if (PlayerPrefs.HasKey ("count") && (PlayerPrefs.GetInt ("game_start") == 1)) {
			count = PlayerPrefs.GetInt ("count");
			PlayerPrefs.SetInt ("game_start", 0);
		}
		else if (!PlayerPrefs.HasKey ("first_time")) {
			count = 5;
			PlayerPrefs.SetInt ("first_time", 0);
		}
		for (int i = 0; i < count; i++)
			Lives [i].SetActive(true);
		if (count == 0) {
			disp.text = "You Have No Lives Left.\nCome Back later.";
			oldTime  = DateTime.Parse(PlayerPrefs.GetString("time"));
			curTime = System.DateTime.Now;
			//t = curTime - oldTime;
			if (curTime.CompareTo(oldTime)==0) {
				count = 5;
				for (int i = 0; i < count; i++)
					Lives [i].SetActive (true);
			}
		}*/
	}
	// Update is called once per frame
	void Update () {
		if (PlayerController.dead) {
			if (done == false && count>0) {
				done = true;
				curTime = System.DateTime.Now;
				curTime.AddHours (1.0);
				//s = timestring + count;
				PlayerPrefs.SetString ("time",curTime.ToString());
				Lives [count - 1].SetActive (false);
				count--;
			}
		}
		/*if (count < 5) {
			s = timestring + (count+1);
			temp = Convert.ToInt64 (PlayerPrefs.GetString (s));
			oldTime = DateTime.FromBinary (temp);
			curTime = System.DateTime.Now;
			diffmin = curTime.Minute - oldTime.Minute;
			done1 = false;
			if (diffmin >= 20 && done1 == false) {
				done1 = true;
				Lives [count].SetActive (true);
				count++;
				s = timestring + (count+1);
				PlayerPrefs.SetString (s,curTime.ToBinary().ToString());
			}
		}*/
		if (count == 0) {
			disp.text = "You Have No Lives Left.\nCome Back later.";
			oldTime  = DateTime.Parse(PlayerPrefs.GetString("time"));
			curTime = System.DateTime.Now;
			//t = curTime - oldTime;
			if (curTime.CompareTo(oldTime)==0) {
				count = 5;
				for (int i = 0; i < count; i++)
					Lives [i].SetActive (true);
			}
		}
	}

	void OnApplicationQuit(){
		PlayerPrefs.SetInt ("count", count);
		PlayerPrefs.SetInt ("game_start", 1);
	}
}
