

public abstract class State<T>   where T : class {


	public abstract void Enter(T Owner);

	public abstract void Execute(T Owner);

	public abstract void Exit(T Owner);

	
}
