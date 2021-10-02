using Player;
using UnityEngine;
using qASIC;

namespace Entity
{
    public class BuildermanController : EntityController
    {
        [SerializeField] GameObject brickPrefab;
        [SerializeField] float brickSpawnRadius = 0.5f;
        [SerializeField] float brickForceMultiplier = 0.5f;

        public override void OnPlayerIgnore()
        {
            Transform cam = PlayerReference.Singleton?.cam?.transform;
            if(cam == null)
            {
                qDebug.LogError("Camera has not been assigned!");
                return;
            }

            Vector3 force = (transform.position - cam.position).normalized;

            GameObject brick = Instantiate(brickPrefab, cam.position + force * brickSpawnRadius, Quaternion.identity);

            Rigidbody rb = brick.GetComponent<Rigidbody>();
            if (rb == null)
            {
                qDebug.LogError("Brick rigidbody has not been assigned!");
                return;
            }

            rb.AddForce(force * brickForceMultiplier, ForceMode.Impulse);
        }
    }
}