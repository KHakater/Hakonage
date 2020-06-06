using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomscript : MonoBehaviour
{
    public float bomtime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("haibaan", bomtime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void haibaan()
    {
        Destroy(this.gameObject);
    }
}
