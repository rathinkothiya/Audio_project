using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class Proximity : MonoBehaviour {

	public GameObject fps;	// Use this for initialization

	void Start () {

//		GameObject theplayer = GameObject.Find ("RigidBodyFPSController");
//		Tremelo tremelo = theplayer.GetComponentInChildren<Tremelo> ();

	}
		
		
	public void  OnTriggerEnter () {
//		Debug.Log ("Object entered!");
		fps.GetComponentInChildren<Tremelo> ().enabled = true;
		fps.GetComponentInChildren<Tremelo> ().GetComponent<AudioSource> ().Play ();
		
	}

	public void  OnTriggerExit () {
//		Debug.Log ("Object Exited!");
		fps.GetComponentInChildren<Tremelo> ().GetComponent<AudioSource> ().Stop ();
//		fps.GetComponentInChildren<Tremelo> ().enabled = false;

	}


}
