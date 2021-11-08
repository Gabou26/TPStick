using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCamController : MonoBehaviour
{
    public float RotationSpeedX = 1;
    public float RotationSpeedY = 1;
    public Transform Target, Player;
    public RayWeapon rayWeapon;
    float mousex, mousey;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        CamControl();
        if (Input.GetButtonDown("Fire1"))
            rayWeapon.StartFiring();
        else if (Input.GetButtonUp("Fire1"))
            rayWeapon.StopFiring();
    }

    void CamControl()
    {
        mousex += Input.GetAxis("Mouse X") * RotationSpeedX;
        mousey -= Input.GetAxis("Mouse Y") * RotationSpeedY;
        mousey = Mathf.Clamp(mousey, -60, 60);

        Vector3 rotTarget = Target.rotation.eulerAngles;
        transform.LookAt(Target);
        Target.rotation = Quaternion.Euler(mousey, rotTarget.y, 0);
        Player.rotation = Quaternion.Euler(0, mousex, 0);
    }
}
