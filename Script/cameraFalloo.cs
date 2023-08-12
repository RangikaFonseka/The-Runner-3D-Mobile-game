using UnityEngine;
using System.Collections;

public class cameraFalloo : MonoBehaviour {

	private Transform LookAt;
	private Vector3 offset;
	private Vector3 moveVector;

	private float transiton = 0.0f;
	private float animationDurataion =2.0f ;
	private Vector3 animationOffset= new Vector3(0,0,5);

	void Start () {
		LookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		offset = transform.position - LookAt.position;

	}
	

	void Update () {
		moveVector =  LookAt.position + offset;


		moveVector.x = 0;
		moveVector.y = Mathf.Clamp(moveVector.y,3,5);


		if(transiton>1.0f){

			transform.position = moveVector;
		}
		else{

			transform.position = Vector3.Lerp (moveVector + animationOffset, moveVector, transiton);

			transiton += Time.deltaTime * 1 / animationDurataion;
			transform.LookAt (LookAt.position+Vector3.up);
		}




	}
}


