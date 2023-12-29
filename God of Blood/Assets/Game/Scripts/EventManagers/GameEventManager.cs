using UnityEngine;
using UnityEngine.Events;

public class GameEventManager 
{
    public static UnityEvent onBattleStarted = new UnityEvent();
    public static UnityEvent<int> onEnemyDied = new UnityEvent<int>();
    public static UnityEvent onLineupCleared = new UnityEvent();
    public static UnityEvent<int> onNextLevelStarted = new UnityEvent<int>();
    public static UnityEvent<ParticleSystem> onAbilityStartCast = new UnityEvent<ParticleSystem>();

    public static void BattleStartEvent()
    {
        onBattleStarted?.Invoke();
    }

    public static void BloodAddedEvent(int amount)
    {
        onEnemyDied?.Invoke(amount);
    }

    public static void Refresh()
    {
        onLineupCleared?.Invoke();
    }

    public static void IntatiateParticleIvent(ParticleSystem particle)
    {
        onAbilityStartCast?.Invoke(particle);
    }

    public static void InitServices(int amount)
    {
        onNextLevelStarted?.Invoke(amount);
    }
}
