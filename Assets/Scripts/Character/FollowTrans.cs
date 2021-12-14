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

    void LateUpdate()
    {
        transform.position = trans.position;
    }
}
