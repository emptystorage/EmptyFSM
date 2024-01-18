using System;
using System.Collections.Generic;
using UnityEngine;

using EmptyFSM.Code;

namespace EmptyFSM
{
    public static class EmptyFSMConnector
    {
        public static void BindMachine<T>(this T owner)
            where T : IStateMachineOwner
        {
            MachineContainer<T>.AddMachine(owner);
        }

        public static void ForgetMachine<T>(this T owner)
            where T : IStateMachineOwner
        {
            MachineContainer<T>.RemoveMachine(owner);
        }

        public static void ChangeState<T, S>(this T owner)
            where T : IStateMachineOwner 
            where S : BaseState<T>, new()
        {
            var machine = MachineContainer<T>.GetMachine(owner);
            var state = Activator.CreateInstance<S>();
            state.Owner = owner;

            machine.ChangeState(state);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            var machineProcessor = new GameObject(nameof(MachineProcessor)).AddComponent<MachineProcessor>();
            MonoBehaviour.DontDestroyOnLoad(machineProcessor);
        }

        private static class MachineContainer<T>
            where T : IStateMachineOwner
        {
            private static Dictionary<int, StateMachine> MachineTable = new Dictionary<int, StateMachine>();

            public static void AddMachine(IStateMachineOwner owner)
            {
                if (!MachineTable.ContainsKey(owner.GetHashCode()))
                {
                    var machine = new StateMachine();
                    MachineProcessor.Instance.OnUpdate += machine.Update;
                    MachineTable.Add(owner.GetHashCode(), machine);
                }
            }

            public static StateMachine GetMachine(IStateMachineOwner owner)
            {
                if(!MachineTable.TryGetValue(owner.GetHashCode(), out var machine))
                {
                    throw new NullReferenceException($"[EmptyFSM]: Контейнер не содержит FSM-машину для объекта с типом - {owner.GetType().Name}");
                }

                return machine;
            }

            public static void RemoveMachine(IStateMachineOwner owner)
            {
                if(MachineTable.TryGetValue(owner.GetHashCode(), out var machine))
                {
                    MachineProcessor.Instance.OnUpdate -= machine.Update;
                }

                MachineTable.Remove(owner.GetHashCode());
            }
        }
    }
}
