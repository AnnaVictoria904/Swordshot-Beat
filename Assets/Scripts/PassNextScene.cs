using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CubeScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Auto Hand Player Container")
        {
            Destroy(gameObject); 
            StartCoroutine(WaitAndLoadScene()); 
        }
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(2); 
        SceneManager.LoadScene("LevelGame"); 
    }
}
