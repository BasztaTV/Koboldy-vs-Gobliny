using G.K.S.InputManager;
using UnityEngine;

namespace G.K.S.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;

        public Transform playerUnits;
        public Transform enemyUnits;

        private void Awake()
        {
            instance = this;
            Units.UnitHandler.instance.SetBasicUnitStats(playerUnits);
            Units.UnitHandler.instance.SetBasicUnitStats(enemyUnits);

        }

        private void Start()
        {
            
        }


        private void Update()
        {
            InputHandler.instance.HandleUnitMovement();
        }
    }
}

