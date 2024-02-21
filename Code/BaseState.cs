using System;

namespace EmptyFSM
{
    public abstract class BaseState<T> : IState
        where T : IStateMachineOwner
    {
        public T Owner { get; set; }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }

        public virtual void OnDispose() { }

        public void Dispose()
        {
            OnDispose();
            GC.SuppressFinalize(this);
        }
    }
}
