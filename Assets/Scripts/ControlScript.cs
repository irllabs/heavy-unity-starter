using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {
	
	public Hv_ballBounce_LibWrapper HeavyScript;

	Rigidbody rb;
	private float lastVelocity;
	private float thisVelocity;
	private bool bounceMoment;

	//AudioSource aud;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		HeavyScript = GetComponent<Hv_ballBounce_LibWrapper> ();
		bounceMoment = false;

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 v3Velocity = rb.velocity; 
		thisVelocity = v3Velocity.y;

		float posY = gameObject.transform.position.y;

		if (thisVelocity > 0 && lastVelocity < 0) {


			HeavyScript.SendBangToReceiver ((uint) Hv_ballBounce_LibWrapper.Parameter.Bouncenow);  //this generates an error saying .SendBangToReceiver expects a uint argument, not a string

			bounceMoment = true;
			print ("bounce!");
			//aud.Play ();
		}

		lastVelocity = thisVelocity;

		/*
		if (posY > .5) {
			bounceMoment = false;
		}
		*/
			
		//LibPD.SendFloat("footPosY", footY);
		HeavyScript.pitchOffset = posY/2;
		//print ("sending posY: " + posY);


		}

}


