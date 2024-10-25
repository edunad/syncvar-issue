using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;

namespace SyncVarIssue
{
    public class SyncVarTester : NetworkBehaviour
    {
        private readonly SyncVar<int> _pressed = new SyncVar<int>();

        private void Awake()
        {
            this._pressed.OnChange += (int prevVal, int newVal, bool server) =>
            {
                Debug.Log(prevVal + " " + newVal + "  -> " + server);
            };
        }
        void Update()
        {
            if (IsServerInitialized && Input.GetKeyDown(KeyCode.K))
                _pressed.Value = Random.Range(0, 99999);
        }
    }
}
