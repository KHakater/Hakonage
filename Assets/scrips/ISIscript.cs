using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISIscript : MonoBehaviour
{
    Rigidbody rb;
    public GameObject explode;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision) //衝突時の処理
    {
        if (collision.gameObject.tag == "Ground")
        {
            ban();
        }
        if (collision.gameObject.tag == "HAKOtag")
        {
            ban();
        }
        if (collision.gameObject.tag == "player")
        {
            ban();
        }
    }
    void ban()
    {
        rb.isKinematic = true;
        this.transform.localScale = Vector3.zero; //みえない大きさにする
        explode.transform.localScale = new Vector3(2f, 2f, 2f);
        Instantiate(explode, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
