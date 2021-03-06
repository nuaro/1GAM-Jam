﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoController : MonoBehaviour {

	public float runSpeed = 8f;

	private CharacterController2DTopDown _controller;
	private Vector3 _velocity;
	private Animator _animator;
	// Use this for initialization

	private bool enableInput = true;

	//instance simple
	public static DemoController playerInstance = null;

	void Awake()
	{

		playerInstance = this;

		_controller = GetComponent<CharacterController2DTopDown>();
		_animator = GetComponent<Animator>();

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
		if (enableInput) {
			float horizontalInput = Input.GetAxisRaw ("Horizontal"); 
			float verticalInput = Input.GetAxisRaw ("Vertical");

			_velocity.x = horizontalInput * runSpeed;
			_velocity.y = verticalInput * runSpeed;

			Vector3 scale = this.transform.localScale;
			if (_velocity.x != 0) {
				if (Mathf.Sign (_velocity.x) != Mathf.Sign (scale.x)) {
					this.transform.localScale = new Vector3 (-scale.x, scale.y, scale.z);
				}
			}


			_animator.SetFloat ("speed_x", Mathf.Abs (_velocity.x));
			_animator.SetFloat ("speed_y", _velocity.y);

			this._controller.move (this._velocity * Time.deltaTime);
		}
	}

	void OnDestroy() {

		playerInstance = null;

	}

	public static void SetPositionPlayer(Vector3 position){

		if (playerInstance != null) {
			
			playerInstance.transform.localPosition = position;

		}
	}

	public static void SetPlayerVisible(bool show){

		if (playerInstance != null) {

			playerInstance.gameObject.SetActive(show);

		}
	}

	public static Vector3 GetPlayerPosition() {
		if (playerInstance != null) {

			return playerInstance.transform.localPosition;
		}

		return Vector3.negativeInfinity;
	}

	public static void EnableInput (bool enable){
		if (playerInstance != null) {
			playerInstance.enableInput = enable;
		}
	}
}
