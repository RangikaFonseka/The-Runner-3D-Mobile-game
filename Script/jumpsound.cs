using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpsound : MonoBehaviour {

	public AudioSource jump;


	public void  jumpSound() {
		jump.Play();
	}

}
