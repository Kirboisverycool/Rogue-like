using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Gate : MonoBehaviour
{
    [Header("Gate")]
    public GameObject[] enemies;
    public int numOfEnemeies;
    public CompositeCollider2D gateCol;

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        OpenGate();
        CloseGate();

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        numOfEnemeies = enemies.Length;
    }

    private void CloseGate()
    {
        if (numOfEnemeies > 0)
        {
            // Close Gate 
            Debug.Log("Close");
            gateCol.isTrigger = false;
        }
    }

    private void OpenGate()
    {
        if(numOfEnemeies <= 0)
        {
            Debug.Log("Open");
            gateCol.isTrigger = true;
        }
    }
}