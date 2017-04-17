using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStopColliderSaurus : MonoBehaviour {
	public EnemySaurus enemysaurus;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (enemysaurus.hp <= 0) {
			Destroy (this.gameObject);
		}
	}
}
