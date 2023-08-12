using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmenu : MonoBehaviour {

	public AudioSource myaudios;

	void Awake () {
		myaudios = GetComponent<AudioSource> ();

		myaudios.Play ();

	}



}
