using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	public GameObject scoretext;
	public GameObject coin;

	void Start(){
		
		scoretext = GameObject.FindWithTag ("Player");
		coin = GameObject.Find ("Coin Sound");
	}


private void OnTriggerEnter(Collider other)
	{

		if(other.CompareTag("Player")){
			scoretext.GetComponent<Score> ().coinvalue = scoretext.GetComponent<Score> ().coinvalue + 5;
			coin.GetComponent<CoinSound>().oncoinSound ();


			Destroy (gameObject);

		}
	}

}
