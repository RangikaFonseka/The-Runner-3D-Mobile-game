using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	private float score = 0f;
	public Text ScoreText;
	public Text diffL;
	public Text CoinText;
	public Text	highScores;
	private int difflevel=1;
	private int maxlevel=10;
	private int scoreTonextleve=10;
	private bool isDead = false;
	public int coinvalue;
	public int Score1;
	public int boosterval;
	public int coin;
	public int coinScore;
	public int coining;

	public GameObject CoinAdds;



	public Manue dethMenu;

	void Start () {
		CoinAdds.GetComponent<AdmobScript> ().RequestRewardBasedVideo ();
	}
	

	void Update () {

		if (isDead)
			return;

		if (score >=scoreTonextleve)
			Levelup ();
		score += Time.deltaTime*difflevel/2;
		diffL.text = "x" + difflevel.ToString();
		Score1 = ((int)score) + coinvalue + boosterval;
		ScoreText.text = ((int)	Score1).ToString();
		CoinText.text =( coinvalue / 5).ToString();
		highScores.text = " Highscore : " + (((int)Score1)-((int)PlayerPrefs.GetFloat ("Highscore"))).ToString();
		coin = coinvalue / 5;

		coinScore = coin+coining;




	}
	public void coingReward(){

	
		CoinAdds.GetComponent<AdmobScript> ().ShowVideoRewardAD ();
		PlayerPrefs.SetInt ("Coins", coin + coinScore+20);
	}











	public void Levelup (){

		if (maxlevel == difflevel)
			return;

		scoreTonextleve *= 2;
		difflevel++;



		GetComponent<PlayerMove>().speedSet(difflevel);


	}
	public void onDeath(){
	
		isDead= true;
		if(PlayerPrefs.GetFloat ("Highscore") < Score1)
		PlayerPrefs.SetFloat ("Highscore", Score1);
		coin=PlayerPrefs.GetInt ("Coins", coin);
		PlayerPrefs.SetInt ("Coins", coin + coinScore);
		PlayerPrefs.Save ();



	  
	


		dethMenu.toogleEnterMenu (Score1,coinvalue);
	}



















}
