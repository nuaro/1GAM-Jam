using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Scenery;

public class Map04SceneController : SceneController {

	private static string SceneFileName { get { return "Map04Scene"; } }

	public TriggerHelper exitDoor;


	private bool enableTriggers = false;

	public static Vector3 playerSpawnPosition {
		get {
			Vector3 spawnPosition =  new Vector3 (342.0f, 119.0f, 0.0f);

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
		if (exitDoor != null) {
			exitDoor.onTriggerEnterEvent += OnExitDoorTriggerEnter;
			exitDoor.onTriggerStayEvent += OnExitDoorTriggerStay;
			exitDoor.onTriggerExitEvent += OnExitDoorTriggerExit;
		}

	}

	#endregion

	#region delegates
	void OnExitDoorTriggerEnter (Collider2D col){

		if (enableTriggers) {
			Debug.Log ("OnExitDoorTriggerEnter: " + col.gameObject.name);
			DemoController.EnableInput (false);
			DemoController.SetPositionPlayer (Map01SceneController.playerSpawnPositionCommingFromRight);
			SceneService.MoveToSceneFrom<Map04SceneController,Map01SceneController> (false, direction_to_move.left,delegate(Map01SceneController obj) {
				DemoController.EnableInput(true);
			});

			enableTriggers = false;
		}
	}

	void OnExitDoorTriggerStay (Collider2D col){

		Debug.Log( "OnExitDoorTriggerStay: " + col.gameObject.name );
	}

	void OnExitDoorTriggerExit (Collider2D col){

		Debug.Log( "OnExitDoorTriggerExit: " + col.gameObject.name );
	}
	#endregion
}
