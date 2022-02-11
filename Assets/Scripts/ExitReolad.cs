using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitReolad : MonoBehaviour
{
    public void Reload()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name); ; }
}