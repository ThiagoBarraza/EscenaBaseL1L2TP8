using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearPendrive : MonoBehaviour
{
    public bool Near = false;
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
        if(col.gameObject.tag == "Player")
        {
            Near = true;
            Debug.Log("Near a pendrive");
            
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pendrive Acquired");
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Near = false;
        }
    }
}
