using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    [SerializeField] private ContactFilter2D filter;

    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    
    protected virtual void Start()
    {
        boxCollider = new BoxCollider2D();
    }

    protected virtual void Update()
    {
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null) continue;

            hits[i] = null;
        }

    }
}
