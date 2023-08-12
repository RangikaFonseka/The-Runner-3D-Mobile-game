using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmanue : MonoBehaviour {
	public Text highScore;
	public Text coin;
	private int con;

	public GameObject add;
	private int free=1;






	void Start () {
		highScore.text = "Highscore : " + ((int)PlayerPrefs.GetFloat ("Highscore")).ToString ();
		con = PlayerPrefs.GetInt ("Coins");
		coin.text = "coins " + con.ToString ();
		add.GetComponent<AdmobScript> ().RequestRewardBasedVideo ();	


		 free=1;
	}


	public void Free(){
	
		free = 0;
		Debug.Log (free);
		add.GetComponent<AdmobScript> ().ShowVideoRewardAD ();	
	}


	public void ToGame(){
		if (con > free*1000) {


			SceneManager.LoadScene ("game");


		} else {
		

		
		}
	}

   

	public void ToGameOther(){
		

			SceneManager.LoadScene ("Game - copy1");


	}

	public void ToGameOtherone(){
		if (con > free*2000) {

			SceneManager.LoadScene ("Game - copy2");

		}
	}

	public void ToGameOthertwo(){
		if (con > free*5000) {

			SceneManager.LoadScene ("Game - copy3");

		}
	}
	public void ToGameOtherthre(){
		if (con > free * 7500) {

			SceneManager.LoadScene ("Game - copy4");
		
		}
	}

	public void ToGameOtherfour(){
		if (con > free*9500) {

		SceneManager.LoadScene ("Game - copy5");

		}
	}

	public void ToGameOthefive(){
		if (con > free*11500) {

		SceneManager.LoadScene ("Game - copy6");

		}
	}






}
