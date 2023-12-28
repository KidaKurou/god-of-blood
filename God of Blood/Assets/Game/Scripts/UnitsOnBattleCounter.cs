using UnityEngine;

public class UnitsOnBattleCounter : MonoBehaviour
{
    [SerializeField] private GameObject _EnemyContainer;
    [SerializeField] private GameObject _PlayerUnitContainer;

    private void Awake()
    {
        GameEventManager.onBattleStarted.AddListener(PlayerUnitsCounter);
        GameEventManager.onBattleStarted.AddListener(EnemyUnitsCounter);
    }

    private void Update()
    {
        PlayerUnitsCounter();
        EnemyUnitsCounter();
    }
    private void PlayerUnitsCounter()
    {
        AbstractUnit[] units = _PlayerUnitContainer.GetComponentsInChildren<AbstractUnit>();
        int count = units.Length;
        UIEventManager.PlayerUnitCounterEvent(count);
        //Debug.Log($"player {count}");

        if (count <= 0)
        {
            UIEventManager.PlayerUnitDeadEvent();
        }
    }

    private void EnemyUnitsCounter()
    {
        AbstractUnit[] units = _EnemyContainer.GetComponentsInChildren<AbstractUnit>();
        int count = units.Length;
        UIEventManager.EnemyUnitCounterEvent(count);
        //Debug.Log($"enemy {count}");

        if (count <= 0)
        {
            UIEventManager.EnemyUnitDeadEvent();
        }
    }
}
