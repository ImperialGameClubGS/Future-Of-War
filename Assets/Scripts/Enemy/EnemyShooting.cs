using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : EnemyBase
{

    void Start()
    {
        Health = 60;
        Damage = 20;
        RunSpeed = 5f;
    }

}
