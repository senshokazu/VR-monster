using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayManager : MonoBehaviour {
	public GameObject dive_Camera;
	public Image reticle;
	public float speed ;
	public bool Movestop = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RayMove ();
	}
		
	void RayMove(){//rayがhitしたオブジェクトに向かって移動するメソッド
		if (Movestop == false) {
			Ray ray = new Ray (dive_Camera.transform.position, dive_Camera.transform.forward);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				//reticle.rectTransform.position = hit.point;
					if (hit.collider.gameObject.tag == "Raymove" && dive_Camera.transform.eulerAngles.x >= 4) {
						dive_Camera.transform.position += ((new Vector3 (hit.point.x, 1.5f, hit.point.z) - new Vector3 (dive_Camera.transform.position.x, 1.5f, dive_Camera.transform.position.z))).normalized * Time.deltaTime * speed;
					}
			} 
		}
	}

}
