using System;

[Serializable]
public class TileStateMachine
{
    public ITileState CurrentState { get; private set; }

    public TileNormalState normalState;
    public TileHoverState hoverState;

    public event Action<ITileState> stateChanged;

    public TileStateMachine(TileStateHandler stateHandler)
    {
        this.normalState = new TileNormalState(stateHandler);
        this.hoverState = new TileHoverState(stateHandler);
    }

    public void Initialize(ITileState state)
    {
        CurrentState = state;
        state.EnterState();

        stateChanged?.Invoke(state);
    }

    public void TransitionTo(ITileState nextState)
    {
        CurrentState.ExitState();
        CurrentState = nextState;
        nextState.EnterState();

        stateChanged?.Invoke(nextState);
    }
}
