
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnLaunch : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
