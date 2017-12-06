using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Scenery;

public class GameSceneController :SceneController {

	private static string SceneFileName { get { return "GameScene"; } }


	#region ===================================== MonoBehaviour ====================================
	protected override void Awake() {
		base.Awake ();
		SceneRepository.LoadScene<Map01SceneController>( true, true, null);
		
	}

	#endregion

}
