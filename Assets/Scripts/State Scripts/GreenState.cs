using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenState : ColorState.IColorState
{
    private Color green = new Color(0, 0.5f, 0, 1);
    private Color black = new Color(0.2f, 0.2f, 0.2f, 1);
    private SkillManager skillManager;

    public void EnterState(PlayerStats player, SpriteRenderer sr)
    {
        sr.color = green;
        //skill.EnableStealth();
        Debug.Log("Green State: Stealth enabled.");
    }

    public void ExitState(PlayerStats player, SpriteRenderer sr)
    {
        sr.color = black;
        //skill.DisableStealth();
        Debug.Log("Green State: Stealth disabled.");
    }

    public void UpdateState(PlayerStats player)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //skill.CastVineAttack();
        }
    }
}