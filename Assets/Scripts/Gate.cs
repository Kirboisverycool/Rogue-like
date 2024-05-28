using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies == null)
        {
            // Open Gate

            // Spawn Random Weapon Or Item
        }
        else if(enemies != null)
        {
            // Close Gate 
        }

    }


}
