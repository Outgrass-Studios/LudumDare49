using qASIC;
using UnityEngine;

namespace Entity
{
    public abstract class EntityController : MonoBehaviour
    {
        [SerializeField] Renderer entityRenderer;
        [SerializeField] float maxPatience = 20f;
        [SerializeField] float resetPatience = 30f;
        [SerializeField] float defaultPatience = 10f;
        [SerializeField] float impatienceRange = 10f;
        [SerializeField] float noticeMultiplier = 1f;

        float currentPatience;
        float impatienceValue;

        /// <summary>Triggered when player ignores entity</summary>
        public virtual void OnPlayerIgnore() { }

        public bool IsRendered() =>
            entityRenderer == null || entityRenderer.isVisible;

        private void Reset()
        {
            entityRenderer = GetComponent<Renderer>();
        }

        public virtual void Awake()
        {
            if (entityRenderer == null)
                qDebug.LogError("Renderer not assigned!");

            currentPatience = defaultPatience;
            impatienceValue = Random.Range(0f, -impatienceRange);
        }

        public virtual void FixedUpdate()
        {
            if(IsRendered())
            {
                currentPatience = Mathf.Clamp(currentPatience + Time.fixedDeltaTime * noticeMultiplier, float.MinValue, maxPatience);
                return;
            }

            currentPatience -= Time.fixedDeltaTime;

            if (currentPatience > impatienceValue) return;
            OnPlayerIgnore();
            currentPatience = resetPatience;
            qDebug.Log($"[{GetType()}] Entity impatience triggered, impatience level has been reset to {currentPatience}", "entity");
        }
    }
}