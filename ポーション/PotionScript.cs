using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour {
	Animation anim;
	bool Heal;
	public GameObject dive_Camera;
	public GameObject ring;
	public HandController handcontroller;
	ParticleSystem particlesystem;
	public AudioClip SlashSound;
	AudioSource audiosource;
	// Use this for initialization
	void Start () {
		audiosource = GetComponent<AudioSource> ();
		audiosource.clip = SlashSound;
		anim = GetComponent<Animation> ();
		particlesystem = ring.GetComponent<ParticleSystem> ();
		particlesystem.Clear ();
	}
	
	// Update is called once per frame
	void Update () {

		if (handcontroller.hp == handcontroller.fullhp)
			Heal = false;
		else
			Heal = true;
	}

		void OnTriggerEnter(Collider other) {
		if (other.name == "CameraCollider" && Heal==true) {
			handcontroller.hp += handcontroller.fullhp / 3;
			if (handcontroller.hp > handcontroller.fullhp) {
				handcontroller.hp = handcontroller.fullhp;
			}
			handcontroller.HpGauge.fillAmount = (float)handcontroller.hp / handcontroller.fullhp;
			Destroy (this.gameObject);
			particlesystem.Play ();
			audiosource.Play ();
		}
	}
}
