using UnityEngine;
using System.Collections;

public class GeneradorNivel : MonoBehaviour
{
    public GameObject prefabCubo;
    public GameObject prefabDiana;
    public float velocidadObjetos = 5f;
    public float rangoSpawnX = 3f;
    public float rangoSpawnYMin = 0f;
    public float rangoSpawnYMax = 2f;
    public float rangoSpawnZ = 20f;
    public float rangoFinalZ = 60f;
    public AudioSource audioSource;
    public float umbralAmplitudCubo = 0.006f; 
    public float umbralAmplitudDiana = 0.007f; 
    public float intervaloGeneracion = 1f; 

    private float tiempoUltimaGeneracion;

    void Start()
    {
        if (audioSource == null || audioSource.clip == null)
        {
            Debug.LogError("¡AudioSource o clip no configurados en el GeneradorNivel!");
            return;
        }

        audioSource.Play();
        tiempoUltimaGeneracion = Time.time;
    }

    void Update()
    {
        if (Time.time - tiempoUltimaGeneracion > intervaloGeneracion)
        {
            GenerarObjetosSegunAudio();
            tiempoUltimaGeneracion = Time.time;
        }
    }

    void GenerarObjetosSegunAudio()
    {
        float[] spectrumData = new float[512]; // Tamaño de la muestra de espectro de audio

        // Obtener el espectro de audio
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        // Calcula la amplitud total de las frecuencias
        float totalAmplitud = 0f;
        foreach (float amplitude in spectrumData)
        {
            totalAmplitud += amplitude;
        }

        // Normaliza la amplitud total para estar en el rango de 0 a 1
        float normalizedAmplitud = totalAmplitud / spectrumData.Length;

        Debug.Log("Amplitud total detectada: " + normalizedAmplitud); // Debug para imprimir la amplitud detectada

        // Si la amplitud total supera el umbral, genera objetos en ambos lados
        if (normalizedAmplitud > umbralAmplitudCubo)
        {
            Debug.Log("Generando cubos");

            GenerarObjeto(prefabCubo, -rangoSpawnX, rangoSpawnYMin);
            GenerarObjeto(prefabCubo, rangoSpawnX, rangoSpawnYMin);
        }
        else if (normalizedAmplitud > umbralAmplitudDiana)
        {
            Debug.Log("Generando dianas");

            GenerarObjeto(prefabDiana, -rangoSpawnX, rangoSpawnYMax);
            GenerarObjeto(prefabDiana, rangoSpawnX, rangoSpawnYMax);
        }
        else
        {
            Debug.Log("No se detectó amplitud suficiente");
        }
    }

    void GenerarObjeto(GameObject prefab, float posX, float posY)
    {
        Vector3 posicion = new Vector3(posX, Random.Range(rangoSpawnYMin, rangoSpawnYMax), rangoSpawnZ);
        GameObject nuevoObjeto = Instantiate(prefab, posicion, Quaternion.identity);
        nuevoObjeto.tag = "TestIsma";
        nuevoObjeto.AddComponent<MovimientoObjeto>().velocidad = velocidadObjetos;
        Debug.Log("Prefab generado en posición: " + posicion);
    }
}
