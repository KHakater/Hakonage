using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliderscript : MonoBehaviour
{
    public GameObject turget;
    public Vector3 turgetpos;
    public float py = 1.3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (turget != null)
        {
            turgetpos = turget.transform.position;
            turgetpos.y += py;
            transform.position = turgetpos;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
