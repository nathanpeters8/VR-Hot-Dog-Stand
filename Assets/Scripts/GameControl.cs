using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	private GameObject[] characters;
	public GameObject charController;
	public float[] startXPos = new float[] {-24f, 24f};
	private float elapsedTime;
	public float timeToInstantiate = 30f; 
	private int randNum;
	private bool fromRight;
	// Use this for initialization
	void Start () {	
		elapsedTime = 1f;
		randNum = Random.Range(0, 2);
		charController.GetComponent<InstantiateAI>().InstantiateRandomCharacter(startXPos[randNum]);
	}
	
	// Update is called once per frame
	void Update () {
		characters = GameObject.FindGameObjectsWithTag("AI");
		elapsedTime += Time.deltaTime;
		if(randNum == 0)
			randNum = 1;
		else
			randNum = 0;
		if(characters.Length < 2 && (Mathf.RoundToInt(elapsedTime) % Mathf.RoundToInt(timeToInstantiate) == 0)) {
			if(characters.Length == 1) {
				fromRight = characters[0].GetComponent<AIControl>().fromRight;
				if(fromRight)
					charController.GetComponent<InstantiateAI>().InstantiateRandomCharacter(startXPos[0]);
				else
					charController.GetComponent<InstantiateAI>().InstantiateRandomCharacter(startXPos[1]);
				Debug.Log("spawn character");
			}
			else if(characters.Length == 0) {
				randNum = Random.Range(0, 2);
				charController.GetComponent<InstantiateAI>().InstantiateRandomCharacter(startXPos[randNum]);
				Debug.Log("spawn character.");
			}
		}
	}
}
