using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class きのこscript : MonoBehaviour
{
    public GameObject Housi;
    public float time1;
    public Vector3 tamago;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("First", time1);
        tamago = transform.position;
        tamago.y += 1.4f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void First()
    {
        Invoke("Re", 4f);
    }
    void Re()
    {
        GameObject createdHousi = Instantiate(Housi) as GameObject;
        createdHousi.transform.position = tamago;
        Invoke("Re", 4f);
    }
}
