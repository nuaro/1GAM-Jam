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

	public static Vector3 playerSpawnPosition {
		get {
			Vector3 spawnPosition =  new Vector3 (2.0f, -12.0f, 0.0f);

			Vector3 playerPosition = DemoController.GetPlayerPosition ();

			if (!playerPosition.Equals (Vector3.negativeInfinity)) {

				spawnPosition.x = playerPosition.x;

			}

			return spawnPosition;
		}
	}

	public static Vector3 playerSpawnPositionCommingFromLeft {
		get {
			Vector3 spawnPosition =  new Vector3 (-296.0f, 152.0f, 0.0f);

			Vector3 playerPosition = DemoController.GetPlayerPosition ();

			if (!playerPosition.Equals (Vector3.negativeInfinity)) {

				spawnPosition.y = playerPosition.y;

			}

			return spawnPosition;
		}
	}

	public static Vector3 playerSpawnPositionCommingFromRight {
		get {
			Vector3 spawnPosition =  new Vector3 (298.0f, 122.0f, 0.0f);

			Vector3 playerPosition = DemoController.GetPlayerPosition ();

			if (!playerPosition.Equals (Vector3.negativeInfinity)) {

				spawnPosition.y = playerPosition.y;

			}

			return spawnPosition;
		}
	}

	#region ===================================== MonoBehaviour ====================================
	protected override void Awake() {
		base.Awake ();

		enableTriggers = true;

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
			DemoController.SetPlayerVisible (false);
			DemoController.SetPositionPlayer (Map02SceneController.playerSpawnPosition);
			SceneService.LoadScene<Map01SceneController,Map02SceneController,TransitionSceneController> (false, delegate(Map02SceneController obj) {

				DemoController.SetPlayerVisible (true);
				
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
			DemoController.EnableInput (false);
			DemoController.SetPositionPlayer (Map03SceneController.playerSpawnPosition);
			SceneService.MoveToSceneFrom<Map01SceneController,Map03SceneController> (false, direction_to_move.left, delegate(Map03SceneController obj) {
				DemoController.EnableInput(true);
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
			DemoController.EnableInput (false);
			DemoController.SetPositionPlayer (Map04SceneController.playerSpawnPosition);
			SceneService.MoveToSceneFrom<Map01SceneController,Map04SceneController> (false, direction_to_move.right, delegate(Map04SceneController obj) {
				DemoController.EnableInput(true);
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
