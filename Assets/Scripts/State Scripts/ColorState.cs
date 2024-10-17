using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorState : MonoBehaviour
{
    // Making this static so that it's the same object for all instances of the class.
    // Making this readonly so that it can't be changed.
    public static readonly IColorState Red = new RedState();
    public static readonly IColorState Green = new GreenState();
    public static readonly IColorState Blue = new BlueState();
    public static readonly IColorState Yellow = new YellowState();

    private IColorState currentState;
    private PlayerStats _playerStats;
    private SpriteRenderer sr;

    #region COLORS
    [NonSerialized] public Color red = new Color(0.5f, 0, 0, 1);
    [NonSerialized] public Color green = new Color(0, 0.5f, 0.25f, 1);
    [NonSerialized] public Color blue = new Color(0, 0.25f, 0.5f, 1);
    [NonSerialized] public Color yellow = new Color(0.9f, 0.85f, 0, 1);
    #endregion

    public interface IColorState
    {
        void EnterState(PlayerStats player, SpriteRenderer sr);
        void ExitState(PlayerStats player, SpriteRenderer sr);
        void UpdateState(PlayerStats player);
    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        _playerStats = GetComponent<PlayerStats>();
    }


    public void ChangeState(IColorState newState)
    {
        if (currentState == newState)
        {
            currentState.ExitState(_playerStats, sr);
            currentState = null;
            Debug.Log("Color state toggled off.");
            return;
        }

        if (currentState != null)
        {
            currentState.ExitState(_playerStats, sr);
        }

        currentState = newState;
        currentState.EnterState(_playerStats, sr);
    }


    public IColorState GetCurrentState()
    {
        return currentState;
    }
}

