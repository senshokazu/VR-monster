using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gamestartt : MonoBehaviour {
	public Camera cameraa;
	// Use this for initialization
	void Start () {
		
	}
	void Update(){
		// Update is called once per frame
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Began)
			{

				Ray ray = cameraa.ScreenPointToRay (touch.position);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					//reticle.rectTransform.position = hit.point;
					if (hit.collider.gameObject.tag == "Button") {
						Application.LoadLevel("Green1-1");
					}
			}

		}
	}

	}
}
