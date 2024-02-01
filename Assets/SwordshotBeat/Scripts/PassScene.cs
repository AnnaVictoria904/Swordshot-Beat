using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassScene : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputField.text.Length == 3)
        {
            cube.SetActive(true);
        }

        else
        {
            cube.SetActive(false);
        }

        if (cube.GetComponent<SliceObject>().hasSliced)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
