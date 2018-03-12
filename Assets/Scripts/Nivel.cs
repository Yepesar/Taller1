using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Nivel : MonoBehaviour {

    [SerializeField]
    private string nivel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (nivel != "Salir")
        {
            SceneManager.LoadScene(nivel);
        }
        
        if(nivel == "Salir")
        {
            Application.Quit();
            Debug.Log("Salir");
        }
    }
}
