using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Scenery;

public class GameSceneController :SceneController {

	private static string SceneFileName { get { return "GameScene"; } }

	public TriggerHelper enterHouseDoor;

	#region ===================================== MonoBehaviour ====================================
	protected override void Awake() {
		base.Awake ();

		if (enterHouseDoor != null) {
			enterHouseDoor.onTriggerEnterEvent += OnEnterHouseDoorTriggerEnter;
			enterHouseDoor.onTriggerStayEvent += OnEnterHouseDoorTriggerStay;
			enterHouseDoor.onTriggerExitEvent += OnEnterHouseDoorTriggerExit;
		}

	}

	#endregion

	#region delegates
	void OnEnterHouseDoorTriggerEnter (Collider2D col){

		Debug.Log( "OnEnterHouseDoorTriggerEnter: " + col.gameObject.name );
		SceneService.LoadScene<GameSceneController,Map02SceneController,TransitionSceneController>(false, null);
	}

	void OnEnterHouseDoorTriggerStay (Collider2D col){

		Debug.Log( "OnEnterHouseDoorTriggerStay: " + col.gameObject.name );
	}

	void OnEnterHouseDoorTriggerExit (Collider2D col){

		Debug.Log( "OnEnterHouseDoorTriggerExit: " + col.gameObject.name );
	}
	#endregion
}
