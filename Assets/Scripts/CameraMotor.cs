using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    [SerializeField] private Transform lookAt;
    [SerializeField] private float boundX;
    [SerializeField] private float boundY;
    
    private Vector3 delta;
    private float deltaX;
    private float deltaY;


    void LateUpdate()
    {
        delta = Vector3.zero;
        
        deltaX = lookAt.position.x - transform.position.x;
        deltaY = lookAt.position.y - transform.position.y;

        delta = AdjustDeltaAccordingToBounds();

        transform.position += new Vector3(delta.x, delta.y, 0);
    }

    private Vector3 AdjustDeltaAccordingToBounds()
    {
        if (IsDeltaOutOfBoundsOnXAxis())
        {
            MoveCameraBoundsOnXAxis();
        }

        if (IsDeltaOutOfBoundsOnYAxis())
        {
            MoveCameraBoundsOnYAxis();
        }

        return delta;

        bool IsDeltaOutOfBoundsOnXAxis()
        {
            return deltaX > boundX || deltaX < -boundX;
        }

        bool IsDeltaOutOfBoundsOnYAxis()
        {
            return deltaY > boundY || deltaY < -boundY;
        }
    }
    
    private void MoveCameraBoundsOnXAxis()
    {
        if (transform.position.x < lookAt.position.x)
        {
            delta.x = deltaX - boundX;
        }
        else
        {
            delta.x = deltaX + boundX;
        }
    }

    private void MoveCameraBoundsOnYAxis()
    {
        if (transform.position.y < lookAt.position.y)
        {
            delta.y = deltaY - boundY;
        }
        else
        {
            delta.y = deltaY + boundY;
        }
    }
}
