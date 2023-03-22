using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using G.K.S.InputManager;

namespace G.K.S.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;

        public Transform playerUnits;
        void Start()
        {
            instance = this;
        }


        private void Update()
        {
            InputHandler.instance.HandleUnitMovement();
        }
    }
}

