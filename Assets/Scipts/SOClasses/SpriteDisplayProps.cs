using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpriteDisplayProps
{
    [SerializeField] float size = 1f;
    [SerializeField] float angle = 0f;

    public float Size { get => size; }
    public float Angle { get => angle; }
}
