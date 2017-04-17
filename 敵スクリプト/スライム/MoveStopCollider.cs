using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStopCollider : MonoBehaviour {
	public EnemySlime enemyslime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyslime.hp <= 0) {
			Destroy (this.gameObject);
		}
	}
}
