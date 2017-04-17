/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
	Animator anim;
	Animator anim2;
	BoxCollider boxCollider;
	public int hp = 100;
	public Image hpGauge;
	int fullHp;
	int attackPower;
	GameObject hpObj;
	public GameObject Saurus;
	public RayManager raymanager;
	public GameObject Hand;
	public CameraCollider cameracollider;


	// Use this for initialization
	void Start () {
		anim = Saurus.GetComponent<Animator> ();
		anim2 = Hand.GetComponent<Animator> ();
		boxCollider = GetComponent<BoxCollider> ();
		hpObj = transform.Find ("HP").gameObject;
		fullHp = hp;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("SaurusBool", true);
		AnimatorStateInfo current = anim.GetCurrentAnimatorStateInfo (0);
		float duration = current.length;
		print ("" + duration);
	}
	void OnTriggerEnter(Collider other){
		if (other.name == "test_sword") {
			attackPower = other.GetComponent<Weapon> ().power;
			hp -= attackPower;
			hpGauge.fillAmount = (float)hp / fullHp; //(float)型変換
			print (hp);
			if (hp <= 0) {
				cameracollider.Slashmotion = false;
				anim.Play ("Allosaurus_Die");
				anim2.SetBool ("Slash", false);
				Destroy (boxCollider);
				Invoke ("destroysaurus", 3.5f);
				Destroy (hpObj);
			}
		}
	}

	void destroysaurus(){
		Destroy (this.gameObject);
		raymanager.Movestop = false;

	}

}

*/