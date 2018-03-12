using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Puntos : MonoBehaviour {

    [SerializeField]
    private Text puntos;

    private int puntaje = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        other.gameObject.SetActive(false);

        if (gameObject.tag == "1")
        {
            puntaje += 1;
            puntos.text = "Puntos: " + puntaje;
        }

        if (gameObject.tag == "3")
        {
            puntaje += 3;
            puntos.text = "Puntos: " + puntaje;
        }

        if (gameObject.tag == "6")
        {
            puntaje += 6;
            puntos.text = "Puntos: " + puntaje;
        }

        if (gameObject.tag == "10")
        {
            puntaje += 10;
            puntos.text = "Puntos: " + puntaje;
        }
    }
}
