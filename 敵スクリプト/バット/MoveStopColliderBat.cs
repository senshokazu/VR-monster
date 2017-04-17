using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStopColliderBat : MonoBehaviour {
	public EnemyBat enemybat;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (enemybat.hp <= 0) {
			Destroy (this.gameObject);
		}
	}
}