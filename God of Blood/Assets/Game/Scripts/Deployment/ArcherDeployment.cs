using GodofBlood.Deployment;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Deployment
{
    public class ArcherDeployment : TroopsDeploymentGrids
    {
        [SerializeField] private TroopsGroupConfig _archerGroupConfig;
        private int _archerQuantity;
        private int _archerQuantityDeploied;

        protected override void Awake()
        {
            RefrashQuantity();
            base.Awake();
        }

        //protected override void Start()
        //{
        //    GameEventManager.onLineupCleared.AddListener(RefrashQuantity);
        //}

        protected override void Start()
        {
            _archerQuantityDeploied = 0;
            GameEventManager.onLineupCleared.AddListener(RefrashQuantity);
            GameEventManager.onBattleStarted.AddListener(DeleteGroupQuantity);
        }

        protected override void DeleteGroupQuantity()
        {
            _archerGroupConfig.Quantity -= _archerQuantityDeploied;
        }

        protected override void Update()
        {
            if (Input.GetKeyDown(_archerGroupConfig.HotKey))
            {
                StartDeployGroup();
            }
            base.Update();
        }

        public override void StartDeployGroup()
        {
            if (_archerQuantity > 0)
            {
                base.StartDeployGroup();
            }
        }

        protected override void PlaceFlyingBuilding(int placeX, int placeY)
        {
            base.PlaceFlyingBuilding(placeX, placeY);
            _archerQuantity--;
            _archerQuantityDeploied++;
        }

        private void RefrashQuantity()
        {
            _archerQuantity = _archerGroupConfig.Quantity;
        }
    }
}