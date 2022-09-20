using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToAnimate : MonoBehaviour
{
    [SerializeField] Animator Anim;
    [SerializeField] bool State;
    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(State == false)
        {
            Anim.SetBool("Open", true);
            Debug.Log(State);
            State = true;
        }
        else
        {
            Anim.SetBool("Open", false);
            Debug.Log(State);
            State = false;
        }

    }
}
