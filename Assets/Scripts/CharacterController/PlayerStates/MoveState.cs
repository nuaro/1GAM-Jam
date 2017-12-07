using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State<PlayerController> {

	private static MoveState instance;

	private MoveState() {}


	public static MoveState Instance {
		get{

			if (instance == null){
				instance = new MoveState();
			}

			return instance;

		}
	}

	public override void Enter (PlayerController player)
	{




	}

	public override void Execute (PlayerController player){

		player.Move ();

//		if(Input.GetButtonDown("Attack") ){
//
//			//player.GetFSM ().ChangeState (MoveState.Instance);
//
//		}
//
//		if (Input.GetButtonDown ("Roll")) {
//		}

	}

	public override void Exit (PlayerController player){



	}
}
