using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCrate : MonoBehaviour {

	public GameObject crateItem;
	private Transform crateTransform;

	void Start() {
		crateTransform = this.gameObject.transform;
	}

	public void InstantiateItem() {
		Debug.Log("crate was selected.");
		Instantiate(crateItem, new Vector3(crateTransform.position.x, crateTransform.position.y, crateTransform.position.z - 0.5f), Quaternion.Euler(0f, 180f, 0f));
	}
}