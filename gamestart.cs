using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gamestart : MonoBehaviour {
	public Camera cameraa;
	public AudioClip audioClip;
	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = audioClip;
		audioSource.Play ();
	}
	void Update(){
		// Update is called once per frame
		if (Input.touchCount > 0)//タッチされた回数
		{
			print ("0");
			Touch touch = Input.GetTouch(0);//Input.GetTouch.phaseはタップ状態をあらわす
			if(touch.phase == TouchPhase.Began)
			{
				
				Vector2 point = touch.position;
				RaycastHit hit;
				Ray ray = cameraa.ScreenPointToRay (point);
				if (Physics.Raycast (ray, out hit)) {
					
					//reticle.rectTransform.position = hit.point;
					if (hit.collider.gameObject.tag == "Button") {
						Application.LoadLevel("Wait");
					}
				}

			}
		}

	}
}
