using UnityEngine;
using System.Collections;

public class GeneradorNivel : MonoBehaviour
{
    public GameObject prefabObjetos;
    public float velocidadObjetos = 5f;
    public float rangoSpawnX = 3f;
    public float rangoSpawnYMin = 0f;
    public float rangoSpawnYMax = 2f;
    public float rangoSpawnZ = 20f;
    public float rangoFinalZ = 60f;
    public float tiempoEspera = 1f; 

    void Start()
    {
        StartCoroutine(GenerarEnBucle());
    }

    IEnumerator GenerarEnBucle()
    {
        while (true)
        {
            GenerarObjeto();
            yield return new WaitForSeconds(tiempoEspera);
        }
    }

    void GenerarObjeto()
    {
        Vector3 posicion = new Vector3(Random.Range(-rangoSpawnX, rangoSpawnX), Random.Range(rangoSpawnYMin, rangoSpawnYMax), rangoSpawnZ);
        GameObject nuevoObjeto = Instantiate(prefabObjetos, posicion, Quaternion.identity);

        nuevoObjeto.tag = "TestIsma";
        nuevoObjeto.AddComponent<MovimientoObjeto>().velocidad = velocidadObjetos;

        StartCoroutine(MoverObjeto(nuevoObjeto.transform));
    }

    IEnumerator MoverObjeto(Transform objetoTransform)
    {
        while (objetoTransform != null && objetoTransform.position.z < rangoFinalZ)
        {
            objetoTransform.Translate(Vector3.forward * velocidadObjetos * Time.deltaTime);
            yield return null;
        }

        if (objetoTransform != null)
        {
            Destroy(objetoTransform.gameObject);
        }
    }

}
