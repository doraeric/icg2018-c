using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour {

	public Animator door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player"){
			door.SetBool("character_nearby", true);
		}
	}

	void OnTriggerExit (Collider other){
		if (other.tag == "Player"){
			door.SetBool("character_nearby", false);
		}
	}
}
