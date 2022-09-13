using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PendriveManager : MonoBehaviour
{
    [SerializeField] GameObject MissionUIElements;
    [SerializeField] GameObject[] ActionUI;
    [SerializeField] bool MissionStarted = false;
    [SerializeField] GameObject[] Pendrives;
    NearPendrive NP;
    NearPC NpC;
    [SerializeField] TMP_Text PickupText;
    [SerializeField] TMP_Text Objective;
    [SerializeField] string[] ObjectiveText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        MissionUIElements = GameObject.FindGameObjectWithTag("PMisionLabel");
        MissionUIElements.SetActive(false);
        for(int i = 1; i < Pendrives.Length; i++)
        {
            Pendrives[i].SetActive(false);
        }
        ActionUI = GameObject.FindGameObjectsWithTag("ActionUI");
        for(int i = 0; i < ActionUI.Length; i++)
        {
            ActionUI[i].SetActive(false);
        }
        NP = FindObjectOfType<NearPendrive>();
        NpC = FindObjectOfType<NearPC>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MissionStarted && Pendrives[0].activeInHierarchy == true)
        {
            Objective.text = ObjectiveText[0];
        }

        if (NP.Near && Pendrives[1].activeInHierarchy == false)
        {
            PickUpPendrive();
        }
        

        if(NpC.NearComputer && Pendrives[0].activeInHierarchy == false)
        {
            DescargarAV();
        }

        if(!NpC.NearComputer && !NP && MissionStarted)
        {
            for (int i = 0; i < ActionUI.Length; i++)
            {
                ActionUI[i].SetActive(false);
            }
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && !MissionStarted)
        {
            ShowMissionUI(true);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && !MissionStarted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MissionStarted = true;
                Debug.Log("MissionStarted");
                ShowMissionUI(false);
            }
            
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            ShowMissionUI(false);
        }
    }

    
    void ShowMissionUI(bool state)
    {
        MissionUIElements.SetActive(state);
        for(int i = 0; i < ActionUI.Length; i++)
        {
            ActionUI[i].SetActive(state);
        }

    }

    
    void PickUpPendrive()
    {
        Debug.Log("Picking");
        if (Pendrives[0].activeInHierarchy == true)
        {
            for (int i = 0; i < ActionUI.Length; i++)
            {
                ActionUI[i].SetActive(true);
            }
            PickupText.text = "Para agarrar";
            if (Input.GetKeyDown(KeyCode.E))
            {
                for (int i = 0; i < ActionUI.Length; i++)
                {
                    ActionUI[i].SetActive(false);
                }
                Pendrives[0].SetActive(false);
                NP.Near = false;
                Objective.text = ObjectiveText[1];
            }
        }
    }

    float tiempo = 3;
    void DescargarAV()
    {
        Debug.Log("DAV");
        
        for (int i = 0; i < ActionUI.Length; i++)
        {
            ActionUI[i].SetActive(true);
        }
        PickupText.text = "Para insertar";
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pendrives[1].SetActive(true);
            NpC.NearComputer = false;
            PickupText.text = "Para retirar";
            Debug.Log("Downloding AV");
        }
        //if (Input.GetKeyDown(KeyCode.E) && Pendrives[1] == true && tiempo < 0)
        //{
        //    Pendrives[1].SetActive(false);
        //    NpC.NearComputer = false;
            
        //    Debug.Log("Downloaded AV");
        //}
        //else
        //{
        //    tiempo -= Time.deltaTime;
        //}
    }
}
