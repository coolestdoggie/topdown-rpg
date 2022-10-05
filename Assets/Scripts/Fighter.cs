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

    protected virtual void ReceiveDamage(Damage damage)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= damage.damageAmount;
            pushDirection = (transform.position - damage.origin).normalized * damage.pushForce;

            GameManager.Instance.ShowText(damage.damageAmount.ToString(), 
                30, Color.red, transform.position, Vector3.zero, 0.5f);
            
            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {
        
    }
}
