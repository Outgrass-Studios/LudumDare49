using UnityEngine;
using System;

namespace Player
{
    public class PlayerCameraAnimator : MonoBehaviour
    {
        [SerializeField] AnimationCurve curve;
        [SerializeField] [Min(0.01f)] float duration;

        Vector3 startPosition;
        Vector3 endPosition;
        Quaternion startRotation;
        Quaternion endRotation;

        public Action OnEndAnimation;

        bool animating;
        float time;

        public void ResetCamera()
        {
            transform.localPosition = Vector3.zero;
        }

        public void AnimateToPosition(Vector3 pos, Quaternion rot, Action onEnd)
        {
            startPosition = transform.localPosition;
            endPosition = pos;
            startRotation = transform.rotation;
            endRotation = rot;
            OnEndAnimation = onEnd;
            animating = true;
        }

        public void AnimateToPosition(Vector3 pos, Quaternion rot) =>
            AnimateToPosition(pos, rot, new Action(() => { }));

        public void ResetCameraSmooth(Action onEnd) =>
            AnimateToPosition(Vector3.zero, Quaternion.identity, onEnd);

        public void ResetCameraSmooth() =>
            AnimateToPosition(Vector3.zero, Quaternion.identity);

        private void Update()
        {
            if (!animating) return;

            time += Time.deltaTime;
            float value = curve.Evaluate(time / duration);
            transform.localPosition = Vector3.Lerp(startPosition, endPosition, value);
            transform.localRotation = Quaternion.Lerp(startRotation, endRotation, value);

            if (time < duration) return;
            animating = false;
            OnEndAnimation?.Invoke();
        }
    }
}