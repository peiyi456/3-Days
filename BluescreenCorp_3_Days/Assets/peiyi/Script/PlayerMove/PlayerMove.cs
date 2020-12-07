using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove
{
    public PlayerMoveBase Base { get; set; }
    public int PP { get; set; }

    public PlayerMove(PlayerMoveBase pBase)
    {
        Base = pBase;
        PP = pBase.PP; ;
    }

}
