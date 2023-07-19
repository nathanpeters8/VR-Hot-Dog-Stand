using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cook : MonoBehaviour {

	public ParticleSystem particles;
	private bool onGrill;
	private Renderer hotDogRenderer;
	public int cookDelay;
	public TextMeshProUGUI timerText;
	private float elapsedTime;
	private float colorValue;
	private int timerValue;
	private Color c;
	// private float timeOnGrill;

	void Start() {
		particles.enableEmission = false;
		onGrill = false;
		hotDogRenderer = this.gameObject.GetComponent<Renderer>();
		elapsedTime = 0f;
		colorValue = 1f;
		timerValue = 20;
		// timeOnGrill = 0f;
		// hand = GameObject.FindWithTag("GameController");
	}

	void Update() {
		if(onGrill) {
			elapsedTime += Time.deltaTime;
			// timeOnGrill += Time.deltaTime;
			// Debug.Log(timeOnGrill);
			if(elapsedTime >= 1f && timerValue >= 0) {
				elapsedTime = elapsedTime % 1f;
				colorValue -= 0.1f;
				timerValue -= 1;
				CookHotDog(colorValue);
				RunTimer(timerValue);
			}
		}
		else {
			elapsedTime = 0f;
			timerValue = 20;
			// RunTimer(timerValue);
		}
		// Debug.Log(hotDogRenderer.material.color);
	}
	
	public void OnCollisionStay(Collision other) {
		if(other.gameObject.CompareTag("Grill")) {
			onGrill = true;
			particles.enableEmission = true;
			particles.Play();
		}
	}

	public void OnCollisionExit(Collision other) {
		if(other.gameObject.CompareTag("Grill")) {
			onGrill = false;
			Debug.Log("hot dog not on grill.");
			particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
		}
	}

	public void CookHotDog(float value) {
		c = hotDogRenderer.material.color;
		c.r = value;
		c.g = value;
		c.b = value;
		hotDogRenderer.material.color = c;
		// Debug.Log(c.r);	
	}

	public void RunTimer(float value) {
		if(value < 10 && value > 0) {
			timerText.text = "0:0" + value.ToString("f0");
		}
		else if(value >= 10) {
			timerText.text = "0:" + value.ToString("f0");
		}
		else if(value == 0) {
			timerText.text = "0:00";
		}
		Debug.Log(timerText.text);
	}
}
