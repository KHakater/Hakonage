using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAGEHAKOscript : MonoBehaviour
{
    Rigidbody rb;
    public GameObject explode;
    private Vector3 scale;
    private float kousinniti = 0;
    private float mrhigh = 0;
    public float bomscale = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        kousinniti = transform.position.y;
        mrhigh = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > kousinniti)
        {
            mrhigh = transform.position.y;
            kousinniti = transform.position.y;
        }
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
        if (collision.gameObject.tag == "enemy")
        {
            ban();
        }
    }
    void ban()
    {
        mrhigh -= transform.position.y;
        bomscale = mrhigh * 1f;
        if (bomscale < 0)
        {
            bomscale = 0.3f;
        }
        rb.isKinematic = true;
        this.transform.localScale = Vector3.zero; //みえない大きさにする
        explode.transform.localScale = new Vector3(bomscale, bomscale, bomscale);
        Instantiate(explode, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
