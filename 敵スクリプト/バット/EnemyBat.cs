using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBat : MonoBehaviour {
	Animator anim;
	Animator anim2;//手
	BoxCollider boxCollider;
	public int hp = 150;
	public int atacck;
	public Image hpGauge;
	int fullHp;
	int attackPower;
	GameObject hpObj;
	public RayManager raymanager;
	public GameObject Hand;
	public CameraCollider cameracollider;
	public HandController handcontroller;
	bool Batbool = false;
	Image playerImage;
	public GameObject Image;
	public GameObject EnemyHit;
	public GameObject MoveStopCollider;
	ParticleSystem SlashEffect;
	public AudioClip EnemyAttackSound;
	AudioSource audiosource;

	// Use this for initialization
	void Start () {
		//	hpObj = transform.Find ("HP").gameObject;
		audiosource = gameObject.GetComponent<AudioSource> ();
		audiosource.clip = EnemyAttackSound;
		SlashEffect = EnemyHit.GetComponent<ParticleSystem> ();
		playerImage = Image.GetComponent<Image>();
		anim = GetComponent<Animator> ();
		anim2 = Hand.GetComponent<Animator> ();
		boxCollider = GetComponent<BoxCollider> ();
		fullHp = hp;
	}

	// Update is called once per frame
	void Update () {
		//AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo (0);
		//float duration = currentState.length;
		//print (duration);
		anim.SetBool ("BatAttack", false);
		anim.SetBool ("BatRun", false);
		float x = (transform.position.x) - (cameracollider.transform.position.x);
		float z = (transform.position.z) - (cameracollider.transform.position.z);
		if ((x * x) + (z * z) < 250f&&Batbool== false) {
			transform.eulerAngles = new Vector3 (0, Mathf.Atan2 (x, z) * Mathf.Rad2Deg-180, 0);
			transform.position += ((new Vector3 (cameracollider.transform.position.x, 0, cameracollider.transform.position.z) - new Vector3 (transform.position.x, 0, transform.position.z))).normalized * Time.deltaTime * 1.0f;
			anim.SetBool ("BatRun", true);
		}
		if ((x * x) + (z * z) < 9f) {
			Batbool = true;
			transform.eulerAngles = new Vector3 (0, Mathf.Atan2 (x, z) * Mathf.Rad2Deg-180, 0);
			anim.SetBool ("BatRun", false);
			anim.SetBool ("BatAttack", true);
			StartCoroutine ("CEnemyAttack");
		} 
		if ((x * x) + (z * z) >=16f&&(x * x) + (z * z) <17f) {
			Batbool = false;
		}
	}
	bool IsRunning = false;
	IEnumerator CEnemyAttack(){
		if (IsRunning == true) {
			yield break;
		}
		else{	IsRunning = true;
			Invoke ("EnemyAttack", 0.8f);
			yield return new WaitForSeconds(2.458333f);
			IsRunning = false;//必ずアニメーションのHasExitTimeのExitTimeを１にして、durationを0にする
		}
	}


	void EnemyAttack(){
		audiosource.Play();
		playerImage.enabled = true;
		Invoke ("PlayerImagefalse",0.25f);
		handcontroller.hp -= atacck;
		handcontroller.HpGauge.fillAmount = (float)handcontroller.hp / handcontroller.fullhp;
	}

	void PlayerImagefalse(){
		playerImage.enabled = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "test_sword") {
			attackPower = other.GetComponent<Weapon> ().power;
			hp -= attackPower;
			hpGauge.fillAmount = (float)hp / fullHp; //(float)型変換
			print (hp);
			if (hp <= 0) {
				MoveStopCollider = null;
				EnemyHit = null;
				SlashEffect.Clear ();
				StopCoroutine ("CEnemyAttack");
				cameracollider.Slashmotion = false;
				anim.SetBool ("Batdie", true);
				anim2.SetBool ("Slash", false);
				Destroy (boxCollider);
				Invoke ("destroyslime", 1.5f);
				Destroy (hpObj);
			}
		}
	}

	void destroyslime(){
		Destroy (this.gameObject);
		raymanager.Movestop = false;

	}

}
