using UnityEngine;
using UnityEngine.UI;

public class UIUnitsCounter : MonoBehaviour
{
    [SerializeField] private Text _EnemyUnitCountText;
    [SerializeField] private Text _PlayerUnitCountText;

    private void Awake()
    {
        UIEventManager.onEnemyUnitCounted.AddListener(OutputEnemyUnitCount);
        UIEventManager.onPlayerUnitCounted.AddListener(OutputPlayerUnitCount);
    }

    private void OutputEnemyUnitCount(int unit)
    {
        _EnemyUnitCountText.text = "Enemy units: " + unit.ToString();
    }

    private void OutputPlayerUnitCount(int unit)
    {
        _PlayerUnitCountText.text = "Player units: " + unit.ToString();
    }
}
