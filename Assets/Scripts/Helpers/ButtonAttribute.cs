using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonMode
{
    ActiveAlways,
    ActiveOnPlayMode,
    ActiveOnEditMode,
}

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class ButtonAttribute : Attribute
{
    private readonly string name = null;
    private readonly ButtonMode buttonMode = ButtonMode.ActiveAlways;

    public string GetName() => name;
    public ButtonMode GetButtonMode() => buttonMode;

    public ButtonAttribute(string name, ButtonMode buttonMode)
    {
        this.name = name;
        this.buttonMode = buttonMode;
    }
}
