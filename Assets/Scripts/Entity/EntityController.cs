using qASIC;
using UnityEngine;
using Player;
using System;

namespace Entity
{
    public abstract class EntityController : MonoBehaviour
    {
        public bool Active { get; set; } = true;
        [SerializeField] Collider entityCollider;
        [SerializeField] float maxPatience = 20f;
        [SerializeField] float resetPatience = 30f;
        [SerializeField] float defaultPatience = 10f;
        [SerializeField] float impatienceRange = 10f;
        [SerializeField] float noticeMultiplier = 1f;

        float currentPatience;
        float impatienceValue;

        public static Action OnEntityReset;

        public static int AILevel { get; set; } = 1;

        public virtual void ResetEntity() 
        {
            currentPatience = defaultPatience;
            ResetImpatienceValue();
        }

        /// <summary>Triggered when player ignores entity</summary>
        public virtual void OnPlayerIgnore() { }

        public bool IsRendered()
        {
            if (entityCollider == null) return true;

            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(PlayerReference.Singleton.cam.TargetCamera);
            return GeometryUtility.TestPlanesAABB(planes, entityCollider.bounds);
        }

        private void Reset()
        {
            entityCollider = GetComponent<Collider>();
        }

        void ResetImpatienceValue() =>
            impatienceValue = UnityEngine.Random.Range(0f, -impatienceRange);

        public virtual void Awake()
        {
            if (entityCollider == null)
                qDebug.LogError("Renderer not assigned!");

            ResetEntity();

            OnEntityReset += ResetEntity;
        }

        private void OnDestroy()
        {
            OnEntityReset -= ResetEntity;
        }

        public virtual void FixedUpdate()
        {
            if (AILevel <= 0 || PlayerReference.IsAnimated || !Active) return;

            if(IsRendered())
            {
                if (currentPatience > maxPatience) return;
                currentPatience += Time.fixedDeltaTime * noticeMultiplier;
                return;
            }

            currentPatience -= Time.fixedDeltaTime;

            if (currentPatience > impatienceValue) return;
            OnPlayerIgnore();
            currentPatience = resetPatience;
            ResetImpatienceValue();
            qDebug.Log($"[{GetType()}] Entity impatience triggered, impatience level has been reset to {currentPatience}", "entity");
        }
    }
}