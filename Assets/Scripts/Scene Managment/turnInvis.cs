using UnityEngine;

/*
Ce script permet de rendre n'importe quel objet auquel il est appliqué invisible.
*/
public class turnInvis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
