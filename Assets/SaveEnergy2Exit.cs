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
	public ParticleSystem[] sub;

	// public Shader Circle;
	
	// Update is called once per frame
	void Update () {
		if (currentEnergy >= EnerCapacity){
			SceneManager.LoadScene("BeginScene");
			Debug.Log("loadScene");
		}else if (currentEnergy < 0){
			currentEnergy = 0;
		}else{
			currentEnergy += currentRate * Time.deltaTime;
		}

		float rate = (2 * currentEnergy / EnerCapacity) % EnerCapacity;

		for (int i = 0; i < sub.Length; i++ ) {
			sub[i].startColor = new Color(255, 255, 255, rate);
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

	void setParticleLevel (float l){
		
	}
}
