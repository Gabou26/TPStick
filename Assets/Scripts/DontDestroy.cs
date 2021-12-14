using UnityEngine;

// Les objets possédant ce script ne seront pas détruit lors du changement de scène (Les Player prefab)
public class DontDestroy : MonoBehaviour
{

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
}
