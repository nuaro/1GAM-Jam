using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State<PlayerController> {

	public static readonly float AttackCD = 0.2f;

	public bool attacking {get; private set;}

	private float attackTimer = 0.0f;

	private static AttackState instance;

	private AttackState() {}


	public static AttackState Instance {
		get{

			if (instance == null){
				instance = new AttackState();
			}

			return instance;

		}
	}


	public override void Enter (PlayerController player)
	{
		attacking = false;



	}

	public override void Execute (PlayerController player){


		if (!attacking) {
			attackTimer = AttackCD;
			attacking = true;
		} else {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				player.GetFSM ().ChangeState (MoveState.Instance);
			}
		}

		player.Attack (attacking);


	}

	public override void Exit (PlayerController player){


		//set idle position back ??
		player.Attack (attacking);
	}
}
