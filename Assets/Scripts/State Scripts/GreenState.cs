using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenState : ColorState.IColorState
{
    [NonSerialized] public Color green = new Color(0, 0.5f, 0.25f, 1);
    [NonSerialized] private Color black = new Color(0.2f, 0.2f, 0.2f, 1);

    public void EnterState(PlayerStats player, SpriteRenderer sr)
    {
        sr.color = green;
    }

    public void ExitState(PlayerStats player, SpriteRenderer sr)
    {
        sr.color = black;
    }

    public void UpdateState(PlayerStats player)
    {
        
    }
}

