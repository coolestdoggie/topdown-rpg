using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public int xpValue = 1;

    public float triggerLength = 1f;
    public float chaseLength = 5f;
    [SerializeField] private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        playerTransform = GameManager.Instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        var distanceBtwPlayerNEnemy = Vector3.Distance(playerTransform.position, startingPosition);
        
        if (distanceBtwPlayerNEnemy < chaseLength)
        {
            if (distanceBtwPlayerNEnemy < triggerLength)
            chasing = true;

            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null) continue;

            if (hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }
            
            hits[i] = null;
        }
    }

    protected override void Death()
    {
        base.Death();
        Destroy(gameObject);
        GameManager.Instance.experienceAmount += xpValue;
        GameManager.Instance.ShowText("+" + xpValue + " xp", 30, 
            Color.magenta, transform.position, Vector3.up * 40, 1f);
    }
}
