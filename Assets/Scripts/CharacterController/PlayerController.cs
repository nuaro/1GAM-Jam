using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum facing_direction {
	up,
	down,
	left,
	right
}

public class PlayerController : MonoBehaviour {

	#region public
	public float runSpeed = 60f;
	public float rollSpeed = 70f;
	public GameObject SpriteAnimator;
	#endregion



	#region private //private var will always use _ before the var name to make a diference withing publics

	private CharacterController2DTopDown _controller;
	private Vector3 _velocity;
	private Animator _animator;

	private bool _enableInput = true;

	private StateMachine<PlayerController> _playerStateMachine;

	private facing_direction playerFacing = facing_direction.down;


	#endregion

	#region MonoBehaviour
	void Awake(){

		//we set the controller
		_controller = GetComponent<CharacterController2DTopDown>();
		//we set the animator
		if (SpriteAnimator != null) {
			_animator = SpriteAnimator.GetComponent<Animator> ();
		}

		if (_controller != null) {
			_controller.onControllerCollidedEvent += onControllerCollider;
			_controller.onTriggerEnterEvent += onTriggerEnterEvent;
			_controller.onTriggerExitEvent += onTriggerExitEvent;
		}

		_playerStateMachine = new StateMachine<PlayerController> (this);
		_playerStateMachine.SetCurrentState (MoveState.Instance);

	}


	void Update () {
		if (_enableInput) {
			_playerStateMachine.OnUpdate ();
		}
	}

	#endregion

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

	#region public methods


	public void SetPlayerPosition( Vector3 position ){

		transform.localPosition = position;
	}

	public void SetPlayerVisible( bool show ) {
		gameObject.SetActive (show);
	}

	public Vector3 GetPlayerPosition () {
		
		return transform.localPosition;

	}

	public void EnableInput (bool enable) {
		
		_enableInput = enable;

	}

	public bool IsInputEnabled () {

		return _enableInput;

	}

	public StateMachine<PlayerController> GetFSM(){

		return _playerStateMachine;
	}

	public void SwitchFacingDirection()
	{
		Vector3 scale = this.transform.localScale;
		if (_velocity.x != 0) {
			if (Mathf.Sign (_velocity.x) != Mathf.Sign (scale.x)) {
				this.transform.localScale = new Vector3 (-scale.x, scale.y, scale.z);
			}
		}
	}

	public void Move() {
		float horizontalInput = Input.GetAxisRaw ("Horizontal"); 
		float verticalInput = Input.GetAxisRaw ("Vertical");

		_velocity.x = horizontalInput * runSpeed;
		_velocity.y = verticalInput * runSpeed;

		SwitchFacingDirection ();

		_animator.SetFloat ("speed_x", Mathf.Abs (_velocity.x));
		_animator.SetFloat ("speed_y", _velocity.y);

		_controller.move (_velocity * Time.deltaTime);


		UpdateFaceDirection ();

	}

	public void Attack (bool attack) {

		_animator.SetBool ("attack", attack);

	}


	public facing_direction GetFacingDirection() {

		return playerFacing;
	}

	public void SetFaceDirection(facing_direction direction) {

		playerFacing = direction;

	}

	public void Roll(bool roll){

		_animator.SetBool ("roll", roll);

		facing_direction _direction = GetFacingDirection ();

		switch (_direction) {
		case facing_direction.down:
			_velocity.y = -rollSpeed;
			break;
		case facing_direction.left:
			_velocity.x = -rollSpeed;
			break;
		case facing_direction.right:
			_velocity.x = rollSpeed;
			break;
		case facing_direction.up:
			_velocity.y = rollSpeed;
			break;
		}

		_controller.move (_velocity * Time.deltaTime);

	}


	#endregion
	#region private

	private void UpdateFaceDirection( ) {

		if (_velocity.x != 0 || _velocity.y != 0) {

			if (_velocity.y != 0) {
				var isGoingUp = _velocity.y > 0;

				playerFacing = isGoingUp ? facing_direction.up : facing_direction.down;
			}
			if (_velocity.x != 0) {
				var isGoingRight = _velocity.x > 0;

				playerFacing = isGoingRight ? facing_direction.right : facing_direction.left;
			}
		}



	}



	#endregion
}
