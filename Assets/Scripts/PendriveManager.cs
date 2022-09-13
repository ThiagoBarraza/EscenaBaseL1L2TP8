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
    }

    // Update is called once per frame
    void Update()
    {
        if (MissionStarted)
        {
            StartMission();
        }

        if (NP.Near)
        {
            PickUpPendrive();
        }

        //if(NP.Near && picked)
        //{
        //    DescargarAV();
        //}
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

    [SerializeField] bool picked = false;
    void PickUpPendrive()
    {
        Debug.Log("Picking");
        
            for (int i = 0; i < ActionUI.Length; i++)
            {
                ActionUI[i].SetActive(true);
            }
            PickupText.text = "Para agarrar";
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                picked = true;
                for (int i = 0; i < ActionUI.Length; i++)
                {
                    ActionUI[i].SetActive(false);
                }
                Destroy(Pendrives[0]);
            }
        
    }
    void StartMission()
    {
        Objective.text = ObjectiveText[0];

        if(picked == true)
        {
            Objective.text = ObjectiveText[1];
        }
    }

    void DescargarAV()
    {
        if (picked)
        {
            for (int i = 0; i < ActionUI.Length; i++)
            {
                ActionUI[i].SetActive(true);
            }
            PickupText.text = "Para insertar";
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            picked = false;
            for (int i = 0; i < ActionUI.Length; i++)
            {
                ActionUI[i].SetActive(false);
            }
            Pendrives[1].SetActive(true);
        }
    }
}
