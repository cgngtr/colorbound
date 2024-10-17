using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedState : ColorState.IColorState
{
    [NonSerialized] private Color red = new Color(0.5f, 0, 0, 1);
    [NonSerialized] private Color black = new Color(0.2f, 0.2f, 0.2f, 1);

    public void EnterState(PlayerStats player, SpriteRenderer sr)
    {
        sr.color = red;
        player.SetMovementSpeed(500f);
        Debug.Log("Red State: Speed increased.");
    }

    public void ExitState(PlayerStats player, SpriteRenderer sr)
    {
        sr.color = black;
        player.ResetMovementSpeed();
        Debug.Log("Red State: Speed reset.");
    }

    public void UpdateState(PlayerStats player)
    {
    }
}

