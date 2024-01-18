using System;
using UnityEngine;

namespace EmptyFSM.Code
{
    public sealed class MachineProcessor : MonoBehaviour
    {
        public static MachineProcessor Instance;

        public event Action OnUpdate;

        private void Start()
        {
            Instance = this;
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}
