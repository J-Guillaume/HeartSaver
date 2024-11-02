using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjectL : MonoBehaviour
{
    public float WhatSpeed = 5;
    public GameObject WhatToGenerate;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.B))
        {
            GameObject Current = Instantiate(WhatToGenerate, transform.position, Quaternion.identity);
            Rigidbody CurrentRB = Current.GetComponent<Rigidbody>();
            CurrentRB.velocity = transform.forward * WhatSpeed;
            GetComponent<AudioSource>().pitch = Random.Range(0.3f, 1.0f);
            GetComponent<AudioSource>().Play();
        }
    }
}
