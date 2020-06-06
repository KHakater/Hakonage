using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baramakiscript : MonoBehaviour
{
    public GameObject KON;
    private Vector3 BBB;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("baramaku", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void baramaku()
    {
        BBB = this.transform.position;
        BBB.y -= 1;
        GameObject createdKON = Instantiate(KON) as GameObject;
        createdKON.GetComponent<Rigidbody>().AddForce(0, 0, 0);
        createdKON.transform.position = BBB;
        Invoke("baramaku", 3f);
    }
}
