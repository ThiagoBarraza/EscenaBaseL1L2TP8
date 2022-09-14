using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PendriveManager : MonoBehaviour
{
    [SerializeField] GameObject MissionUIElements;
    [SerializeField] GameObject[] ActionUI;
    [SerializeField] bool MissionStarted = false;
    [SerializeField] GameObject[] Pendrives;
    NearPendrive NP;
    NearPC NpC;
    public float tiempo = 5;
    [SerializeField] TMP_Text PickupText;
    [SerializeField] TMP_Text Objective;
    [SerializeField] string[] ObjectiveText;
    private bool AvCharged;


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

        if (NP.Near && Pendrives[1].activeInHierarchy == false && !AvCharged)
        {
            PickUpPendrive();
        }
        

        if(Pendrives[0].activeInHierarchy == false)
        {
            DescargarAV();
        }

        if(!NpC.NearComputer && !NP && MissionStarted)
        {
            ShowActionUI(false);
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && !MissionStarted)
        {
            ShowMissionUI(true);
        }
        if (col.gameObject.tag == "Player" && MissionStarted)
        {
            ShowActionUI(true);
            PickupText.text = "Para insertar";
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

        if (col.gameObject.tag == "Player" && MissionStarted && AvCharged)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Loading Minigame");
                SceneManager.LoadScene("Minigame");
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            ShowMissionUI(false);
        }
        if (col.gameObject.tag == "Player" && MissionStarted)
        {
            ShowActionUI(false);
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
            ShowActionUI(true);
            PickupText.text = "Para agarrar";
            if (Input.GetKeyDown(KeyCode.E))
            {
                ShowActionUI(false);
                Pendrives[0].SetActive(false);
                NP.Near = false;
                Objective.text = ObjectiveText[1];
            }
        }
    }

    
    void DescargarAV()
    {
        if (NpC.NearComputer)
        {
            Debug.Log("DAV");
            if (!Pendrives[1].activeInHierarchy)
            {
                ShowActionUI(true);
                PickupText.text = "Para insertar";
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Pendrives[1].SetActive(true);
                ShowActionUI(false);
                NpC.NearComputer = false;
                Debug.Log("Downloding AV");
            }
            
            
        }
        if (Pendrives[1].activeInHierarchy && tiempo < 0)
        {
            Pendrives[1].SetActive(false);
            ShowActionUI(false);
            NpC.NearComputer = false;
            AvCharged = true;
            Debug.Log("Downloaded AV");
        }
        if (Pendrives[1].activeInHierarchy && tiempo > 0)
        {
            tiempo -= Time.deltaTime;
            Debug.Log(tiempo);
        }
    }

    void ShowActionUI(bool state)
    {
        for (int i = 0; i < ActionUI.Length; i++)
        {
            ActionUI[i].SetActive(state);
        }
    }
}
