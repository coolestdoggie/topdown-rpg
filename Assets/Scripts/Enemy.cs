using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public int xpValue = 1;

    public float triggerLength = 1f;
    public float chaseLength = 5f;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];
}
