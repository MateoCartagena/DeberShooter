using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    public GameObject cuboPrefab;
    public GameObject esferaPrefab;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;
    public float minXE;
    public float maxXE;
    public float minYE;
    public float maxYE;
    public float minZE;
    public float maxZE;

    public int cantidadInicialCubos = 3;
    public int cantidadInicialEsferas = 3;

    private int cubosGenerados = 0;
    private int esferasGeneradas = 0;

    void Start()
    {
        // Genera la cantidad inicial de cubos y esferas al inicio
        GenerarObjetos("Cubo", cantidadInicialCubos);
        GenerarObjetos("Esfera", cantidadInicialEsferas);
    }

    public void GenerarObjetos(string tipo, int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            GenerarObjeto(tipo);
        }
    }

    public void GenerarObjeto(string tipo)
    {
        GameObject nuevoObjeto = null;

        if (tipo == "Cubo" && cubosGenerados < 100000)
        {
            nuevoObjeto = Instantiate(cuboPrefab, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);
            nuevoObjeto.tag = "Cubo";
            cubosGenerados++;
        }
        else if (tipo == "Esfera" && esferasGeneradas < 100000)
        {
            nuevoObjeto = Instantiate(esferaPrefab, new Vector3(Random.Range(minXE, maxXE), Random.Range(minYE, maxYE), Random.Range(minZE, maxZE)), Quaternion.identity);
            nuevoObjeto.tag = "Esfera";
            esferasGeneradas++;
        }
    }
}