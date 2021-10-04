using Player;
using UnityEngine;
using qASIC.AudioManagment;
using System;

namespace Entity
{
    public class ArsonistController : EntityController
    {
        enum ArsonistState { idle, prepared, lighted };
        ArsonistState currentState = ArsonistState.idle;

        [SerializeField] GameObject matchstick;
        [SerializeField] string channelName;
        [SerializeField] AudioData equipClipData;
        [SerializeField] AudioData deathClipData;

        [Space]
        [SerializeField] Color explosionColor = Color.white;
        [SerializeField] float duration = 0.2f;

        public override void OnPlayerIgnore()
        {
            if (currentState == ArsonistState.lighted) return;
            currentState++;

            switch (currentState)
            {
                case ArsonistState.prepared:
                    AudioManager.Play(channelName, equipClipData);
                    matchstick.SetActive(true);
                    break;
                case ArsonistState.lighted:
                    AudioManager.Play(channelName, deathClipData);
                    if (PlayerDamage.IsGod) return;
                    FadeController.Fade(explosionColor, duration, new Action(() =>
                    {
                        PlayerReference.Singleton?.damage?.KillInstant();
                    }));
                    break;
            }
        }
    }
}