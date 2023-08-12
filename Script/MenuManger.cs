using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManger : MonoBehaviour {
	public GameObject bannerStart;

	void Start () {
      bannerStart.GetComponent<AdmobScript> ().RequestBanner ();

		bannerStart.GetComponent<AdmobScript> ().ShowBannerAD ();

	}
	

	void Update () {
		
	}
}
