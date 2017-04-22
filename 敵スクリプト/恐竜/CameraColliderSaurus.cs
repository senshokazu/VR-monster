using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CameraColliderSaurus : MonoBehaviour {
	public GameObject MoveStopCollider;
	public GameObject dive_Camera;
	public GameObject Hand;
	public GameObject Saurus;
	GameObject sword;
	SphereCollider swordsphere;
	public RayManager raymanager;
	Animator anim,SaurusMotion;
	public bool Slashmotion;
	public bool SaurusAttackMotion;
	public HandController handcontroller;
	public  EnemyGhost enemyslime;
	// Use this for initialization

	void Start () {
		anim = Hand.GetComponent<Animator> ();
		SaurusMotion = Saurus.GetComponent<Animator> ();
		sword = GameObject.FindWithTag ("Sword");
		swordsphere = sword.GetComponent<SphereCollider>();
		swordsphere.enabled = false;
		Slashmotion = false;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (dive_Camera.transform.position.x, dive_Camera.transform.position.y, dive_Camera.transform.position.z);
		transform.eulerAngles = new Vector3 (0,dive_Camera.transform.eulerAngles.y,0);
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag=="CameraMoveStop") {
		Slashmotion = true;
	    anim.SetBool ("Slash", true);
		SaurusAttackMotion = true;
		raymanager.Movestop = true;
		StartCoroutine ("Slasha");
		StartCoroutine ("CEnemyAttack");
		}	
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "CameraMoveStop") {
			swordsphere.enabled = false;
			anim.SetBool ("Slash", false);
			raymanager.Movestop = false;
			Slashmotion = false;
			SaurusAttackMotion = false;
			SaurusMotion.SetBool ("SaurusRun", true);
		}
	}

	IEnumerator Slasha(){

		while (true) {
			if (Slashmotion == true) {
				Invoke ("swordspheretrue", 0.45f);
				Invoke ("swordspherefalse", 0.50f);
				yield return new WaitForSeconds (1.166667f);
			}
			if (Slashmotion == false) {
				break;
			}
		}
	}
		
	void swordspheretrue(){
		swordsphere.enabled = true;
	}

	void swordspherefalse(){
		swordsphere.enabled = false;
	}
		
}




