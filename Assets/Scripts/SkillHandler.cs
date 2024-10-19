using UnityEngine;

public class SkillHandler : MonoBehaviour
{
    [SerializeField] private SkillManager skillManager;

    private void OnEnable()
    {
        skillManager.OnStealthEnabled += () => LogSkillStatus("Stealth mode activated.");
        skillManager.OnStealthDisabled += () => LogSkillStatus("Stealth mode deactivated.");
        skillManager.OnElectricPowerEnabled += () => LogSkillStatus("Electric power activated.");
        skillManager.OnElectricPowerDisabled += () => LogSkillStatus("Electric power deactivated.");
        skillManager.OnUnderwaterBreathingEnabled += () => LogSkillStatus("Underwater breathing activated.");
        skillManager.OnUnderwaterBreathingDisabled += () => LogSkillStatus("Underwater breathing deactivated.");
        skillManager.OnCastVineSkill += () => LogSkillStatus("Vine attack casted.");
    }

    private void OnDisable()
    {
        skillManager.OnStealthEnabled -= () => LogSkillStatus("Stealth mode activated.");
        skillManager.OnStealthDisabled -= () => LogSkillStatus("Stealth mode deactivated.");
        skillManager.OnElectricPowerEnabled -= () => LogSkillStatus("Electric power activated.");
        skillManager.OnElectricPowerDisabled -= () => LogSkillStatus("Electric power deactivated.");
        skillManager.OnUnderwaterBreathingEnabled -= () => LogSkillStatus("Underwater breathing activated.");
        skillManager.OnUnderwaterBreathingDisabled -= () => LogSkillStatus("Underwater breathing deactivated.");
        skillManager.OnCastVineSkill -= () => LogSkillStatus("Vine attack casted.");
    }

    private void LogSkillStatus(string message)
    {
        Debug.Log(message);
    }
}
