using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRandomOrder : MonoBehaviour {

	public Sprite[] images;
	private Canvas canvas;
	private Image image;
	private GameObject obj;
	private GameObject img;
	private RectTransform imgTransform;
	private RectTransform canvasTransform;
	public int randNum;
	// Use this for initialization
	void Start () {

	}


	public void RandomOrder() {
		obj = new GameObject();
		obj.name = "Canvas";
		obj.transform.SetParent(this.gameObject.transform);
		obj.AddComponent<Canvas>();
		canvas = obj.GetComponent<Canvas>();
		canvas.renderMode = RenderMode.WorldSpace;
		obj.AddComponent<CanvasScaler>();
		obj.AddComponent<GraphicRaycaster>();

		// obj.AddComponent<RectTransform>();
		canvasTransform = obj.GetComponent<RectTransform>();
		canvasTransform.localPosition = new Vector3(0f, 4.5f, 0f);
		canvasTransform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		canvasTransform.sizeDelta = new Vector2(1f, 1f);
		canvasTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);

		img = new GameObject();
		img.name = "Image";
		img.transform.parent = obj.transform;
		image = img.AddComponent<Image>();
		randNum = Random.Range(0,4);
		image.sprite = images[randNum];

		imgTransform = image.GetComponent<RectTransform>();
		imgTransform.localPosition = new Vector3(-2.5f, 1f, 0);
		imgTransform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
		imgTransform.sizeDelta = new Vector2(10f, 5f);
		imgTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
	}

}
