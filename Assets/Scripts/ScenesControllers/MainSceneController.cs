using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Scenery;

public class MainSceneController : SceneController {

	private static string SceneFileName { get { return "MainScene"; } }


	public void OpenExamplePopUp (){

		SceneRepository.LoadScene<PopupExampleController>( true, false, delegate( PopupExampleController popupController ){

			popupController.Present( delegate( int result ){
				ClosePopUpCallback<PopupExampleController>( popupController );
			});
		});
	}

	private void ClosePopUpCallback<T>( PopupController popupController )  where T:SceneController{
		Destroy(popupController.gameObject);
		SceneRepository.UnloadScene<T>();
		SetInteractable( true );
	}

}
