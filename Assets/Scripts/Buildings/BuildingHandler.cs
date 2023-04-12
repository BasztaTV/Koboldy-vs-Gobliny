using UnityEngine;

namespace G.K.S.Buildings
{
    public class BuildingHandler : MonoBehaviour
    {
        public static BuildingHandler instance;

        [SerializeField]
        private BasicBuilding barraks;

        private void Awake()
        {
            instance = this;
        }

        public BuildingStatTypes.Base GetBasicBuildingStats(string type)
        {
            BasicBuilding building;
            switch (type)
            {
                case "barraks":
                    building = barraks;
                    break;
                default:
                    Debug.Log($"Unit Type: {type} could not be found or does not exist!");
                    return null;
            }
            return building.baseStats;
        }


    }
}