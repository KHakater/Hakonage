using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class コウモリscript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;//追いかける対象-オブジェクトをインスペクタから登録できるように
    public float speed = 3f;//移動スピード
    private Vector3 vec;
    Rigidbody rb;
    private bool playerin = false;
    public GameObject hani;
    public bool fry = false;
    private float moverX = 0f;
    public int HP;
    public int PsHP;
    public int Atack;
    public Slider eslider;
    public playerscript playerScript;
    public bool aaa = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        PsHP = playerScript.PHP;
        if (fry == true)
        {
            rb.isKinematic = false;
            //transform.position += transform.forward * speed;
            rb.AddForce(transform.forward * speed);
        }
        else
        {
            rb.isKinematic = true;
        }
        if (HP < 1)
        {
            Destroy(this.gameObject);
        }
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
                Fry();
            }
        }
        if (other.CompareTag("bom"))
        {
            HP -= 1;
        }
    }
    void Fry()
    {
        if (aaa == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 1f);
        }
        fry = true;
        aaa = false;
        //targetに向かって進む
        Invoke("Fry",5f);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (playerScript.muteki == false)
            {
                PsHP -= Atack;
                playerScript.PHP = PsHP;
                
            }
            
        }
        if (collision.gameObject.tag == "Ground")
        {
            gameObject.transform.position += new Vector3(0f, 0.1f, 0f);
            fry = false;
            aaa = true;
        }
        PsHP = playerScript.PHP;
    }
}
