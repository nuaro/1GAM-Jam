using UnityEngine.Assertions;

public class StateMachine<T>  where T : class {

	#region ====================== vars private ===========================
	// reference to the agaent that owner of the fsm intance
	private T  m_pOwner; 

	// current state
	private State<T> m_pCurrentState;

	// previous state 
	private State<T> m_pPreviousState;

	// global state, this state is called always the fsm is updated
	private State<T> m_pGlobalState;


	#endregion

	#region ==========================public methods =========================
	// constructor
	public StateMachine (T owner){

		this.m_pOwner = owner;
		this.m_pCurrentState = null;
		this.m_pPreviousState = null;
		this.m_pGlobalState = null;
		
	}

	// use this method to init the fsm 
	public void SetCurrentState(State<T> s) {
		this.m_pCurrentState = s;
	}

	public void SetGlobalState(State<T> s) {
		this.m_pGlobalState = s;
	}

	public void SetPreviousState(State<T> s) {
		this.m_pPreviousState = s;
	}
	//geters
	public State<T> GetCurrentState() {
		return this.m_pCurrentState;
	}

	public  State<T> GetGlobalState() {
		return this.m_pGlobalState;
	}

	public  State<T> GetPreviousState() {
		return this.m_pPreviousState;
	}


	// call this to update the fsm, the best place to put it is on the owner object update
	public void OnUpdate() {
		//if global state exist , call its execute method
		if(m_pGlobalState !=null){
			m_pGlobalState.Execute(m_pOwner);
		}

		// same for the current state
		if(m_pCurrentState != null){
			m_pCurrentState.Execute(m_pOwner);
		}
	}

	// change to new state
	public void ChangeState(State<T> pNewState){
			//check if the current and newstate are not null
			Assert.IsNotNull(pNewState);
			Assert.IsNotNull(m_pCurrentState);

			// save the current as previous state
			m_pPreviousState = m_pCurrentState;

			//call the exit method of the current state
			m_pCurrentState.Exit(m_pOwner);

			//change the state to the new state
			m_pCurrentState = pNewState;

			//call the entry method of the new state
			m_pCurrentState.Enter(m_pOwner);


	}

	public void RevertToPreviousState(){
		ChangeState(m_pPreviousState);
	}

	public bool isInState(State<T> st){
			if(st.GetType() == m_pCurrentState.GetType()){
				return true;
			}

			return false;
	}




	#endregion

	
}
