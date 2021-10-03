using UnityEngine;
using Entity;
using qASIC;

namespace Triggers
{
    public class EntityTrigger : MonoBehaviour
    {
        [SerializeField] EntityController target;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player") || target == null) return;
            qDebug.Log($"[{target.name}] state has been changed to active", "trigger");
            target.Active = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player") || target == null) return;
            qDebug.Log($"[{target.name}] state has been changed to inactive", "trigger");
            target.Active = false;
        }
    }
}