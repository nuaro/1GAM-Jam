using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Scenery;

/// <summary>
/// Init scene controller.
/// simple example scene 
/// recomended to initialize here data managaers and other things that are needed 
/// to intialize first
/// </summary>

public class InitSceneController : SceneController {

	private static string SceneFileName { get { return "InitScene"; } }

	#region ===================================== Editor Variables =====================================

	//this is optional paramether only to waith and change scene aoutomatically
	[SerializeField]
	private float waitDuration = 3.0f;

	#endregion

	#region ===================================== MonoBehaviour ====================================

	protected override void Awake() {
		base.Awake ();
		StartCoroutine (InitCoroutine ());
	}

	#endregion

	#region ===================================== Others ====================================

	IEnumerator InitCoroutine() {


		yield return new WaitForSeconds(waitDuration);
		SceneService.LoadScene<InitSceneController,MainSceneController,TransitionSceneController>(false, null);
	}

	#endregion

}
