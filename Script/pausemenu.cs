using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour {


	public static bool Gamepause = false;
	public GameObject pauseMenuUI;
	public GameObject SoundChange;
	public GameObject adding;


	void Start(){
		adding.GetComponent<AdmobScript> ().RequestInterstitial ();
	
	}

	void Update () {

	}

	public void Resum (){

		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		Gamepause = false;
		SoundChange.GetComponent<Sound> ().myaudio.Play();
		//adding.GetComponent<AdmobScript> ().DistroyAding();
	}

	public void pause(){

		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		Gamepause = true;
		SoundChange.GetComponent<Sound> ().myaudio.Pause ();

		//adding.GetComponent<AdmobScript> ().showInterstitialAD();

	}

	/*public void ButtonPuse(){



			if (Gamepause) {
				Resum ();

			} else {
				pause ();




		}
	}*/




}