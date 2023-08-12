using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manue : MonoBehaviour {
	public Text ScoreText;
	public Text coinText;
	public Image backgroundImg;
	private bool isShown = false;
	private float transition=0.0f;
	public GameObject adds;



	void Start () {
		gameObject.SetActive (false);
		adds.GetComponent<AdmobScript> ().RequestInterstitial ();	

	}
	

	void Update () {
		if (!isShown)
			return;
		transition += Time.deltaTime/3;
		backgroundImg.color = Color.Lerp (new Color (0, 0, 0, 0), Color.white,transition );

	}

	public void toogleEnterMenu(float score , float coin){

		gameObject.SetActive (true);
		ScoreText.text= ((int)score).ToString();
		coinText.text = ((int)coin/5).ToString ();
		isShown = true;


	
	}

	public void Restart(){
		

	SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	public void ToMenu(){
		adds.GetComponent<AdmobScript> ().showInterstitialAD ();	

		SceneManager.LoadScene ("Menu");
	}


}



