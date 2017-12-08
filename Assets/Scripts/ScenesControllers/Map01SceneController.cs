using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Scenery;

public class Map01SceneController : SceneController {

	private static string SceneFileName { get { return "Map01Scene"; } }

	public TriggerHelper enterHouseDoor;
	public TriggerHelper exitLeft;
	public TriggerHelper exitRigth;


	private bool enableTriggers = false;

	private PlayerController player = null;

	public static Vector3 playerSpawnPosition {
		get {
			Vector3 spawnPosition =  new Vector3 (2.0f, -12.0f, 0.0f);

			PlayerController _player = GameSceneController.GetMainPlayer ();

			if (_player != null) {

				spawnPosition.x = _player.GetPlayerPosition().x;

			}

			return spawnPosition;
		}
	}

	public static Vector3 playerSpawnPositionCommingFromLeft {
		get {
			Vector3 spawnPosition =  new Vector3 (-296.0f, 152.0f, 0.0f);

			PlayerController _player = GameSceneController.GetMainPlayer ();

			if (_player != null) {

				spawnPosition.y = _player.GetPlayerPosition().y;

			}

			return spawnPosition;
		}
	}

	public static Vector3 playerSpawnPositionCommingFromRight {
		get {
			Vector3 spawnPosition =  new Vector3 (298.0f, 122.0f, 0.0f);

			PlayerController _player = GameSceneController.GetMainPlayer ();

			if (_player != null) {

				spawnPosition.y = _player.GetPlayerPosition().y;

			}

			return spawnPosition;
		}
	}

	#region ===================================== MonoBehaviour ====================================
	protected override void Awake() {
		base.Awake ();

		enableTriggers = true;

		player = GameSceneController.GetMainPlayer ();

	

		if (enterHouseDoor != null) {
			enterHouseDoor.onTriggerEnterEvent += OnEnterHouseDoorTriggerEnter;
			enterHouseDoor.onTriggerStayEvent += OnEnterHouseDoorTriggerStay;
			enterHouseDoor.onTriggerExitEvent += OnEnterHouseDoorTriggerExit;
		}

		if (exitLeft != null) {
			exitLeft.onTriggerEnterEvent += OnEnterExitLeftTriggerEnter;
			exitLeft.onTriggerStayEvent += OnEnterExitLeftTriggerStay;
			exitLeft.onTriggerExitEvent += OnEnterExitLeftTriggerExit;
		}

		if (exitRigth != null) {
			exitRigth.onTriggerEnterEvent += OnEnterExitRightTriggerEnter;
			exitRigth.onTriggerStayEvent += OnEnterExitRightTriggerStay;
			exitRigth.onTriggerExitEvent += OnEnterExitRightTriggerExit;
		}

	}

	#endregion

	#region delegates
	void OnEnterHouseDoorTriggerEnter (Collider2D col){
		if (enableTriggers) {
			Debug.Log ("OnEnterHouseDoorTriggerEnter: " + col.gameObject.name);
			player.SetPlayerVisible (false);
			player.SetPlayerPosition (Map02SceneController.playerSpawnPosition);
			SceneService.LoadScene<Map01SceneController,Map02SceneController,TransitionSceneController> (false, delegate(Map02SceneController obj) {

				player.SetPlayerVisible (true);
				player.SetFaceDirection(facing_direction.down);
				
			});

			enableTriggers = false;
		}
	}

	void OnEnterHouseDoorTriggerStay (Collider2D col){
		if (enableTriggers) {
			Debug.Log ("OnEnterHouseDoorTriggerStay: " + col.gameObject.name);
		}
	}

	void OnEnterHouseDoorTriggerExit (Collider2D col){
		if (enableTriggers) {
			Debug.Log ("OnEnterHouseDoorTriggerExit: " + col.gameObject.name);
		}
	}


	void OnEnterExitLeftTriggerEnter (Collider2D col){
		if (enableTriggers) {
			Debug.Log ("OnEnterExitLeftTriggerEnter: " + col.gameObject.name);
			player.EnableInput(false);
			player.SetPlayerPosition (Map03SceneController.playerSpawnPosition);
			SceneService.MoveToSceneFrom<Map01SceneController,Map03SceneController> (false, direction_to_move.left, delegate(Map03SceneController obj) {
				player.EnableInput(true);
			});
			enableTriggers = false;
		}
	}

	void OnEnterExitLeftTriggerStay (Collider2D col){

		Debug.Log( "OnEnterExitLeftTriggerStay: " + col.gameObject.name );
	}

	void OnEnterExitLeftTriggerExit (Collider2D col){

		Debug.Log( "OnEnterExitLeftTriggerExit: " + col.gameObject.name );
	}


	void OnEnterExitRightTriggerEnter (Collider2D col){
		if (enableTriggers) {
			Debug.Log ("OnEnterExitRightTriggerEnter: " + col.gameObject.name);
			player.EnableInput(false);
			player.SetPlayerPosition (Map04SceneController.playerSpawnPosition);
			SceneService.MoveToSceneFrom<Map01SceneController,Map04SceneController> (false, direction_to_move.right, delegate(Map04SceneController obj) {
				player.EnableInput(true);
			});
			enableTriggers = false;
		}
	}

	void OnEnterExitRightTriggerStay (Collider2D col){

		Debug.Log( "OnEnterExitRightTriggerStay: " + col.gameObject.name );
	}

	void OnEnterExitRightTriggerExit (Collider2D col){

		Debug.Log( "OnEnterExitRightTriggerExit: " + col.gameObject.name );
	}
	#endregion
}
