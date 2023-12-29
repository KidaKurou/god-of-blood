using Services.Events;
using Services.Locator;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels
{
    public class LevelInstance : MonoBehaviour
    {
        public GameInstance GameInstance { get; private set; }

        [SerializeField] private LevelServices _levelServices;

        private IServiceLocator _serviceLocator;
        private ILevelEventsExec _levelEventsExec;

        public void Init(GameInstance gameInstance)
        {
            GameInstance = gameInstance;

            _levelServices.InitiailizeServices(gameInstance);
            _serviceLocator = _levelServices.GetServiceLocator();

            _levelEventsExec = _serviceLocator.GetService<ILevelEventsExec>();


            _levelEventsExec.OnLevelReady();
        }

        private void Start()
        {
            var gameInstance = FindObjectOfType<GameInstance>();

            if (gameInstance == null)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}