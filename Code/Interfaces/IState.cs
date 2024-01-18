using System;

namespace EmptyFSM
{
    public interface IState : IDisposable
    {
        void Enter();
        void Update();
        void Exit();
    }
}

