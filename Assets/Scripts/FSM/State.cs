

public abstract class State<T>   where T : class {


	public abstract void Enter(T Miner);

	public abstract void Execute(T Miner);

	public abstract void Exit(T Miner);

	
}
