using UnityEngine;

public class Fragmentador : MonoBehaviour
{
    public GameObject fragmentoPrefab;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TestIsma"))
        {
            // Fragmentar el cubo original
            FragmentarCubo();
            // Hacer que el cubo original desaparezca
            Destroy(other.gameObject);
        }
    }

    void FragmentarCubo()
    {
        // Instanciar los fragmentos en la posición del cubo original
        Instantiate(fragmentoPrefab, transform.position, Quaternion.identity);
    }
}
