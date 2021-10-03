using Player;
using UnityEngine;

namespace Entity
{
    public class ArsonistController : EntityController
    {
        enum ArsonistState { idle, prepared, lighted };
        ArsonistState currentState = ArsonistState.idle;

        public GameObject matchstick;

        public override void OnPlayerIgnore()
        {
            currentState++;

            switch (currentState)
            {
                case ArsonistState.prepared:
                    //Play audio
                    matchstick.SetActive(true);
                    break;
                case ArsonistState.lighted:
                    //Plau audio
                    PlayerReference.Singleton?.damage?.Kill();
                    break;
            }
        }
    }
}