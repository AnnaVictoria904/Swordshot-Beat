using UnityEngine;
using System.Collections;

public class Espada : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TestIsma"))
        {
            // Obtener la referencia al script SliceObject
            SliceObject sliceObjectScript = other.GetComponent<SliceObject>();

            // Verificar si el script SliceObject está presente
            if (sliceObjectScript != null)
            {
                // Llamar a la función Slice del script SliceObject
                sliceObjectScript.Slice(other.gameObject);
            }

            // Iniciar una corrutina para destruir el objeto después de 3 segundos
            StartCoroutine(DestruirDespuesDeEspera(other.gameObject, 3f));
        }
    }

    IEnumerator DestruirDespuesDeEspera(GameObject objetoADestruir, float tiempoEspera)
    {
        // Esperar durante el tiempo especificado
        yield return new WaitForSeconds(tiempoEspera);

        // Destruir el objeto
        //Destroy(objetoADestruir);
    }
}
