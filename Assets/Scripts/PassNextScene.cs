using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CubeScript : MonoBehaviour
{
    [SerializeField] private GameObject cube;
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
        /*yield return new WaitForSeconds(2); 
        SceneManager.LoadScene("LevelGame");*/
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("LevelGame");
    }
    private void Update()
    {
        if (cube.GetComponent<SliceObject>().hasSliced)
        {
            StartCoroutine(WaitAndLoadScene());
        }
    }
}
