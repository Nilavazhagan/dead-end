using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	GameObject[] spawn_points;
	int length;
	int rand;
	Transform pos;
	public GameObject player;
	// Use this for initialization
	void Start () {
		spawn_points = GameObject.FindGameObjectsWithTag ("Respawn");
		length = spawn_points.Length;
		rand = Random.Range (0, length);
		pos = spawn_points [rand].transform;
		Instantiate (player, pos.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
