using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private RaycastHit2D hit;
    
    private Vector3 moveDelta;
    private float moveDeltaX;
    private float moveDeltaY;


    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        GetInput();

        Flip();

        if(HasCollisionOnXAxis()) transform.Translate(moveDelta.x * Time.deltaTime, 0f, 0f);
        if(!HasCollisionOnYAxis()) transform.Translate(0f, moveDelta.y * Time.deltaTime, 0f);
    }

    private void GetInput()
    {
        moveDeltaX = Input.GetAxisRaw("Horizontal");
        moveDeltaY = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(moveDeltaX, moveDeltaY, 0);
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
