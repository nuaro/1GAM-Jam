using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Trigger helper. to acces trigers from another class 
/// example usage add to a object thart need to lisen the trigger
/// to do action like change scene , start animation etc..
/// </summary>
public class TriggerHelper : MonoBehaviour {

	public event Action<Collider2D> onTriggerEnterEvent;
	public event Action<Collider2D> onTriggerStayEvent;
	public event Action<Collider2D> onTriggerExitEvent;

	#region MonoBehavior

	void OnTriggerEnter2D( Collider2D col )
	{
		if( onTriggerEnterEvent != null )
			onTriggerEnterEvent( col );
		
	}


	void OnTriggerStay2D( Collider2D col )
	{
		if( onTriggerStayEvent != null )
			onTriggerStayEvent( col );
		
	}


	void OnTriggerExit2D( Collider2D col )
	{
		if( onTriggerExitEvent != null )
			onTriggerExitEvent( col );
		
	}

	#endregion
}
