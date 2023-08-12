using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	public AudioSource myaudio;

	void Awake () {
		myaudio = GetComponent<AudioSource> ();

		myaudio.Play ();
	
	}


	void Update () {
		

}

}