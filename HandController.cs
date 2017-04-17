using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandController : MonoBehaviour {
	public int hp;
	public int fullhp;
	public Image HpGauge;
	public Image Image;
	public Image GameOver;
	public Text text;
	Image playerdying;
	// Use this for initialization
	void Start () {
		GameOver.enabled = false;
		text.enabled = false;
		fullhp = hp;
		playerdying = Image.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (hp < fullhp / 3) {
			playerdying.enabled = true;
		} else {
			playerdying.enabled = false;
		}

		if (hp < 0) {
			GameOver.enabled = true;
			text.enabled = true;
			Invoke ("gameover",3.0f);
		}
			
	}

	void gameover(){
		GameOver.enabled = false;
		text.enabled = false;
		Application.LoadLevel("Title");
	}
}
