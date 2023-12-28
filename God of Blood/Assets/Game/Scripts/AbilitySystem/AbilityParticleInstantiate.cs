using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.AbilitySystem
{
    public class AbilityParticleInstantiate : MonoBehaviour
    {

        private void Awake()
        {
            GameEventManager.onAbilityStartCast.AddListener(InstantiateAura);
        }

        private void InstantiateAura(ParticleSystem particle)
        {
            Debug.Log("inst");
            ParticleSystem ps = Instantiate(particle);
            ps.Play();
        }
    }
}