using UnityEngine;

/*
Ce script permet de rendre n'importe quel objet auquel il est appliqué invisible.
*/
public class turnInvis : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
