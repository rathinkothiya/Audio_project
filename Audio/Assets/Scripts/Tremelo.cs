using UnityEngine;

public class Tremelo : MonoBehaviour
{

	public float depth;
	public int speed;
	public static float[] samples;
	// Read all the samples from the clip, reducing their gain by half
	void Start()
	{
		doTremello ();

	}


	public void doTremello(){
		
		//		float depth = 0.5f;
		//		int speed = 5;
		float tremelo;
		//setting the sampling rate according to the nyquist rate.
		double sample_rate = 44100 * 2;
		//Getting audioSource component
		AudioSource audioSource = GetComponent<AudioSource>();

		//storing clip data in samples array 
		samples = new float[audioSource.clip.samples * audioSource.clip.channels];
		audioSource.clip.GetData(samples, 1);



		// looping through all the values of sample array and applying tremolo filter
		for (int i = 0; i < samples.Length; ++i)
		{
			//			samples[i] = samples[i] * 0.5f;
			//			print ("samples are: "+ samples[i]);
			//calculating the Tremolo value.
			tremelo = ( 1 + depth * Mathf.Sin(2 * Mathf.PI * i * (speed / (float)sample_rate)));
			samples [i] = tremelo * samples [i];

		}
		//Setting the data from samples array on to the audio source.
		audioSource.clip.SetData(samples, 0);
		audioSource.Play ();
		//Enabling the lowpass filter in order implement the underwater effect.
		GetComponent<AudioLowPassFilter> ().enabled = true;


	}




}
