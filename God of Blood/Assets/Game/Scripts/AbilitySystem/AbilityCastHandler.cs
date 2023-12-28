using Game.AbilitySystem.AbilityUI;
using Services.Locator;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.AbilitySystem
{
    public class AbilityCastHandler : MonoBehaviour, IInjectServices
    {
        [SerializeField] private AbilityDisplaying _abilityDisplaying;
        [SerializeField] private AbilityStorage _abilityStorage;
        [SerializeField] private AbstractUnit _unit;
        [SerializeField] private LayerMask _targetLayer;

        private List<AbstractUnit> _targets = new List<AbstractUnit>();
        private List<Ability> _abilities = new();
        private Ability _currentAbility;

        private Camera _camera;

        public void Inject(IServiceLocator locator)
        {
            _camera = Camera.main;
            _abilityDisplaying = locator.GetService<AbilityDisplaying>();

            _abilityStorage.Init();
            _abilities.AddRange(_abilityStorage.GetAbilities());

            _abilityDisplaying.Init(_abilityStorage.GetAbilities());
            _abilityDisplaying.OnClickAbility += OnClickAbilityButton;
        }

        public void OnClickAbilityButton(int abilityIndex)
        {
            _currentAbility?.CancelCast();

            switch (_abilities[abilityIndex].Status)
            {
                case EAbilityStatus.Ready:
                    _currentAbility = _abilities[abilityIndex];
                    //_currentAbility.StartCast(_currentAbility.AreaParticle);
                    _currentAbility.StartCast();

                    break;
                case EAbilityStatus.Cooldown:
                    break;
                case EAbilityStatus.NeedMana:
                    break;
                default:
                    break;
            }
        }

        private void Update()
        {
            for (int i = 0; i < _abilities.Count; i++)
            {
                _abilities[i].EventTick(Time.deltaTime);

                if (Input.GetKeyDown(_abilities[i].Hotkey))
                {
                    OnClickAbilityButton(i);
                }
            }

            if (_currentAbility != null)
            {

                //Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                //var groundPlane = new Plane(Vector3.up, Vector3.zero);

                //if (groundPlane.Raycast(ray, out float position))
                //{
                //    Vector3 worldPosition = ray.GetPoint(position);

                //    _currentAbility.AreaParticle.transform.position = new Vector3(worldPosition.x, 1f, worldPosition.z);

                //}

                if (Input.GetMouseButtonDown(1))
                {
                    _currentAbility.CancelCast();
                    _currentAbility = null;
                    return;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit[] hitresult = Physics.SphereCastAll(ray, _currentAbility.AreaRadius, 500f, _targetLayer);

                    for (int i = 0; i < hitresult.Length; i++)
                    {
                        _targets.Add(hitresult[i].collider.GetComponent<AbstractUnit>());

                    }
                    if (_currentAbility.CheckCondition(_unit, _targets))
                    {
                        _currentAbility.ApplyCast();
                        _targets.Clear();
                        _currentAbility = null;
                    }
                }

            }
        }

        //private void OnDestroy()
        //{
        //    _abilityDisplaying.OnClickAbility -= OnClickAbilityButton;
        //}
    }
}