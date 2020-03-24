using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	Transform player;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player(Clone)").GetComponent<Transform>();
		offset = new Vector3(0, .25f, 0) - player.transform.position;
		transform.position = offset;
		transform.LookAt(player);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
		
	}
}
