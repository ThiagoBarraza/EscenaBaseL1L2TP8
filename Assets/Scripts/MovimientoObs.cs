using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoObs : MonoBehaviour
{
    public Vector3 PosInicial;
    public Vector3 PosFinal;
    [SerializeField]  int Health;
    public float velocidad;
    bool if1 = false;
    [SerializeField] MeshRenderer MR;
    [SerializeField] GameData GD;
    [SerializeField] float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0 && tiempo > 0)
        {
            MR.enabled = false;
            GD.MinigameBeaten = true;
            tiempo -= Time.deltaTime;
            Debug.Log(tiempo);
        }
        if(Health <= 0 && tiempo < 0)
        {
            SceneManager.LoadScene("Tic L1 L2 controller");
        }

        if (gameObject.transform.position.x <= PosFinal.x && !if1)
        {
            gameObject.transform.Translate(velocidad, 0, 0);
        }
        else
        {
            if1 = true;
        }
        if (gameObject.transform.position != PosInicial && if1)
        {
            gameObject.transform.Translate(-velocidad, 0, 0);
        }
        else
        {
            if1 = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Colision");
        Health--;
    }
}