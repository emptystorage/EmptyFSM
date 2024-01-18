using System;

namespace EmptyFSM.Code
{
    public sealed class StateMachine : IStateMachine
    {
        public StateMachine() { }

        public IState CurrentState { get; private set; }

        public void ChangeState<T>(T state) where T : IState
        {
            if(CurrentState != null 
                && CurrentState.GetType().Equals(typeof(T)))
            {
                return;
            }

            CurrentState?.Exit();
            CurrentState?.Dispose();

            CurrentState = state;
            CurrentState?.Enter();
        }

        public void Dispose()
        {
            CurrentState?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Update() => CurrentState?.Update();
    }
}
