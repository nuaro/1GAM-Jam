using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Scenery;

public class Map02SceneController :  SceneController {

	private static string SceneFileName { get { return "Map02Scene"; } }

	public TriggerHelper exitDoor;



	#region ===================================== MonoBehaviour ====================================
	protected override void Awake() {
		base.Awake ();

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
		SceneService.LoadScene<Map02SceneController,GameSceneController,TransitionSceneController>(false, null);
	}

	void OnExitDoorTriggerStay (Collider2D col){

		Debug.Log( "OnExitDoorTriggerStay: " + col.gameObject.name );
	}

	void OnExitDoorTriggerExit (Collider2D col){

		Debug.Log( "OnExitDoorTriggerExit: " + col.gameObject.name );
	}
	#endregion

}
