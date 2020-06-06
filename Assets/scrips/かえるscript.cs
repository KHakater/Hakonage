using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class かえるscript : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;
    public float playerx;
    public float kaerux;
    private int pyon = -360;
    public GameObject gameoverLabelObject;
    public int HP;
    private bool playerin = false;
    public GameObject hani;
    public int PsHP;
    public int Atack;
    public playerscript playerScript;
    public Slider eslider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        eslider.maxValue = HP;
    }

    // Update is called once per frame
    void Update()
    {
        eslider.value = HP;
        PsHP = playerScript.PHP;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        playerx = player.transform.position.x;
        kaerux = transform.position.x;
        if (kaerux > playerx)
        {
            pyon = -360;
        }
        else
        {
            pyon = 360;
        }
        if (HP < 1)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector3.zero;
            if (playerin == true)
            {
                Invoke("haneru", 0.4f);
            }
        }

        if (collision.gameObject.CompareTag("HAKOtag"))
        {
            rb.velocity = Vector3.zero;
            if (playerin == true)
            {
                Invoke("haneru", 0.4f);
            }
        }
        if (collision.gameObject.tag == "player")
        {
            if (playerScript.muteki == false)
            {
                PsHP -= Atack;
                playerScript.PHP = PsHP;
            }
        }
    }
    void haneru()
    {
        Vector3 force = new Vector3(pyon, 2000f,0f);
        rb.AddForce(force);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bom"))
        {
            if (playerin == true)
            {
                HP -= 1;
            }
        }
        if (other.CompareTag("player"))
        {
            if (playerin == false)
            {
                Invoke("haneru", 0.5f);
            }
            playerin = true;
            hani.SetActive(false);
        }
    }
}
