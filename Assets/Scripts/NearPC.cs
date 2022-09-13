using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearPC : MonoBehaviour
{
    public bool NearComputer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        
            if (col.gameObject.tag == "Player")
            {
                NearComputer = true;
                Debug.Log("Near a computer");

            }
        

    }
    void OnTriggerExit(Collider col)
    {
        
        
            if (col.gameObject.tag == "Player")
            {
                NearComputer = false;


            }
        
    }
}
