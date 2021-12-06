using UnityEngine;

public class Grappling : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public Third_person_mvmnt movement;
    public LayerMask whatIsGrappleable;
    public LayerMask whatStopsGrappleable;
    public Transform grappleTip, cam, player;
    private float maxDistance = 60f;
    private bool IsGrappling;
    public float grappleSpeed;
    private float Speed;
    private Vector3 lastPosition;
    private bool pressed = false;
    private bool released = false;
    private Vector3 VelocityZero;
    private bool springmax;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        IsGrappling = true;
        StopGrapple();
        Speed = grappleSpeed;
        lastPosition = player.position;
        VelocityZero = new Vector3(0, 0, 0);
        springmax = false;
    }

    private void Update()
    {
        if(pressed)
        {
            StartGrapple();
            pressed = false;
        }
        if (released)
        {
            StopGrapple();
            released = false;
        }

        if(IsGrappling)
        {
            if(Vector3.Distance(grappleTip.position, grapplePoint) > 6.0f)
            {
                float dist = .5f + (Vector3.Distance(player.transform.position, grapplePoint) / maxDistance);
                //Debug.Log(dist);
                Speed = Mathf.Clamp(Speed * dist, grappleSpeed, grappleSpeed * 1.5f);
                lastPosition = player.transform.position;
                player.transform.position = Vector3.MoveTowards(player.transform.position, grapplePoint, Speed * Time.deltaTime);
            }
            else
            {
                movement.Velocity = VelocityZero;
                springmax = true;
            }
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    public void OnGrapplePress() {
        pressed = true;
    }

    public void OnGrappleRelease() {
        released = true;
    }

    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, whatIsGrappleable))
        {
            if (hit.transform.tag == "Detach")
            {
                return;
            }

            springmax = false;
            movement.Velocity = new Vector3(0, 0, 0);
            grapplePoint = hit.point;


            lr.positionCount = 2;
            IsGrappling = true;
        }
    }

    void DrawRope()
    {
        if (!IsGrappling) return;

        lr.SetPosition(0, grappleTip.position);
        lr.SetPosition(1, grapplePoint);
        if (Vector3.Distance(grappleTip.position, grapplePoint) < 5.0f)
        {
            StopGrapple();
        }
    }

    void StopGrapple()
    {
        if (!IsGrappling) return;

        movement.yvelocity = 0f;
        var velocity = (player.transform.position - lastPosition) * (Time.deltaTime * 20f);
        if(!springmax) movement.Velocity = velocity;
        lr.positionCount = 0;
        IsGrappling = false;
        springmax = false;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }

    public bool GetIsGrappling()
    {
        return IsGrappling;
    }
}
