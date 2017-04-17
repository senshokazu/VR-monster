using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CameraCollider : MonoBehaviour {
	public GameObject MoveStopCollider;
	public GameObject dive_Camera;
	public GameObject Hand;
	public GameObject EnemyHit;
	GameObject sword;
	SphereCollider swordsphere;
	public RayManager raymanager;
	Animator anim;
	public bool Slashmotion;
	public HandController handcontroller;
	ParticleSystem SlashEffect;
	public AudioClip SlashSound;
	AudioSource audiosource;
	public Image image;
	public Text text;
	// Use this for initialization

	void Start () {
		audiosource = gameObject.GetComponent<AudioSource> ();
		audiosource.clip = SlashSound;
		SlashEffect = EnemyHit.GetComponent<ParticleSystem> ();
		anim = Hand.GetComponent<Animator> ();
		sword = GameObject.FindWithTag ("Sword");
		swordsphere = sword.GetComponent<SphereCollider>();
		swordsphere.enabled = false;
		Slashmotion = false;
		SlashEffect.Clear ();

	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3 (dive_Camera.transform.position.x, dive_Camera.transform.position.y, dive_Camera.transform.position.z);
		transform.eulerAngles = new Vector3 (0,dive_Camera.transform.eulerAngles.y,0);

	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag=="CameraMoveStop") {
		Slashmotion = true;
		if (MoveStopCollider == null) {
		anim.SetBool ("Slash", false);
		}
	    anim.SetBool ("Slash", true);
		raymanager.Movestop = true;
		StartCoroutine ("Slasha");
		}	
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "CameraMoveStop") {
			StopCoroutine ("Slasha");
			swordsphere.enabled = false;
			anim.SetBool ("Slash", false);
			raymanager.Movestop = false;
			Slashmotion = false;
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
		if (EnemyHit == null) {
			return;
		} else {
			audiosource.Play ();
			SlashEffect.Play ();
			swordsphere.enabled = true;
		}
	}

	void swordspherefalse(){
		swordsphere.enabled = false;
		Invoke ("SlashEffectClear", 0.5f);
	}

	void SlashEffectClear(){
		if (EnemyHit == null) {
			return;
		} else {
			SlashEffect.Clear ();
		}
	}
		
}



