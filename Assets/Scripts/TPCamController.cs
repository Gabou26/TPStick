using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPCamController : MonoBehaviour
{
    public float RotationSpeedX = 1;
    public float RotationSpeedY = 1;
    public Transform Target, Player, RagdollTarget;
    public Transform CamFocus;
    float mousex, mousey;
    float horizontal = 0f;
    float vertical = 0f;
    public bool deadChar;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        deadChar = false;
        CamFocus = Target;
    }

    private void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        mousex += horizontal * RotationSpeedX;
        mousey += vertical * RotationSpeedY;
        mousey = Mathf.Clamp(mousey, -60, 60);

        transform.LookAt(CamFocus);
        CamFocus.rotation = Quaternion.Euler(mousey, mousex, 0);
        if(!deadChar) Player.rotation = Quaternion.Euler(0, mousex, 0);
    }
    
    public void OnCameraH(InputValue value) {
        horizontal = value.Get<float>();
    }

    public void OnCameraV(InputValue value) {
        vertical = value.Get<float>();
    }

    public void OnCameraVKey(InputValue value) {
        vertical = -value.Get<float>();
    }

}
