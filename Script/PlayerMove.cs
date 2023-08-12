using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private CharacterController Controller;
	public GameObject Over;
	public GameObject JSound;
	public GameObject SSound;

	public Vector3 moveVector;
	private Animator Anim;
	public float Speed =9f;
	private bool  isDead = false;
	private float startTime;
   

	private float animationDurataion =3.0f ;

	private float Gravity=12f;
	private float Jump=4.2f;
	private float Velorcity;
	private const float turnspeed =2f;




    private int desiedLane=1;
	private float LaneDistance=1.2f;

    public GameObject Booster;


	private bool boost= false;
    public GameObject scoretexts;

	public bool hits= true;


	void Start () 

	{
		


       scoretexts = GameObject.FindWithTag ("Player");

		Over=  GameObject.Find ("GameOverSound");
		Controller = GetComponent<CharacterController> ();
		Anim = GetComponent<Animator> ();
		startTime = Time.time;
		Booster = GameObject.FindWithTag ("boostertag");
	}
	

	void Update () {

	
		if (MobileInput.Instance.SwipeRight) 

		{
			
			/*desiedLane++;
			if (desiedLane == 3)
				desiedLane = 2;*/
			MoveLane(true);
			SSound.GetComponent<sideSound>().sidesound ();
		

		}

		if (MobileInput.Instance.SwipeLeft) 

		{
			
			/*desiedLane--;
			if (desiedLane == -1)
				desiedLane = 0;*/

			MoveLane (false);
			SSound.GetComponent<sideSound>().sidesound ();
		}


		Vector3 tragetPosition = transform.position.z * Vector3.forward;
		if (desiedLane == 0)
			tragetPosition += Vector3.left * LaneDistance;
		else if (desiedLane==2)
			tragetPosition += Vector3.right * LaneDistance;


		moveVector = Vector3.zero;
		moveVector.x = (tragetPosition - transform.position).normalized.x *Speed;



	 

	

		if (boost == true) {
			Controller.Move ( Vector3.forward*Time.deltaTime * Speed * 1.5f);

				


			hits = false;
		

		}
			else  {

			hits = true;

			}

		

	
		Anim.SetBool("isslipe",false);



		if (isDead)
			return;
		if (Time.time-startTime < animationDurataion) {

			Controller.Move (Vector3.forward * Time.deltaTime * Speed);
			return;
		}

		if (Controller.isGrounded) {

			Velorcity = -1.5f;

			if (MobileInput.Instance.SwipeUp) {
				Anim.SetTrigger ("isjump");
				Velorcity = Jump;
				JSound.GetComponent<jumpsound> ().jumpSound ();

			} else if (MobileInput.Instance.SwipeDown)
			
			{
				
				startSlide ();

				Invoke("stoptSlide",1.0f);


				JSound.GetComponent<jumpsound> ().jumpSound ();
			}
			
			
			
			
		



		} else {
			
			Velorcity -=( Gravity*Time.deltaTime);
			if (MobileInput.Instance.SwipeDown) {

				Velorcity = -Jump;

				Anim.SetBool ("isslipe", true);
				Controller.height = 1.35f;
				Controller.center = new Vector3 (0, 0.6f, 0);



			}



		}
		moveVector.y = Velorcity;		 
			

	







        /*Vector3 tragetposition = transform.position.z * transform.forward + transform.position.y * transform.up;
		if (desiedLane == 0) 
		
		{
			tragetposition += Vector3.left * LaneDistance;


		}
		else if (desiedLane == 2) 

		{
			tragetposition+= Vector3.right * LaneDistance;


		}
		transform.position = Vector3.Lerp (transform.position, tragetposition,50* Time.deltaTime);*/



	
	    

		if (moveVector.y < -10.0f) {
			Death ();
		}



	

		moveVector.z = Speed;


		Controller.Move (moveVector * Time.deltaTime);
	
		Vector3 dir = Controller.velocity;
		dir.y = 0;
		transform.forward = Vector3.Lerp (transform.forward, dir,turnspeed);

	}


	public void speedSet(float modiffer){

		Speed =9f+ modiffer;



	} 


  


	private void OnControllerColliderHit(ControllerColliderHit hit){

		if (hits) {
			if (hit.collider.tag == "obtacale") {
				Death ();
			}
		
		} else {
			if (hit.collider.tag == "obtacale") {
				hit.collider.enabled = false;
			}
		
		
		}
	

	}







	private void Death(){
		
	
		isDead = true;
		Anim.SetTrigger ("isdead");
		Over.GetComponent<GameOver> ().overSound ();
		GetComponent<Score> ().onDeath();


	}







       void OnTriggerEnter(Collider other)
	{
	
	
		if (other.gameObject.tag == "Booster")
			StartCoroutine (Playerboost ());
		
		    

	}



 IEnumerator Playerboost(){

      
		boost = true;


		scoretexts.GetComponent<Score> ().boosterval = scoretexts.GetComponent<Score> ().boosterval + 10;
		Booster.GetComponent<BosterSound > ().OnboosterSound ();

		yield return new WaitForSeconds (5);

		boost = false;
}  

	public void startSlide ()

	{
	
		Anim.SetBool ("isslipe", true);
		Controller.height = 0.9f;
		Controller.center = new Vector3 (0, 0.4f, 0);

	
	}

	public void stoptSlide ()

	{
	
		Anim.SetBool ("isslipe", false);
		Controller.height = 2f;
		Controller.center = new Vector3 (0, 1, 0);

	
	}



	private bool Isgrounded(){
	
	
		Ray groundRay = new Ray(
			new Vector3 (
				Controller.bounds.center.x,
				(Controller.bounds.center.y - Controller.bounds.extents.y)+0.2f,Controller.bounds.center.z), Vector3.down);

		return Physics.Raycast (groundRay, 0.2f + 0.1f);
			
	}




	private void MoveLane(bool goingRight){
		
		
		desiedLane += (goingRight) ? 1 : -1;
		desiedLane = Mathf.Clamp (desiedLane, 0, 2);
	
	
	}
}	


