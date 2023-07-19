using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOrder : MonoBehaviour {

	private int randomNumber;
	public bool isGrabbing;
	public bool correctOrder;
	private bool ketchupExists = false;
	private bool mustardExists = false;
	public bool inTrigger = false;
	public GameObject scoreboardManager;
	private bool done;
	// Use this for initialization
	void Start () {
		// randomNumber = gameObject.GetComponent<GetRandomOrder>().randNum;
	}
	
	// Update is called once per frame
	void Update () {
		randomNumber = gameObject.GetComponent<GetRandomOrder>().randNum;
		isGrabbing = GameObject.FindWithTag("GameController").GetComponent<EmulateGrab1>().isGrabbing;
		scoreboardManager = GameObject.Find("Scoreboard Manager");
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Grabbable") {
			// Debug.Log("Checking order...");
			inTrigger = true;
			foreach(Transform child in other.transform) {
				// Debug.Log(child.gameObject.name);
				if(child.gameObject.tag == "Ketchup") {
					ketchupExists = true;
				}
				if(child.gameObject.tag == "Mustard") {
					mustardExists = true;
				}
			}
	
			if(randomNumber == 0) {
				if(ketchupExists == false && mustardExists == false)
					correctOrder = true;
				else
					correctOrder = false;
			}	
			else if(randomNumber == 1) {
				if(ketchupExists == true && mustardExists == false)
					correctOrder = true;
				else
					correctOrder = false;
			}	
			else if(randomNumber == 2) {
				if(ketchupExists == false && mustardExists == true)
					correctOrder = true;
				else
					correctOrder = false;
			}
			else if(randomNumber == 3) {
				if(ketchupExists == true && mustardExists == true)
					correctOrder = true;
				else
					correctOrder = false;
			}
			Debug.Log("rand num: " + randomNumber + "  correct: " + correctOrder);
			scoreboardManager.GetComponent<TrackScores>().GetScore();
			inTrigger = false;
			Destroy(other.gameObject);
			Destroy(this.gameObject);
			// done = GetComponent<AIControl>().done;
			// while(!done) {
			// 	gameObject.GetComponent<AIControl>().CharacterLeave();
			// }

		}
	}
}
