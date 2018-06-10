using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveEnergy2Exit : MonoBehaviour {

	public bool inCollider = false;
	public float saveRate = 1.0f;
	public float lossRate = -0.5f;

	private float currentRate;		
	public float currentEnergy = 0f;
	public float EnerCapacity = 100f;

	public GameObject portalEffect;
	public ParticleSystem[] Circle_H;
	public ParticleSystem Circle_V;

	public ParticleSystem pointlight;
	
	// Update is called once per frame
	void Update () {
		if (currentEnergy >= EnerCapacity){
			SceneManager.LoadScene("BeginScene");
			Debug.Log("loadScene");
		}else if (currentEnergy < 0){
			currentEnergy = 0;
		}else{
			if (inCollider){
				currentEnergy += saveRate * Time.deltaTime;
				Debug.Log(currentEnergy);
			}
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player"){
			Debug.Log("is Trigger");
			inCollider = true;
			currentRate = saveRate;
		}
	}

	void OnTriggerExit (Collider other){
		if (other.tag == "Player"){
			Debug.Log("exit Trigger");
			inCollider = false;
			currentRate = lossRate;
		}
	}
}
