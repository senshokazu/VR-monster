using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Wait : MonoBehaviour {
	float time = 10.0f;
	public Image image;
	public Text text;
	// Use this for initialization
	void Start () {
		image.enabled = true;
		text.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time < 0) {
			Application.LoadLevel ("Green1-1");
			image.enabled = false;
			text.enabled = false;
		}
	}
}
