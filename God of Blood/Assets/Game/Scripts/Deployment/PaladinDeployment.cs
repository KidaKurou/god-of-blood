using GodofBlood.Deployment;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Deployment
{
    public class PaladinDeployment : TroopsDeploymentGrids
    {
        [SerializeField] private TroopsGroupConfig _paladinGroupConfig;
       
        private int _paladinQuantity;

        protected override void Awake()
        {
            RefrashQuantity();
            base.Awake();
        }

        protected override void Start()
        {
            GameEventManager.onLineupCleared.AddListener(RefrashQuantity);
        }

        protected override void Update()
        {
            if (Input.GetKeyDown(_paladinGroupConfig.HotKey))
            {
                StartDeployGroup();
            }
            base.Update();
        }

        public override void StartDeployGroup()
        {
            if (_paladinQuantity > 0)
            {
                base.StartDeployGroup();
            }
        }

        protected override void PlaceFlyingBuilding(int placeX, int placeY)
        {
            base.PlaceFlyingBuilding(placeX, placeY);
            _paladinQuantity --;
        }

        private void RefrashQuantity()
        {
            _paladinQuantity = _paladinGroupConfig.Quantity;
        }
    }
}