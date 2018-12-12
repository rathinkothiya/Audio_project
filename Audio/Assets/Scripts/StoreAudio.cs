using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class StoreAudio : MonoBehaviour
{

	AudioClip myAudioClip; 
	void Start() {

	}
	void Update () {

	}

	void OnGUI()
	{
		//  Creating a record button 
		if (GUI.Button(new Rect(10,10,60,50),"Record"))
		{ 
			myAudioClip = Microphone.Start ( null, false, 10, 44100 );
		}
		//  Creating a Save button 
		if (GUI.Button(new Rect(10,70,60,50),"Save"))
		{
			SavWav.Save("myfile", myAudioClip);
		}
		//  Creating a Play button 
		if (GUI.Button (new Rect (10, 130, 60, 50), "Play")) 
		{
			ApplyFilter ();
		}
	}
	// not working at this moment.. still in progress.
	public void ApplyFilter() {
		float[] samples;
		AudioSource a = GetComponent<AudioSource> ();
		double tremelo;
		double sample_rate = 44100 * 2;
		double depth = 0.5;
		int speed = 5;
		samples = new float[myAudioClip.samples * myAudioClip.channels];
		for (int i = 0; i < samples.Length; ++i)
		{
						tremelo = ( 1 + depth * Mathf.Sin(2 * Mathf.PI * i * (speed / (float)sample_rate)));
			Debug.Log(tremelo);
			samples [i] = (float)tremelo * samples [i];
			myAudioClip.SetData (samples,  0);

		}
			
	}
}
