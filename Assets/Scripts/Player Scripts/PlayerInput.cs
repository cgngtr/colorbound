using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public ColorState _colorState;

    private void Awake()
    {
        _colorState = GetComponent<ColorState>();
    }

    public void ChangeColorState()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _colorState.ChangeState(ColorState.Red);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _colorState.ChangeState(ColorState.Green);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _colorState.ChangeState(ColorState.Blue);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _colorState.ChangeState(ColorState.Yellow);
        }
    }
}
