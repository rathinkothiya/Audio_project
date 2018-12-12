using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
public class ChangePostProfile : MonoBehaviour {


	public PostProcessingProfile normal,fx; 


	private PostProcessingBehaviour cameraImageFx;


	// Use this for initialization
	void Start () {
		cameraImageFx = FindObjectOfType<PostProcessingBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Player")) 
		{
			cameraImageFx.profile = fx;

		}

	}

	void OnTriggerExit(Collider col)
	{
		if (col.CompareTag ("Player")) 
		{
			cameraImageFx.profile = normal;
		}

	}
}
