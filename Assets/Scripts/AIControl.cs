using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour {

	public float speed = 1f;
	public float rotateSpeed = 10f;
	private Animator animator;
	public bool fromRight;
	private bool orderChoosen = false;
	public bool done = false;
	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator>();
		// this.gameObject.GetComponent<GetRandomOrder>().RandomOrder();
		if(transform.position.x == 24f) {
			fromRight = true;
		}
		else if(transform.position.x == -24f) {
			fromRight = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(fromRight) {
			MoveCharacterFromRight();
		}
		else {
			MoveCharacterFromLeft();
		}
		if(!orderChoosen) {
			// Debug.Log("order choosen.");
			this.gameObject.GetComponent<GetRandomOrder>().RandomOrder();
			orderChoosen = true;
		}
	}

	//start position = (24f, 2.7f, 7.8f)
	//start rotation = (0f, 270f, 0f)
	public void MoveCharacterFromRight() {
		if(transform.position.x >= 4f && transform.position.z > 7f) {
			animator.SetBool("Stop", false);
			transform.Translate(0f, 0f, 1f * Time.deltaTime * speed);
			// Debug.Log("Keep walking.");
		}
		else {
			// Debug.Log("player should stop.");
			animator.SetBool("Stop", true);
			transform.Translate(0f, 0f, 0f);
			if(transform.rotation.eulerAngles.y >= 180f) {
				transform.Rotate(0f, -1f * Time.deltaTime * rotateSpeed, 0f);
			}
			else {
				transform.Rotate(0f, 0f , 0f);
				animator.SetBool("Stop", false);
				if(transform.position.z >= 3.5f) {
					// Debug.Log(transform.position.z);
					transform.Translate(0f, 0f, 1f * Time.deltaTime * speed);
				}
				else {
					// Debug.Log(transform.position.z);
					animator.SetBool("Stop", true);
					transform.Translate(0f, 0f, 0f);
					return;
					// this.gameObject.GetComponent<GetRandomOrder>().RandomOrder();
				}
			}
		}
	}
	//start position = (-24f, 2.7f, 7.8f)
	//start rotation = (0f, 90f, 0f);
	public void MoveCharacterFromLeft() {
		if(transform.position.x <= -4f && transform.position.z > 7f) {
			animator.SetBool("Stop", false);
			transform.Translate(0f, 0f, 1f * Time.deltaTime * speed);
			//Debug.Log("Keep walking.");
		}
		else {
			//Debug.Log("player should stop.");
			animator.SetBool("Stop", true);
			transform.Translate(0f, 0f, 0f);
			if(transform.rotation.eulerAngles.y <= 180f) {
				transform.Rotate(0f, 1f * Time.deltaTime * rotateSpeed, 0f);
			}
			else {
				transform.Rotate(0f, 0f , 0f);
				animator.SetBool("Stop", false);
				if(transform.position.z >= 3.5f) {
					//Debug.Log(transform.position.z);
					transform.Translate(0f, 0f, 1f * Time.deltaTime * speed);
				}
				else {
					//Debug.Log(transform.position.z);
					animator.SetBool("Stop", true);
					transform.Translate(0f, 0f, 0f);
					return;
					// this.gameObject.GetComponent<GetRandomOrder>().RandomOrder();
				}
			}
		}
	}

	public void CharacterLeave() {
		done = false;
		Debug.Log("character is leaving.");
		if(transform.rotation.eulerAngles.y >= 0f) {
			Debug.Log("rotating");
			transform.Rotate(0f, 1f * Time.deltaTime * rotateSpeed, 0f);
			done = false;
		}
		else{
			animator.SetBool("Stop", false);
			done = true;
		}
	}
}
