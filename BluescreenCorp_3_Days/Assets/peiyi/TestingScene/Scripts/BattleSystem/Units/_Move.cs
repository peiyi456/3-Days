using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Move
{
    public _MoveBase Base { get; set; }
    public float Efficiency { get; set; }

    public _Move(_MoveBase pBase)
    {
        Base = pBase;
        Efficiency = pBase.Efficiency;
    }
}
