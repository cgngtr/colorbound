using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowState : ColorState.IColorState
{
    [NonSerialized] public Color yellow = new Color(0.9f, 0.85f, 0, 1);
    [NonSerialized] private Color black = new Color(0.2f, 0.2f, 0.2f, 1);

    public void EnterState(PlayerStats player, SpriteRenderer sr)
    {

    }

    public void ExitState(PlayerStats player, SpriteRenderer sr)
    {

    }

    public void UpdateState(PlayerStats player)
    {

    }
}
