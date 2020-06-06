using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Housiscript : MonoBehaviour
{
    public float zzz;
    // Start is called before the first frame update
    void Start()
    {
        zzz = transform.position.z - 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale += new Vector3(0.05f, 0.05f, 0);
        gameObject.transform.position -= new Vector3(0, 0, 0.07f);
        if (zzz > transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }
    
}
