using Game.AbilitySystem.AbilityUI;
using Services.Events;
using Services.Locator;
using UnityEngine;

namespace Levels
{
    public class LevelServices : MonoBehaviour
    {
        [SerializeField] private AbilityDisplaying _abilityDisplaying;

        private ServiceLocator _serviceLocator;

        private LevelEvents _levelEvents;

        public void InitiailizeServices(GameInstance gameInstance)
        {
            _serviceLocator = new ServiceLocator();

            _serviceLocator.RegisterService<GameInstance>(gameInstance);

            RegistrationOfServices();
            InjectServicesInSceneObjects();
        }

        private void RegistrationOfServices()
        {
            _levelEvents = new LevelEvents();

            _serviceLocator
                .RegisterService<ILevelEvents>(_levelEvents)
                .RegisterService<ILevelEventsExec>(_levelEvents)
                .RegisterService<AbilityDisplaying>(_abilityDisplaying);
        }

        private void InjectServicesInSceneObjects()
        {
            foreach (var monoBehavior in FindObjectsOfType<MonoBehaviour>())
            {
                if(monoBehavior is IInjectServices dependency)
                {
                    dependency.Inject(_serviceLocator);
                }
            }
        }

        public IServiceLocator GetServiceLocator() => _serviceLocator;

    }
}