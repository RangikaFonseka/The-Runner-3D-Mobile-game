using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour {

	private const float DEADZONE = 100.0f;

	public static MobileInput Instance{ set; get;}

	private bool tap,swipeLeft,swipeRight,swipeUp,swipeDown;

	private Vector2 swipeDelta,startTourch;


	public bool Tap{get{ return tap; }}
	public Vector2 SwipeDelta {get{return swipeDelta;}}
	public bool SwipeLeft   {get{return swipeLeft;}}
	public bool SwipeRight  {get{return swipeRight;}}
	public bool SwipeUp     {get{return  swipeUp;}}
	public bool SwipeDown   {get{return  swipeDown;}}

	private void Awake()
	{

		Instance = this;



	}
	private void Update()
	{


		tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;
		#region Standalone Inputs
		if(Input.GetMouseButtonDown(0))
			{
				tap = true;

				startTourch = Input.mousePosition;

			}

			else if (Input.GetMouseButtonUp(0))
			{

				startTourch= swipeDelta=Vector2.zero;

			}


		#endregion






			#region Mobile Inputs
		if(Input.touches.Length !=0){

			if(Input.touches[0].phase==TouchPhase.Began)
			
				{
					tap = true;

					startTourch = Input.mousePosition;

				}

				else if (Input.GetMouseButtonUp(0))
				{

					startTourch= swipeDelta=Vector2.zero;

				}
	}

				#endregion



		swipeDelta = Vector2.zero;
		if (startTourch != Vector2.zero) 
		
		
		{
			if (Input.touches.Length != 0) {
			
			
				swipeDelta = Input.touches [0].position - startTourch;


			} else if (Input.GetMouseButton(0)) {
			
				swipeDelta = (Vector2) Input.mousePosition - startTourch;
			
			}
		
		
		}




		if (swipeDelta.magnitude > DEADZONE) {
		
		
			float x = swipeDelta.x;
			float y = swipeDelta.y;

			if (Mathf.Abs (x) > Mathf.Abs (y)) {

				//  right

				if (x < 0)
					swipeLeft = true;
				else
					swipeRight = true;

			} else {

				if (y< 0)
					swipeDown = true;
				else
					swipeUp = true;
			
			}
			startTourch= swipeDelta = Vector2.zero; 


		
		}








	}



}
