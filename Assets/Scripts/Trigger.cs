using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject gM;
    void Start()
    {
        gM = GameObject.Find("GM");
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        gM.GetComponent<GameManager>().combat = true;
    }
}
