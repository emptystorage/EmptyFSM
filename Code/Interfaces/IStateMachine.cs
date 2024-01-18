using System;

namespace EmptyFSM
{
    public interface IStateMachine : IDisposable
    {
        IState CurrentState { get; }

        void ChangeState<T>(T state) where T : IState;
        void Update();
    }
}
