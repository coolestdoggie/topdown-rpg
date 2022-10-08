using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected RaycastHit2D hit;

    protected Vector3 moveDelta;
    protected float moveDeltaX;
    protected float moveDeltaY;
    protected float xSpeed = 1f;
    protected float ySpeed = 0.75f;


    protected virtual void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    protected void GetInput()
    {
        moveDeltaX = Input.GetAxisRaw("Horizontal");
        moveDeltaY = Input.GetAxisRaw("Vertical");
    }

    protected void UpdateMotor(Vector3 input)
    {
        moveDelta = new Vector3(moveDeltaX * xSpeed, moveDeltaY * ySpeed, 0);
        
        Flip();

        if (!HasCollisionOnXAxis()) transform.Translate(moveDelta.x * Time.deltaTime, 0f, 0f);
        if (!HasCollisionOnYAxis()) transform.Translate(0f, moveDelta.y * Time.deltaTime, 0f);
    }
    
    private void Flip()
    {
        if (moveDelta.x > 0) transform.localScale = Vector3.one;
        else if (moveDelta.x < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    private bool HasCollisionOnXAxis()
    {
        hit = Physics2D.BoxCast(transform.position, boxCollider.size,
            0,
            new Vector2(moveDelta.x, 0),
            Mathf.Abs(moveDelta.x * Time.deltaTime),
            LayerMask.GetMask("Actor", "Blocking"));

        return hit.collider != null;
    }

    private bool HasCollisionOnYAxis()
    {
        hit = Physics2D.BoxCast(transform.position, boxCollider.size,
            0,
            new Vector2(0, moveDelta.y),
            Mathf.Abs(moveDelta.y * Time.deltaTime),
            LayerMask.GetMask("Actor", "Blocking"));

        return hit.collider != null;
    }
}
