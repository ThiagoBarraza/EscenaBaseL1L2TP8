using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUIEnd : MonoBehaviour
{
    [SerializeField] GameObject[] UIToHide1;
    [SerializeField] GameObject[] UIToHide2;
    // Start is called before the first frame update
    void Start()
    {
        UIToHide1 = GameObject.FindGameObjectsWithTag("PMisionLabel");
        UIToHide2 = GameObject.FindGameObjectsWithTag("ActionUI");
        for (int i = 0; i < UIToHide1.Length; i++)
        {
            UIToHide1[i].SetActive(false);
        }
        for (int i = 0; i < UIToHide2.Length; i++)
        {
            UIToHide2[i].SetActive(false);
        }
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < UIToHide1.Length; i++)
        {
            UIToHide1[i].SetActive(false);
        }
        for (int i = 0; i < UIToHide2.Length; i++)
        {
            UIToHide2[i].SetActive(false);
        }
    }
}
