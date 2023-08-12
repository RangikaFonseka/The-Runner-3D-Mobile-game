using UnityEngine;
using System.Collections;
using  System.Collections.Generic;

public class TileManger : MonoBehaviour {

	public GameObject[] Tileprefab;
	private Transform PlayerTransform; 
	private float Spamz = 0.0f;
	private float tilelenth =7.5f;
	private int amnTile =10;
	private float savezone =15.0f;
	public List <GameObject> activeTiles;
	private int lastprefabindex=0;

	void Start () {
		
		PlayerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		activeTiles= new List<GameObject>();
		for(int i=1 ;i < amnTile;i++){
			if (1 < 2)
				SpamTile (0);
			else
			SpamTile ();

		}
	}
	

	void Update () {
		if(PlayerTransform.position.z-savezone>(Spamz - amnTile *tilelenth )){
			SpamTile ();
			DeleteTile ();

		}
	}
	private void SpamTile(int prefabindx = -1){
		GameObject go;
		if (prefabindx == -1)
			go = Instantiate (Tileprefab [RandomprefabIndex ()])as GameObject;
		  
		else
			
			go=Instantiate(Tileprefab[prefabindx])as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * Spamz;
		Spamz += tilelenth;
		activeTiles.Add (go);

		
	
	
	
	}


	private void DeleteTile(){
		

		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0); 
	}
	private int RandomprefabIndex(){
		if (Tileprefab.Length <= 1)
			return 0;
		int randomIndex = lastprefabindex;
		while(randomIndex == lastprefabindex){

			randomIndex = Random.Range (0, Tileprefab.Length);

		}
	
		lastprefabindex = randomIndex;
		return randomIndex;
	}
}
 