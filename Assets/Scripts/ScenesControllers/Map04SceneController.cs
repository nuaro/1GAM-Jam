using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Scenery;

public class Map04SceneController : SceneController {

	private static string SceneFileName { get { return "Map04Scene"; } }

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
		//SceneRepository.LoadScene<GameSceneController> (false, true, null);
	}

	void OnExitDoorTriggerStay (Collider2D col){

		Debug.Log( "OnExitDoorTriggerStay: " + col.gameObject.name );
	}

	void OnExitDoorTriggerExit (Collider2D col){

		Debug.Log( "OnExitDoorTriggerExit: " + col.gameObject.name );
	}
	#endregion
}
