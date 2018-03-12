using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlArma : MonoBehaviour {

    [SerializeField]
    private GameObject bala;
    [SerializeField]
    private float velocidad_bala;
    [SerializeField]
    private GameObject canon;
    [SerializeField]
    private GameObject frente;
    [SerializeField]
    private Camera camara;
    [SerializeField]
    private GameObject pos_inicial;
    [SerializeField]
    private GameObject pos_final;
    [SerializeField]
    private Text UI_disparos;
    [SerializeField]
    private int UI_tiros = 2;
  


    private Rigidbody2D rb_bala;
    private bool disparo = false;
    private bool mov = false;
    private int tiros = 0;
    

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && disparo == false && mov == false && UI_tiros != 0)
        {
            disparo = true;
            mov = true;
            camara.transform.position = pos_inicial.transform.position;
            tiros += 1;
            UI_tiros -= 1;
            UI_disparos.text = "Disparos: " + UI_tiros;
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            camara.transform.position = pos_inicial.transform.position;
        }

        if(disparo)
        {
            Disparar();
        }

        if(mov)
        {
            MoverCamara();
            if(Vector2.Distance(camara.transform.position,pos_final.transform.position) <= 0.5f)
            {
                mov = false;
            }
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);

    }

    private void Disparar()
    {
        Vector2 direccion = frente.transform.position - canon.transform.position;
        direccion.Normalize();
        GameObject clon = Instantiate(bala, bala.transform.position, Quaternion.identity);
        rb_bala = clon.GetComponent<Rigidbody2D>();
        rb_bala.velocity = Vector3.zero;
        clon.transform.position = canon.transform.position;
        rb_bala.AddForce(direccion * velocidad_bala, ForceMode2D.Impulse);
        disparo = false;
    }

    private void MoverCamara()
    {
        camara.transform.position = Vector3.MoveTowards(camara.transform.position, pos_final.transform.position, velocidad_bala * Time.deltaTime);
    }
}
