using UnityEngine;

    public interface IColorState
    {
        void EnterState(PlayerStats player, SpriteRenderer sr, SkillManager skill);
        void ExitState(PlayerStats player, SpriteRenderer sr, SkillManager skill);
        void UpdateState(PlayerStats player, SkillManager skill);
    }

