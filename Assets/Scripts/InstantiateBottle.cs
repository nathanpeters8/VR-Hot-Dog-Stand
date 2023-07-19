using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBottle : MonoBehaviour {

	public GameObject ketchupBottle;
	public GameObject mustardBottle;
	private GameObject ketchupInstance;
	private GameObject mustardInstance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ketchupInstance = ketchupBottle;
		mustardInstance = mustardBottle;
		if(ketchupInstance.transform.position.y < -3f) {
			ketchupInstance = Instantiate(ketchupBottle, new Vector3(1f, 0.3f, 2.05f), Quaternion.identity);
			Destroy(ketchupInstance);

		}
		if(mustardInstance.transform.position.y < -3f) {
			mustardInstance = Instantiate(mustardBottle, new Vector3(2f, 0.3f, 2.05f), Quaternion.identity);
			Destroy(ketchupInstance);
		}
	}
}
