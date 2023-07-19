using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrackScores : MonoBehaviour {

	public TextMeshProUGUI correctScoreText;
	public TextMeshProUGUI wrongScoreText;
	private int correctScore = 0;
	private int wrongScore = 0;
	private GameObject[] characters;
	private bool correctOrder;
	private bool inTrigger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void GetScore() {
		characters = GameObject.FindGameObjectsWithTag("AI");
		if(characters.Length != 0) {
			foreach(GameObject character in characters) {
				inTrigger = character.GetComponent<CheckOrder>().inTrigger;
				if(inTrigger == true) {
					Debug.Log("In trigger");
					correctOrder = character.GetComponent<CheckOrder>().correctOrder;
					if(correctOrder) {
						correctScore += 1;
						correctScoreText.text = correctScore.ToString("f0");
						// inTrigger = false;
					}
					else {
						wrongScore += 1;
						wrongScoreText.text = wrongScore.ToString("f0");
						// inTrigger = false;
					}
				}
				// Debug.Log("Out of trigger");
			}
		}
	}
}
