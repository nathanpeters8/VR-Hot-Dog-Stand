using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmulateMovement : MonoBehaviour {

	public float speed;
	private Vector3 moveDirection = Vector3.zero;

	void Awake() {
		this.transform.position = new Vector3(0f, 1.7f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log(Input.GetAxis("Horizontal"));
		// if(Input.GetAxis("Horizontal") < 0) {
		// 	moveDirection = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
		// 	moveDirection *= speed;
		// }
		// else if(Input.GetAxis("Horizontal") > 0) {
		// 	moveDirection = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
		// 	moveDirection *= speed;
		// }
		Debug.Log(transform.position);
		if(Input.GetAxis("Horizontal") != 0) {
			moveDirection = new Vector3(transform.position.x + Input.GetAxis("Horizontal"), 1.7f, transform.position.z);
			moveDirection.x *= speed;
		}
		this.transform.position = moveDirection;
	}
}