using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KONscript : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision) //衝突時の処理
    {
        if (collision.gameObject.tag == "Ground")
        {
            Invoke("KONdie", 0.5f);
        }
        if (collision.gameObject.tag == "HAKOtag")
        {
            Invoke("KONdie", 0.5f);
        }

        if (collision.gameObject.tag == "player")
        {
            Invoke("KONdie", 0.1f);
        }
    }
    void KONdie()
    {
        Destroy(this.gameObject);
    }
}
