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

		if(Input.GetButtonDown("Attack") ){

			player.GetFSM ().ChangeState (AttackState.Instance);

		}

		if (Input.GetButtonDown ("Roll")) {

			player.GetFSM ().ChangeState (RollState.Instance);

		}

	}

	public override void Exit (PlayerController player){



	}
}
