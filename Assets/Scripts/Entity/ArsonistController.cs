using System.Collections;
using System.Collections.Generic;
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
                case ArsonistState.lighted:
                    //Play audio
                    matchstick.SetActive(true);
                    break;
                case ArsonistState.prepared:
                    //Plau audio
                    //kill
                    break;
            }
        }
    }
}