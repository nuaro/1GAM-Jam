using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Scenery;

public class Map02SceneController :  SceneController {

	private static string SceneFileName { get { return "Map02Scene"; } }

	public TriggerHelper exitDoor;

	private PlayerController player = null;

	public static Vector3 playerSpawnPosition {
		get {
			Vector3 spawnPosition =  new Vector3 (160.0f, 197.0f, 0.0f);

			PlayerController _player = GameSceneController.GetMainPlayer ();

			if (_player != null) {

				spawnPosition.x = _player.GetPlayerPosition().x;

			}


			return spawnPosition;
		}
	}



	#region ===================================== MonoBehaviour ====================================
	protected override void Awake() {
		base.Awake ();

		player = GameSceneController.GetMainPlayer ();

		if (exitDoor != null) {
			exitDoor.onTriggerEnterEvent += OnExitDoorTriggerEnter;
			exitDoor.onTriggerStayEvent += OnExitDoorTriggerStay;
			exitDoor.onTriggerExitEvent += OnExitDoorTriggerExit;
		}
			

	}

	#endregion

	#region delegates
	void OnExitDoorTriggerEnter (Collider2D col){
		
		Debug.Log( "OnExitDoorTriggerEnter: " + col.gameObject.name );
		player.SetPlayerVisible (false);
		player.SetPlayerPosition (Map01SceneController.playerSpawnPosition);
		SceneService.LoadScene<Map02SceneController,Map01SceneController,TransitionSceneController>(false, delegate(Map01SceneController obj) {
			player.SetPlayerVisible (true);
			player.SetFaceDirection(facing_direction.down);
		});
	}

	void OnExitDoorTriggerStay (Collider2D col){

		Debug.Log( "OnExitDoorTriggerStay: " + col.gameObject.name );
	}

	void OnExitDoorTriggerExit (Collider2D col){

		Debug.Log( "OnExitDoorTriggerExit: " + col.gameObject.name );
	}
	#endregion

}
