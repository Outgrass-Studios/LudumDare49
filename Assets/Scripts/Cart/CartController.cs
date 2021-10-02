using UnityEngine;
using System;
using Player;

public class CartController : MonoBehaviour
{
    [SerializeField] Transform cart;
    [SerializeField] Vector3 cameraRotation;
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] CartAnimation startAnimation;
    [SerializeField] CartAnimation endAnimation;

    CartAnimation currentAnimation;
    Transform cameraTransform;
    float time;

    public static bool PlayAnimationOnAwake { get; set; } = true;
    public static CartController Singleton { get; private set; }
    public int remainingTasks;

    public Action OnEndAnimation;

    [System.Serializable]
    class CartAnimation
    {
        public Vector3 startPoint;
        public Vector3 endPoint;
        public AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        public float duration = 5f;

        public void DrawGizmos(Transform transform, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawSphere(transform.position + startPoint, 0.1f);
            Gizmos.DrawSphere(transform.position + endPoint, 0.1f);
        }

        public Vector3 LerpPosition(float time) =>
            Vector3.Lerp(startPoint, endPoint, curve.Evaluate(time / duration));
    }

    public bool IsAnimating() =>
        currentAnimation != null;

    private void Awake()
    {
        AssignSingleton();
        if (!PlayAnimationOnAwake) return;
        
        PlayAnimation(startAnimation);
        OnEndAnimation = new Action(() => 
        { 
            PlayerReference.Singleton?.camAnimator?.ResetCameraSmooth(new Action(() => 
            {
                CursorManager.ChangeLookState("cart", true);
                CursorManager.ChangeMovementState("cart", true);
            }));
        });
    }

    void AssignSingleton()
    {
        if(Singleton == null)
        {
            Singleton = this;
            return;
        }

        if (Singleton != this)
            Destroy(gameObject);
    }

    void PlayAnimation(CartAnimation animation)
    {
        currentAnimation = animation;
        time = 0f;
        cameraTransform = Player.PlayerReference.Singleton.cam.transform;
        if (cameraTransform != null) cameraTransform.eulerAngles = cameraRotation;
        CursorManager.ChangeLookState("cart", false);
        CursorManager.ChangeMovementState("cart", false);

        OnEndAnimation = new Action(() =>
        {
            CursorManager.ChangeLookState("cart", true);
            CursorManager.ChangeMovementState("cart", true);
        });
    }

    private void Update()
    {
        if (currentAnimation == null) return;
        time += Time.deltaTime;
        cart.position = transform.position + currentAnimation.LerpPosition(time);
        if (cameraTransform != null) cameraTransform.position = cart.position + cameraOffset;

        if (time < currentAnimation.duration) return;
        currentAnimation = null;
        OnEndAnimation?.Invoke();
        OnEndAnimation = new Action(() => { });
    }

    private void OnDrawGizmosSelected()
    {
        startAnimation.DrawGizmos(transform, Color.white);
        endAnimation.DrawGizmos(transform, Color.black);
    }

    private void OnDestroy()
    {
        CursorManager.ChangeLookState("cart", true);
        CursorManager.ChangeMovementState("cart", true);
    }
}