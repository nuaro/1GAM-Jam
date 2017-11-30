using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoController : MonoBehaviour {

	public float runSpeed = 8f;

	private CharacterController2DTopDown _controller;
	private Vector3 _velocity;
	// Use this for initialization
	void Awake()
	{
		_controller = GetComponent<CharacterController2DTopDown>();

		// listen to some events for illustration purposes
		_controller.onControllerCollidedEvent += onControllerCollider;
		_controller.onTriggerEnterEvent += onTriggerEnterEvent;
		_controller.onTriggerExitEvent += onTriggerExitEvent;
	}

	#region Event Listeners

	void onControllerCollider( RaycastHit2D hit )
	{
		// bail out on plain old ground hits cause they arent very interesting
//		if( hit.normal.y == 1f )
//			return;

		// logs any collider hits if uncommented. it gets noisy so it is commented out for the demo
		Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );
	}


	void onTriggerEnterEvent( Collider2D col )
	{
		Debug.Log( "onTriggerEnterEvent: " + col.gameObject.name );
	}


	void onTriggerExitEvent( Collider2D col )
	{
		Debug.Log( "onTriggerExitEvent: " + col.gameObject.name );
	}

	#endregion

	void Update()
	{
		float horizontalInput = Input.GetAxisRaw("Horizontal"); 
		float verticalInput = Input.GetAxisRaw("Vertical");

		_velocity.x = horizontalInput * runSpeed;
		_velocity.y = verticalInput * runSpeed;


		this._controller.move (this._velocity * Time.deltaTime);
	}
}
