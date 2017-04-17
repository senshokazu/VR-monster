using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStopColliderGhost : MonoBehaviour {
	public EnemyGhost enemyghost;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (enemyghost.hp <= 0) {
			Destroy (this.gameObject);
		}
	}
}
