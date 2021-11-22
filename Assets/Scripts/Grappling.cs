using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public Third_person_mvmnt movement;
    public LayerMask whatIsGrappleable;
    public LayerMask whatStopsGrappleable;
    public Transform grappleTip, cam, player;
    private float maxDistance = 100f;
    private bool IsGrappling;
    public float grappleSpeed;
    private float Speed;
    private Vector3 lastPosition;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        IsGrappling = false;
        Speed = grappleSpeed;
        lastPosition = player.position;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            StopGrapple();
        }

        if(IsGrappling)
        {
            float dist = .5f + (Vector3.Distance(player.transform.position, grapplePoint) / maxDistance);
            //Debug.Log(dist);
            Speed = Mathf.Clamp(Speed * dist, grappleSpeed, grappleSpeed * 1.5f);
            lastPosition = player.transform.position;
            player.transform.position = Vector3.MoveTowards(player.transform.position, grapplePoint, Speed * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        DrawRope();
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
        if (Vector3.Distance(grappleTip.position, grapplePoint) < 8.0f)
        {
            StopGrapple();
        }
    }

    void StopGrapple()
    {
        if (!IsGrappling) return;

        movement.yvelocity = 0f;
        var velocity = (player.transform.position - lastPosition) / (Time.deltaTime * 1000f);
        Debug.Log(velocity);
        movement.Velocity = velocity;
        lr.positionCount = 0;
        IsGrappling = false;
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
