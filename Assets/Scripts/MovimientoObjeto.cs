using UnityEngine;

public class MovimientoObjeto : MonoBehaviour
{
    public float velocidad = 2f;

    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        if (transform.position.z > 50f)
        {
            Destroy(gameObject);
        }
    }
}
