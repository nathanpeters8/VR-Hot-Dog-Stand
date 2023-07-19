using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondimentControl : MonoBehaviour {

	public GameObject condiment;
	public bool isGrabbing;
	public bool leftClick;
	private GameObject c;
	private Vector3 hotDogPos;
	private string condimentName;
	private float rotValue;
	// Use this for initialization
	void Start () {
		condimentName = condiment.name;
	}
	
	// Update is called once per frame
	void Update () {
		leftClick = false;
		isGrabbing = GameObject.FindWithTag("GameController").GetComponent<EmulateGrab1>().isGrabbing;
		if(Input.GetMouseButtonDown(1) || OVRInput.GetUp(OVRInput.Button.Two)) {
			leftClick = true;
		}
	}

	void OnTriggerStay(Collider other) {
		if(other.transform.GetChild(0).gameObject.tag == "Grabbable") {
			// Debug.Log("Hot dog in bun.");
			hotDogPos = other.transform.GetChild(0).position;
			if(isGrabbing && leftClick) {
				if(condimentName.ToLower().StartsWith("m")) {
					rotValue = 270f;
				}
				else if(condimentName.ToLower().StartsWith("k")) {
					rotValue = 90f;
				}
				c = Instantiate(condiment, new Vector3(hotDogPos.x, hotDogPos.y - 0.05f, hotDogPos.z), Quaternion.Euler(0f, rotValue, 0f));
				c.transform.SetParent(other.transform);
				c.transform.SetSiblingIndex(1);
				c.tag = condimentName;
			}
		}
		else {
			// Debug.Log("Hot dog not in bun.");
		}
	}
}
