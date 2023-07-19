using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAI : MonoBehaviour {

	public GameObject[] characters;
	public float[] startXPos = new float[] {-24f, 24f};
	private float xPos;
	private float yRot;
	public GameObject character;
	// Use this for initialization
	void Start () {
		// InstantiateRandomCharacter(startXPos[0]);
		// InstantiateRandomCharacter(startXPos[1]);
	}

	public void InstantiateRandomCharacter(float xPos) {
		// xPos = startXPos[Random.Range(0, 2)];
		Debug.Log(xPos);
		if(xPos < 0f) {
			yRot = 90f;
		}
		else {
			yRot = 270f;
		}
		character = characters[Random.Range(0, 4)];
		Instantiate(character, new Vector3(xPos, -2.7f, 7.8f), Quaternion.Euler(0f, yRot, 0f));

	}
}
