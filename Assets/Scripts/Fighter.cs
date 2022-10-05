using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitpoint = 10;
    public int maxHitPoint = 10;
    public float pushRecoverySpeed = 0.2f;

    protected float immuneTime = 1f;
    protected float lastImmune;

    protected Vector3 pushDirection;

}
