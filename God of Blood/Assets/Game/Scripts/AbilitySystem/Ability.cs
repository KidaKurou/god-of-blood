using Assets.Scripts.AbilitySystem;
using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class Ability 
{
    public event Action<float, float> EventChangeCooldownTimer;

    public string Title { get; private set; }
    public string Description { get; private set; }
    public Sprite DisplayImage { get; private set; }

    public float CooldownTime { get; private set; }
    public float CooldownTimer { get; private set; }

    public float ManaCost { get; private set; }
    public float AreaRadius { get; private set; }
    public ParticleSystem AreaParticle { get; private set; }

    public KeyCode Hotkey { get; private set; }
    public EAbilityStatus Status { get; private set; }

    public void SetDescription(string title, string description, Sprite displayImage)
    {
        Title = title;
        Description = description;
        DisplayImage = displayImage;
    }

    public void SetKey(KeyCode key) => Hotkey = key;
    public void SetCooldownTime(float cooldown) => CooldownTime = cooldown;
    public void SetManaCost(float manaCost) => ManaCost = manaCost;
    public void SetStatus(EAbilityStatus status) => Status = status;
    public void SetAreaRadius(float areaRadius) => AreaRadius = areaRadius;
    public void SetAreaParticle(ParticleSystem areaParticle) => AreaParticle = areaParticle;

    public void ChangeCooldownTimer(float timer)
    {
        CooldownTimer = Mathf.Clamp(timer, 0.0f, CooldownTime);
        EventChangeCooldownTimer?.Invoke(CooldownTimer, CooldownTime);
    }

    //public virtual void StartCast(ParticleSystem particle)
    //{
    //    GameEventManager.IntatiateParticleIvent(particle);
    //}

    public virtual void StartCast()
    {
    }

    public virtual bool CheckCondition(AbstractUnit owner, List<AbstractUnit> target)
    {
        return false;
    }

    public virtual void ApplyCast()
    {
        //Destroy(AreaParticle);
    }

    public virtual void EventTick(float deltaTick)
    {

    }

    public virtual void CancelCast()
    {
        //Destroy(AreaParticle);
    }
}
