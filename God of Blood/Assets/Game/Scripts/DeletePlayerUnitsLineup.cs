using UnityEngine;

public class DeletePlayerUnitsLineup : MonoBehaviour
{
    [SerializeField] private GameObject _PlayerUnitContainer;

    public void DeleteUnits()
    {
        foreach (Transform child in _PlayerUnitContainer.transform)
        {
            Destroy(child.gameObject);
        }
        GameEventManager.Refresh();
    }
}
