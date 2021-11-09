using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTrans : MonoBehaviour
{
    public Transform trans;

    //(Gab) Vraiment weird comme script mais a une utilitée!
    //Bug dans Rig system de Unity. Faire cela contourne le problème.
    void LateUpdate()
    {
        transform.position = trans.position;
    }
}
