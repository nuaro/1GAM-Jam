using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState :  State<PlayerController> {

	private static RollState instance;

	private RollState() {}


	public static RollState Instance {
		get{

			if (instance == null){
				instance = new RollState();
			}

			return instance;

		}
	}


	public static readonly float rollCD = 0.3f;

	public bool rolling {get; private set;}

	private float rollTimer = 0.0f;

	public override void Enter (PlayerController player)
	{


		rolling = false;

	}

	public override void Execute (PlayerController player){

		if (!rolling) {
			rollTimer = rollCD;
			rolling = true;
		} else {
			if (rollTimer > 0) {
				rollTimer -= Time.deltaTime;
			} else {
				rolling = false;
				player.GetFSM ().ChangeState (MoveState.Instance);
			}
		}

		player.Roll (rolling);

	}

	public override void Exit (PlayerController player){


		player.Roll (rolling);
	}
}
