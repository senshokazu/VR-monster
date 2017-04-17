using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChange2 : MonoBehaviour {
	public GameObject MoveStopCollider;
	public Image NextStage;
	public Text text;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (MoveStopCollider == null) {
			NextStage.enabled = true;
			text.enabled = true;
			Invoke ("Scene",6.0f);
		}
	}

	void Scene(){
		NextStage.enabled = false;
		text.enabled = false;
		Application.LoadLevel("Green1-3");

	}
}
