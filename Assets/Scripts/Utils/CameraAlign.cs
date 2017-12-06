using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum direction_to_move {
	up,
	down,
	left,
	right
}

public class CameraAlign : MonoBehaviour {

	private Vector3 currentPosition;

	private System.Action endMoveCallback = null;

	public float alignDuration = 1f;



	#region ===================================== MonoBehaviour ====================================
	void Awake(){

		currentPosition = transform.position;

	}
	#endregion


	public void SetNewPosition(direction_to_move move, System.Action callback){

		if (callback != null) {
			endMoveCallback = callback;
		}



		switch (move) {
			case direction_to_move.down:
				currentPosition.y -= 480;
			break;
			case direction_to_move.left:
				currentPosition.x -= 640;
			break;
			case direction_to_move.right:
				currentPosition.x += 640;
			break;
			case direction_to_move.up:
				currentPosition.y += 480;
			break;
		}


		StartCoroutine (AlignToNewPosition ());

	}

	IEnumerator AlignToNewPosition(){

		Vector3 startVect = transform.position;
		Vector3 trackingVect = transform.position;

		float lerpTime = 0;

		while (lerpTime < alignDuration) {
			lerpTime += Time.deltaTime;
			trackingVect = Vec3Lerp (lerpTime, alignDuration, startVect, currentPosition);
			transform.position = trackingVect;
			yield return 0;
		}


		transform.position = currentPosition;


		if (endMoveCallback != null) {
			endMoveCallback ();

			endMoveCallback = null;
		}
	}

	public static Vector3 Vec3Lerp(float currentTime, float duration, Vector3 v3_start, Vector3 v3_target){
		float step = (currentTime/duration);
		Vector3 v3_ret = Vector3.Lerp(v3_start, v3_target, step);
		return v3_ret;
	}

}
