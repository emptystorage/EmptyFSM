﻿using System;

namespace EmptyFSM
{
    public abstract class BaseState<T> : IState
        where T : IStateMachineOwner
    {
        public T Owner { get; set; }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}