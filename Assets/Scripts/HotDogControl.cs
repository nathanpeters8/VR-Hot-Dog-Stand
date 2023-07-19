using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDogControl : MonoBehaviour {
	public bool isGrabbing;

	void Update() {
		isGrabbing = GameObject.FindWithTag("GameController").GetComponent<EmulateGrab1>().isGrabbing;
	}

	void OnTriggerEnter(Collider other) {
		// Debug.Log("Hot dog is in trigger zone");
		if(!isGrabbing) {
			transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 0.1f, other.transform.position.z);
			this.transform.SetParent(other.transform);
			this.transform.SetAsFirstSibling();
		}
	}
}
