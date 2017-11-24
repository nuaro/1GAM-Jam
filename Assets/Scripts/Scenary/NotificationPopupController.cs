using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Base.Scenery;

namespace Base.Scenery
{

	public class NotificationPopupController : PopupController
	{
		private static string SceneFileName { get { return "NotificationPopup"; } }

		#region ===================================== constants =====================================

		private const string ON_TEXT = "ON";
		private const string OFF_TEXT = "OFF";

		#endregion

		#region ===================================== Editor Variables =====================================

		[SerializeField]
		protected Text titleText;

		[SerializeField]
		protected Text descriptionText;

		[SerializeField]
		protected GameObject okButton;
		[SerializeField]
		protected Text okText;

		[SerializeField]
		protected GameObject cancelButton;
		[SerializeField]
		protected Text cancelText;
		
		#endregion
		
		#region ===================================== Local Variables =====================================

		private System.Action okActionCallback = null;
		private System.Action cancelActionCallback = null;

		#endregion
		
		#region ===================================== MonoBehaviour =====================================

		void Start() {
		}

		#endregion

		#region ===================================== Init =====================================

		public void Init( string title , string description , string ok , System.Action okCallback , string cancel , System.Action cancelCallback ) {
			titleText.text = title;
			descriptionText.text = description;
			okText.text = ok;
			okActionCallback = okCallback;
			cancelText.text = cancel;
			cancelActionCallback = cancelCallback;
		}

		public void Init( string title , string description , string ok , System.Action okCallback ) {
			titleText.text = title;
			descriptionText.text = description;
			okText.text = ok;
			okActionCallback = okCallback;
			okButton.transform.localPosition = new Vector2 (0, okButton.transform.localPosition.y);
			cancelButton.SetActive (false);
		}

		#endregion
		
		#region ===================================== Buttons =====================================
		
		public void OkButtonAction() {
			if (okActionCallback != null) {
				okActionCallback ();
			}
			Dismiss();
		}

		public void cancelButtonAction() {
			if (cancelActionCallback != null) {
				cancelActionCallback ();
			}
			Dismiss();
		}
	
		#endregion
    
    }

}
