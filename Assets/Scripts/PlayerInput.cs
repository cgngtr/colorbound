using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public ColorState _colorState;
    public void ChangeColorState()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {    
            _colorState.ColorType selectedColor = _colorState.ColorType.Red;
        }
    }
}
