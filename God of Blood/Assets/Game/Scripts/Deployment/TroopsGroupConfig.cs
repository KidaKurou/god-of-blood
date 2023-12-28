using UnityEngine;

namespace GodofBlood.Deployment
{
	[CreateAssetMenu(menuName = "Configs/TroopsGroupConfig", fileName = "TroopsGroupConfig")]
	public class TroopsGroupConfig : ScriptableObject
	{
        [Header("UnitsInfo")]
        public string Title;
        public int Quantity;

        [field: SerializeField] public KeyCode HotKey { get; private set; }
    }
}