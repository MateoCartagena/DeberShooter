using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;

    public Objetos objetos;
    private int tiros = 0;
    private int cubosDestruidos = 0;
    private int esferasDestruidas = 0;

    private string textoContador;
    public TextMeshProUGUI textoEnPantalla;
 
    LineRenderer laserLine;
    float fireTimer;
 
    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        textoEnPantalla = GetComponent<TextMeshProUGUI>();
    }
 
    void Update()
    {
        fireTimer += Time.deltaTime;
        if(Input.GetButtonDown("Fire1") && fireTimer > fireRate)
        {
            fireTimer = 0;
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
            {
                laserLine.SetPosition(1, hit.point);
                //Destroy(hit.transform.gameObject);

                if (hit.transform.CompareTag("Cubo"))
                {
                    tiros++;
                    if (tiros >= 2)
                    {
                    Destroy(hit.transform.gameObject);
                        tiros = 0;
                            cubosDestruidos++;

                            
                        objetos.GenerarObjeto("Cubo");
                    }
                }
                else if (hit.transform.CompareTag("Esfera"))
                {
                    tiros++;
                    if (tiros >= 3)
                    {
                        Destroy(hit.transform.gameObject);
                        tiros = 0;
                            esferasDestruidas++;
                        objetos.GenerarObjeto("Esfera");
                    }
                }
                else
                {
                    tiros++;
                }


                textoContador = "Cubos: " + cubosDestruidos + "\nEsferas: " + esferasDestruidas;
                textoEnPantalla.text = textoContador + "HOLAAA";
            
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            }
            StartCoroutine(ShootLaser());
        }
    }
 
    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}