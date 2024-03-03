using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CameraRotation : MonoBehaviour {
	public float rotForce = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (PlayerPrefs.GetInt ("Controls") == 0) {
		Vector3 rotYVec = new Vector3 (-CrossPlatformInputManager.GetAxis ("Vertical"), CrossPlatformInputManager.GetAxis("Horizontal"), 0) * rotForce;
		rotYVec.y = 0;
		float rotx = rotYVec.x;
		Quaternion xq = Quaternion.AngleAxis (rotx, Vector3.right);
		if(Mathf.Abs(Mathf.Tan(transform.rotation.x))<1)	
		transform.localRotation *= xq;
			}

		if (PlayerPrefs.GetInt ("Controls") == 1) {
			#if UNITY_EDITOR
			Vector3 rotYVec = new Vector3 (-Input.GetAxis ("Vertical"), Input.GetAxis("Horizontal"), 0) * rotForce;
			rotYVec.y = 0;
			float rotx = rotYVec.x;
			Quaternion xq = Quaternion.AngleAxis (rotx, Vector3.right);
			if(Mathf.Abs(Mathf.Tan(transform.rotation.x))<1)	
				transform.localRotation *= xq;
			#endif
			#if UNITY_ANDROID
			Vector3 rotYVec2 = new Vector3 (Input.acceleration.y, Input.acceleration.x, 0) * rotForce;
			rotYVec2.y = 0;
			float rotx2 = rotYVec2.x;
			Quaternion xq2 = Quaternion.AngleAxis (rotx2, Vector3.right);
			if(Mathf.Abs(Mathf.Tan(transform.rotation.x))<1)	
				transform.localRotation *= xq2;
			#endif
		}
	}

}
