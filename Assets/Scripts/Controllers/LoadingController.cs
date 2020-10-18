using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(1);
    }
}
