using System;
using UnityEngine;

public class BlueState : ColorState.IColorState
{
    [NonSerialized] private Color blue = new Color(0, 0, 0.5f, 1);
    [NonSerialized] private Color black = new Color(0.2f, 0.2f, 0.2f, 1);

    public void EnterState(PlayerStats player, SpriteRenderer sr)
    {
        sr.color = blue;
        player.SetJumpForce(350f);
        Debug.Log("Blue State: Jump height increased.");
    }

    public void ExitState(PlayerStats player, SpriteRenderer sr)
    {
        sr.color = black;
        player.ResetJumpForce();
        Debug.Log("Blue State: Jump height reset.");
    }

    public void UpdateState(PlayerStats player)
    {
    }
}
