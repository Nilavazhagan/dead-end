using UnityEngine;
using System.Collections;

public class Logo_Script : MonoBehaviour {
	public AudioClip clip;
	// Use this for initialization
	void Awake () {
		this.GetComponent<Animation> () ["Default Take"].speed = 3.0f;
		this.GetComponent<Animation> ().Play ();
		this.GetComponent<AudioSource> ().PlayOneShot (clip);
		StartCoroutine (AudioOne ());
	}

	IEnumerator AudioOne(){
		yield return new WaitForSeconds (0.5f);
		this.GetComponent<AudioSource> ().PlayOneShot (clip);
	}
}
