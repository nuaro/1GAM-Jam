using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Scenery;

public class PopupExampleController : PopupController {
	private static string SceneFileName { get { return "PopUpExample"; } }



	public void CloseButton() {

		Dismiss ();
	}
}
