﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Animator anim;
	GameObject sword;
	//SphereCollider swordCollider;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		sword = GameObject.Find ("cutter01");
		//swordCollider = sword.GetComponent<SphereCollider> ();
		IsAttackingToFalse ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Invoke ("IsAttackingToTrue", 0.58f);
			anim.SetTrigger ("Attack");
			Invoke ("IsAttackingToFalse", 0.8f);
		}
	}
	void IsAttackingToFalse(){
	//	swordCollider.enabled = false;
	}
	void IsAttackingToTrue(){
		//swordCollider.enabled = true;
	}
}
