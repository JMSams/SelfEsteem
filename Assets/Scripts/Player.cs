using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : FallingSloth.SingletonBehaviour<Player>
{
    new public static Rigidbody2D rigidbody { get; protected set; }

    protected override void Awake()
    {
        base.Awake();

        rigidbody = GetComponent<Rigidbody2D>();
    }
}