using UnityEngine.Events;

public class UIEventManager 
{
    public static UnityEvent<int> onPlayerUnitCounted = new UnityEvent<int>();
    public static UnityEvent<int> onEnemyUnitCounted = new UnityEvent<int>();
    public static UnityEvent<int> onBloodBankChanged = new UnityEvent<int>();
    public static UnityEvent onPlayerUnitsDead = new UnityEvent();
    public static UnityEvent onEnemyUnitsDead = new UnityEvent();

    public static void PlayerUnitCounterEvent(int unit)
    {
        onPlayerUnitCounted?.Invoke(unit);
    }

    public static void EnemyUnitCounterEvent(int unit)
    {
        onEnemyUnitCounted?.Invoke(unit);
    }

    public static void BloodBankEvent(int unit)
    {
        onBloodBankChanged?.Invoke(unit);
    }

    public static void PlayerUnitDeadEvent()
    {
        onPlayerUnitsDead?.Invoke();
    }

    public static void EnemyUnitDeadEvent()
    {
        onEnemyUnitsDead?.Invoke();
    }
}
