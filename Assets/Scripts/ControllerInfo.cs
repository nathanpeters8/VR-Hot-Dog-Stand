using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerInfo : MonoBehaviour {

	public Text activeControllerText, handPositionText;
	OVRInput.Controller activeController;
	
	// Update is called once per frame
	void Update () {
		activeController = OVRInput.GetActiveController();
		transform.localPosition = OVRInput.GetLocalControllerPosition(activeController);
		transform.localRotation = OVRInput.GetLocalControllerRotation(activeController);

		activeControllerText.text = 

		"<b>ActiveController's Type:</b> " + activeController + "\n\n"
		+ "<b>ActiveController's Position:</b> "
		+ "X: " + OVRInput.GetLocalControllerPosition(activeController).x.ToString("F2") + ", "
		+ "Y: " + OVRInput.GetLocalControllerPosition(activeController).y.ToString("F2") + ", " 
		+ "Z: " + OVRInput.GetLocalControllerPosition(activeController).z.ToString("F2") + "\n\n"

		+ "<b>ActiveController's Rotation:</b> "
		+ "X: " + OVRInput.GetLocalControllerRotation(activeController).eulerAngles.x.ToString("F0") + ", "
		+ "Y: " + OVRInput.GetLocalControllerRotation(activeController).eulerAngles.y.ToString("F0") + ", "
		+ "Z: " + OVRInput.GetLocalControllerRotation(activeController).eulerAngles.z.ToString("F0") + "\n\n"

		+ "<b>MainCamera's Position:</b> "
		+ "X: " + Camera.main.transform.position.x.ToString("F2") + ", "
		+ "Y: " + Camera.main.transform.position.y.ToString("F2") + ", "
		+ "Z: " + Camera.main.transform.position.z.ToString("F2") + "\n\n"

		+ "<b>MainCamera's Rotation:</b> "
		+ "X: " + Camera.main.transform.rotation.eulerAngles.x.ToString("F0") + ", "
		+ "Y: " + Camera.main.transform.rotation.eulerAngles.y.ToString("F0") + ", "
		+ "Z: " + Camera.main.transform.rotation.eulerAngles.z.ToString("F0");


		handPositionText.text = 

		"<b>Hand GameObject's Local Position:</b> "
		+ "X: " + transform.localPosition.x.ToString("F2") + ", "
		+ "Y: " + transform.localPosition.y.ToString("F2") + ", "
		+ "Z: " + transform.localPosition.z.ToString("F2") + ", "

		+ "<b>Hand GameObject's Local Rotation:</b> "
		+ "X: " + transform.localRotation.eulerAngles.x.ToString("F0") + ", "
		+ "Y: " + transform.localRotation.eulerAngles.y.ToString("F0") + ", "
		+ "Z: " + transform.localRotation.eulerAngles.z.ToString("F0") + "\n\n"

		+ "<b>Hand GameObject's Global Position:</b> "
		+ "X: " + transform.position.x.ToString("F2") + ", "
		+ "Y: " + transform.position.y.ToString("F2") + ", "
		+ "Z: " + transform.position.z.ToString("F2") + "\n\n"

		+ "<b>Hand GameObject's Global Rotation:</b> " 
		+ "X: " + transform.rotation.eulerAngles.x.ToString("F0") + ", "
		+ "Y: " + transform.rotation.eulerAngles.y.ToString("F0") + ", "
		+ "Z: " + transform.rotation.eulerAngles.z.ToString("F0") + "\n\n"

		+ "<b>Hand GameObject's Parent's Global Position:</b> "
		+ "X: " + transform.parent.position.x.ToString("F2") + ", "
		+ "Y: " + transform.parent.position.y.ToString("F2") + ", "
		+ "Z: " + transform.parent.position.z.ToString("F2") + "\n\n"

		+ "<b>Hand GameObject's Parent's Global Rotation:</b> "
		+ "X: " + transform.parent.rotation.eulerAngles.x.ToString("F2") + ", "
		+ "Y: " + transform.parent.rotation.eulerAngles.y.ToString("F2") + ", "
		+ "Z: " + transform.parent.rotation.eulerAngles.z.ToString("F2");
 	}
}
