using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEditor.Animations;

public class ActiveWeapon : MonoBehaviour
{
    public Transform crossHairTarg;
    public Transform weaponParent;
    public Rig hankIk;
    RayWeapon rayWeapon;
    private bool pressed;
    private bool released;

    //Editeur
    public Transform gripLeft, gripRight;
    Animator animator;
    AnimatorOverrideController overrides;

    // Start is called before the first frame update
    void Start()
    {
        RayWeapon baseWeapon = GetComponentInChildren<RayWeapon>();
        if (baseWeapon)
            Equip(baseWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        if (!rayWeapon)
        {
            hankIk.weight = 0;
            return;
        }

        if (pressed)
            rayWeapon.StartFiring();
        else
            rayWeapon.StopFiring();
    }

    public void OnFirePress() {
        pressed = true;
    }

    public void OnFireRelease() {
        pressed = false;
    }

    public void Equip(RayWeapon weapon)
    {
        if (rayWeapon)
            Destroy(rayWeapon.gameObject);

        rayWeapon = weapon;
        rayWeapon.raycastAimTarget = crossHairTarg;
        rayWeapon.transform.parent = weaponParent;
        rayWeapon.transform.localPosition = Vector3.zero;
        rayWeapon.transform.localRotation = Quaternion.identity;

        hankIk.weight = 1;
    }

    [ContextMenu("Save Weapon Pose")]
    void SaveWeaponPose() {
        GameObjectRecorder recorder = new GameObjectRecorder(gameObject);
        recorder.BindComponentsOfType<Transform>(weaponParent.gameObject, false);
        recorder.BindComponentsOfType<Transform>(gripLeft.gameObject, false);
        recorder.BindComponentsOfType<Transform>(gripRight.gameObject, false);
        recorder.TakeSnapshot(0);
        recorder.SaveToClip(rayWeapon.weaponAnim);
        UnityEditor.AssetDatabase.SaveAssets();
    }
}
