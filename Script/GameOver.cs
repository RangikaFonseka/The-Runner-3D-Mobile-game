using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
	public AudioSource Over;

	public void  overSound() {
		Over.Play();
	}
	
}

