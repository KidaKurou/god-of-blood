using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleStageChanger : MonoBehaviour
{
    [SerializeField] private GameObject StartBattleButton;
    [SerializeField] private GameObject GridContainer;
    [SerializeField] private GameObject WarGroupsPanel;
    [SerializeField] private GameObject PlayerUnitText;
    [SerializeField] private GameObject EnemyUnitText;
    [SerializeField] private GameObject DeletePlayerUnits;

    [SerializeField] private GameObject BattleEndPanel;
    [SerializeField] private GameObject AbilityPanel;
    [SerializeField] private Text BattleEndText;
    [SerializeField] private Text BloodText;

    [SerializeField] private GameObject MainMenuButton;
    [SerializeField] private GameObject RestartLevelButton;
    [SerializeField] private GameObject NextLevelButton;

    [SerializeField] private Text BloodRewardText;
    [SerializeField] private Text CoinRewardText;

    private void Awake()
    {
        StartBattleButton.SetActive(true);
        GridContainer.SetActive(true);
        WarGroupsPanel.SetActive(true);
        PlayerUnitText.SetActive(false);
        EnemyUnitText.SetActive(false);
        BattleEndPanel.SetActive(false);
        DeletePlayerUnits.SetActive(true);
        AbilityPanel.SetActive(false);
        BloodText.gameObject.SetActive(false);
        RestartLevelButton.SetActive(false);
        NextLevelButton.SetActive(false);

        Time.timeScale = 0;
    }

    public void StartBattleStage()
    {
        StartBattleButton.SetActive(false);
        GridContainer.SetActive(false);
        WarGroupsPanel.SetActive(false);
        PlayerUnitText.SetActive(true);
        EnemyUnitText.SetActive(true);
        DeletePlayerUnits.SetActive(false);
        AbilityPanel.SetActive(true);
        BloodText.gameObject.SetActive(true);

        UIEventManager.onEnemyUnitsDead.AddListener(PlayerWinEvent);
        UIEventManager.onPlayerUnitsDead.AddListener(PlayerLoseEvent);

        GameEventManager.BattleStartEvent();

        Time.timeScale = 1;
    }

    private void PlayerWinEvent()
    {
        BattleEndPanel.SetActive(true);
        NextLevelButton.SetActive(true);
        BattleEndText.text = "You Win";
        BloodRewardText.text = "888";
        CoinRewardText.text = "888";
        Time.timeScale = 0;
    }

    private void PlayerLoseEvent()
    {
        BattleEndPanel.SetActive(true);
        RestartLevelButton.SetActive(true);
        BattleEndText.text = "You lose";
        BloodRewardText.text = "0((";
        CoinRewardText.text = "0((";
        Time.timeScale = 0;
    }
}
