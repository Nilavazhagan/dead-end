using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	Rigidbody rbody;
	public GameObject cam;
	public float moveForce = 0.005f;
	public float rotForce = 5f;
	GameObject display;
	public static bool dead = false;
	void Start () {
		rbody = this.GetComponent<Rigidbody> ();

	}

	void Awake(){
		display = GameObject.FindGameObjectWithTag ("Display"); 
	}

	void FixedUpdate () {
		if(Life_Script.count>0){
		if (PlayerPrefs.GetInt ("Controls") == 0) {
			Vector3 rotXVec = new Vector3 (-CrossPlatformInputManager.GetAxis ("Vertical"), CrossPlatformInputManager.GetAxis ("Horizontal"), 0) * rotForce;
			rotXVec.x = 0;
			Quaternion deltarotation = Quaternion.Euler (rotXVec * Time.maximumDeltaTime);
			rbody.MoveRotation (rbody.rotation * deltarotation);

			#if UNITY_EDITOR
			if (Input.GetAxis ("Horizontal") > 0.1f)
				transform.position += transform.right * moveForce * Time.deltaTime;
			if (Input.GetAxis ("Horizontal") < -0.1f)
				transform.position += -transform.right * moveForce * Time.deltaTime;
			if (Input.GetAxis ("Vertical") > 0.1f)
				transform.position += transform.forward * moveForce * Time.deltaTime;
			if (Input.GetAxis ("Vertical") < -0.1f)
				transform.position += -transform.forward * moveForce * Time.deltaTime;
			#endif

			#if UNITY_ANDROID
			if (Input.acceleration.x > 0.1f)
				transform.position += transform.right * moveForce * Time.deltaTime;
			if (Input.acceleration.x < -0.1f)
				transform.position += -transform.right * moveForce * Time.deltaTime;
			if (Input.acceleration.y > 0.1f)
				transform.position += transform.forward * moveForce * Time.deltaTime;
			if (Input.acceleration.y < -0.1f)
				transform.position += -transform.forward * moveForce * Time.deltaTime;
			#endif
		}

		if (PlayerPrefs.GetInt ("Controls") == 1) {
			if (CrossPlatformInputManager.GetAxis ("Horizontal") > 0.1f)
				transform.position += transform.right * moveForce * Time.deltaTime;
			if (CrossPlatformInputManager.GetAxis ("Horizontal") < -0.1f)
				transform.position += -transform.right * moveForce * Time.deltaTime;
			if (CrossPlatformInputManager.GetAxis ("Vertical") > 0.1f)
				transform.position += transform.forward * moveForce * Time.deltaTime;
			if (CrossPlatformInputManager.GetAxis ("Vertical") < -0.1f)
				transform.position += -transform.forward * moveForce * Time.deltaTime;
			#if UNITY_EDITOR
			Vector3 rotXVec = new Vector3 (-Input.GetAxis ("Vertical"), Input.GetAxis ("Horizontal"), 0) * rotForce;
			rotXVec.x = 0;
			Quaternion deltarotation = Quaternion.Euler (rotXVec * Time.maximumDeltaTime);
			rbody.MoveRotation (rbody.rotation * deltarotation);
			#endif
			#if UNITY_ANDROID
			Vector3 rotXVec2 = new Vector3 (-Input.acceleration.y, Input.acceleration.x, 0) * rotForce;
			rotXVec2.x = 0;
			Quaternion deltarotation2= Quaternion.Euler (rotXVec2 * Time.maximumDeltaTime);
			rbody.MoveRotation (rbody.rotation * deltarotation2);
			#endif
		}
	}
}
	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Finish")) {
			Switch_Level ();
			Debug.Log ("WIN");
		}
		if (other.CompareTag ("End")) {
			dead = true;
			display.GetComponent<Text> ().text = "GAME OVER";
			StartCoroutine (Delay ());
			Debug.Log ("LOSE");
		}
	}

	void Switch_Level(){
		int index = SceneManager.GetActiveScene ().buildIndex;
		PlayerPrefs.SetInt ("Finished_Level", index);
		SceneManager.LoadScene (index + 1);
	}

	void Reload(){
		int index = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (index);
	}

	IEnumerator Delay(){
		yield return new WaitForSeconds (3f);
		dead = false;
		Reload ();
	}

}