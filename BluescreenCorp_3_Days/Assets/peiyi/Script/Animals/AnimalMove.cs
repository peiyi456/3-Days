using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMove : MonoBehaviour
{
    public AnimalMoveBase Base { get; set; }
    public int PP { get; set; }

    public AnimalMove(AnimalMoveBase pBase, int pp)
    {
        Base = pBase;
        PP = pp;
    }
}
