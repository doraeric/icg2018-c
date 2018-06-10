using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageTransform : MonoBehaviour {

	public Transform player;
	public Transform nextStage;
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player"){
			player.position = nextStage.position;
		}
	}
}
