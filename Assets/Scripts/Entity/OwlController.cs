using Mechanics;
using UnityEngine;
using System;
using System.Collections;

namespace Entity
{
    public class OwlController : EntityController
    {
        [SerializeField] Color fadeColor = Color.black;
        [SerializeField] float fadeDuration = 0f;
        [SerializeField] float waitDuration = 1f;

        public override void OnPlayerIgnore()
        {
            if (LightManager.enabledSwitches.Count > 1)
            {
                LightManager.DisableRandom();
                return;
            }

            CursorManager.ChangeMovementState("death", true);
            CursorManager.ChangeLookState("death", true);

            FadeController.Fade(fadeColor, fadeDuration, new Action(() =>
            {
                StartCoroutine(WaitForKill());
            }));
        }

        IEnumerator WaitForKill()
        {
            yield return new WaitForSeconds(waitDuration);
            Player.PlayerReference.Singleton.damage.KillInstant();
        }
    }
}