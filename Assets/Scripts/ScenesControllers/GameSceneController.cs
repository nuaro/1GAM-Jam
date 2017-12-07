using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Scenery;

public class GameSceneController :SceneController {

	private static string SceneFileName { get { return "GameScene"; } }


	public PlayerController player;


	#region ===================================== MonoBehaviour ====================================
	protected override void Awake() {
		base.Awake ();
		SceneRepository.LoadScene<Map01SceneController>( true, true, null);
		
	}

	#endregion

	#region static

	public static PlayerController GetMainPlayer(){
		PlayerController _player = null;

		GameSceneController _gameSceneInstance = SceneRepository.GetScene<GameSceneController> ();

		if (_gameSceneInstance != null) {

			_player = _gameSceneInstance.player;

		}

		return _player;

	}

	#endregion

}
