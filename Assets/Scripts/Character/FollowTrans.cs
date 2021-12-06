using UnityEngine;

public class FollowTrans : MonoBehaviour
{
    public Transform trans;
    public bool dontDestroy = false;

    private void Start()
    {
        if (dontDestroy)
            DontDestroyOnLoad(gameObject);
    }

    //(Gab) Vraiment weird comme script mais a une utilitée!
    //Bug dans Rig system de Unity. Faire cela contourne le problème.
    void LateUpdate()
    {
        transform.position = trans.position;
    }
}
