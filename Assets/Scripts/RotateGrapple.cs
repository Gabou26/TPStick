using UnityEngine;

public class RotateGrapple : MonoBehaviour
{
    public Grappling theGrapple;

    private Quaternion desiredRotation;
    private float rotationSpeed = 4f;

    void Update()
    {
        if(theGrapple.GetIsGrappling())
        {
            desiredRotation = Quaternion.LookRotation(theGrapple.GetGrapplePoint() - transform.position);
        }
        else
        {
            desiredRotation = transform.parent.rotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }
}
