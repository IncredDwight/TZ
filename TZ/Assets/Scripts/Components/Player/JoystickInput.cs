using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour, IInput
{
    [SerializeField] private FixedJoystick _joystick;

    public float GetHorizontal()
    {
        return _joystick.Horizontal;
    }

    public float GetVertical()
    {
        return _joystick.Vertical;
    }
}
