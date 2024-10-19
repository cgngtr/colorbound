using System;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public event Action OnStealthEnabled;
    public event Action OnStealthDisabled;

    public event Action OnElectricPowerEnabled;
    public event Action OnElectricPowerDisabled;

    public event Action OnUnderwaterBreathingEnabled;
    public event Action OnUnderwaterBreathingDisabled;

    public event Action OnCastVineSkill;

    public void EnableStealth()
    {
        OnStealthEnabled?.Invoke();
        Debug.Log("Stealth enabled.");
    }

    public void DisableStealth()
    {
        OnStealthDisabled?.Invoke();
        Debug.Log("Stealth disabled.");
    }

    public void EnableElectricPower()
    {
        OnElectricPowerEnabled?.Invoke();
        Debug.Log("Electric power enabled.");
    }

    public void DisableElectricPower()
    {
        OnElectricPowerDisabled?.Invoke();
        Debug.Log("Electric power disabled.");
    }

    public void EnableUnderwaterBreathing()
    {
        OnUnderwaterBreathingEnabled?.Invoke();
        Debug.Log("Underwater breathing enabled.");
    }

    public void DisableUnderwaterBreathing()
    {
        OnUnderwaterBreathingDisabled?.Invoke();
        Debug.Log("Underwater breathing disabled.");
    }

    public void CastVineAttack()
    {
        OnCastVineSkill?.Invoke();
        Debug.Log("Vine attack casted.");
    }
}
