using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haniscript : MonoBehaviour
{
    Rigidbody rb;
    private bool playerin = false;
    public GameObject hani;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            if (playerin == false)
            {
                playerin = true;
                hani.SetActive(false);
                rb.isKinematic = false;
            }
        }
    }
}
