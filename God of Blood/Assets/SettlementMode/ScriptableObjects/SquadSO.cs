using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/SquadSO", fileName = "SquadSO")]
public class SquadSO : ScriptableObject
{
    [Header("Unit Info")]
    public string Title;

    public int Quantity;

    
}
