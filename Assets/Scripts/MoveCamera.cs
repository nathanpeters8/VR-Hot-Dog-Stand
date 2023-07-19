using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	public GameObject ovrCameraRig;
	public float speed;
	public float translation;
	OVRInput.Controller activeController;
	// Use this for initialization
	void Start () {
		activeController = OVRInput.GetActiveController();
	}
	
	// Update is called once per frame
	void Update () {
		activeController = OVRInput.GetActiveController();
		if(Input.GetAxis("Horizontal") < 0f || OVRInput.Get(OVRInput.Button.Left)) {
			ovrCameraRig.transform.Translate(-0.5f * Time.deltaTime * speed, 0f, 0f);
		}
		if(Input.GetAxis("Horizontal") > 0f || OVRInput.Get(OVRInput.Button.Right)) {
			ovrCameraRig.transform.Translate(0.5f * Time.deltaTime * speed, 0f, 0f);
		}
		// translation = ovrCameraRight.Translate(Input.GetAxis("Horizontal"))
	}
}
