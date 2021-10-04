using System.Collections;
using System;
using UnityEngine;
using qASIC.AudioManagment;

namespace Mechanics
{
    public class LightSwitchController : MonoBehaviour, Interactable
    {
        [SerializeField] bool enabledOnStart;
        [SerializeField] Animator anim;
        [SerializeField] string boolName = "isOn";
        [SerializeField] float animationDuration = 0.25f;
        [SerializeField] GameObject targetLight;
        [SerializeField] AudioClip[] clips;

        AudioSourceController source;

        public bool IsActive { get; set; } = true;

        private void Start()
        {
            index = LightManager.AddSwitch(this);
            if (enabledOnStart)
            {
                IsActive = false;
                targetLight.SetActive(true);
                LightManager.enabledSwitches.Add(index);
            }

            source = GetComponent<AudioSourceController>();
        }

        int index;

        public void DisableSwitch()
        {
            targetLight.SetActive(false);
            anim?.SetBool(boolName, false);
            IsActive = true;
            CartController.Singleton.remainingTasks++;
            LightManager.enabledSwitches.Remove(index);
            PlaySound();
        }

        public void Interact(Action onInteractionDone)
        {
            IsActive = false;
            StartCoroutine(WaitForAnimation(onInteractionDone));
        }

        IEnumerator WaitForAnimation(Action onInteractionDone)
        {
            anim?.SetBool(boolName, true);
            PlaySound();
            yield return new WaitForSeconds(animationDuration);
            onInteractionDone?.Invoke();
            LightManager.enabledSwitches.Add(index);
            CartController.Singleton.remainingTasks--;
            targetLight.SetActive(true);
        }

        void PlaySound()
        {
            if (source?.Target == null || clips.Length == 0) return;

            source.Stop();
            source.Target.clip = clips[UnityEngine.Random.Range(0, clips.Length)];
            source.Play();
        }
    }
}