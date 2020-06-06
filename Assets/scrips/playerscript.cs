using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerscript : MonoBehaviour
{
    public int speed;
    private float moveX = 0f;
    public float jumpForce;
    private Vector3 pos;
    private Vector3 toro;
    private int jumpint = 0;
    public GameObject HAKO;
    public GameObject NAGEHAKO;
    private bool HKokitime = true;
    public int HAKOkazu = 0;
    private bool HAKOokeru = true;
    private bool zimen = false;
    private float beforey;
    private float aftery;
    public int HAKOwhich = 1;
    float h;
    float v;
    public GameObject clearObject;
    public Text HAKOText;
    private string HAKOiro = "茶";
    public GameObject gameoverLabelObject;
    public int PHP = 100;
    public bool muteki = false;
    public Slider slider;
    public bool Tyaazi = true;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        beforey = transform.position.y;
        slider = GameObject.Find("PSlider").GetComponent<Slider>();
    }

    
    // Update is called once per frame
    void Update()
    {
        aftery = transform.position.y;
        if (beforey == aftery)
        {
            zimen = true;
        }
        else
        {
            zimen = false;
        }
        beforey = aftery;
        toro = transform.position;
        moveX = Input.GetAxis("Horizontal") * speed;
        pos = rb.velocity;
        pos.x = moveX;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (Input.GetButtonDown("jump"))
        {
            if (jumpint < 2)
            {
                rigidbody.AddForce(Vector3.up * jumpForce);
                jumpint += 1;
            }
        }
        if (Input.GetButtonDown("which"))
        {
            HAKOwhich = HAKOwhich * -1;
            if (HAKOwhich == 1)
            {
                HAKOiro = "茶";
            }
            else
            {
                HAKOiro = "白";
            }
        }
        if (Input.GetButtonDown("HAKOdasu"))
        {
            if (HAKOwhich == 1)
            {
                TyaHAKO();
            }
            else
            {
                SiroHAKO();
            }
        }
        HAKOText.text = HAKOiro + ":あと" + HAKOkazu;
        if (PHP < 1)
        {
            gameoverLabelObject.SetActive(true);
            Invoke("Load", 3f);
        }
        slider.value = PHP;
    }
    private void FixedUpdate()
    {
        rb.velocity = pos;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpint = 0;
        }
        if (collision.gameObject.CompareTag("HAKOtag"))
        {
            jumpint = 0;
        }
        if (collision.gameObject.CompareTag("KON"))
        {
            if (muteki == false)
            {
                PHP -= 7;
                Invoke("mutekinaru", 0.03f);
                Invoke("kaizyo", 1f);
            }
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            Invoke("mutekinaru",0.01f);
            Invoke("kaizyo", 1f);
        }
        if (collision.gameObject.CompareTag("K1"))
        {
            gameObject.layer = LayerMask.NameToLayer ("s");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HAKOtag"))
        {
            HAKOokeru = false;
        }
        if (other.CompareTag("Ground"))
        {
            HAKOokeru = false;
        }
        if (other.CompareTag("Clear"))
        {
            clearObject.SetActive(true);
            Invoke("Load", 3f);
        }
        if (other.CompareTag("Housi"))
        {
            if (muteki == false)
            {
                PHP -= 7;
                Invoke("mutekinaru", 0.03f);
                Invoke("kaizyo", 1f);
                speed -= 1;
                Invoke("Housi", 5f);
            }
        }
        if (other.CompareTag("ISI"))
        {
            if (muteki == false)
            {
                PHP -= 15;
                Invoke("mutekinaru", 0.03f);
                Invoke("kaizyo", 1f);
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HAKOtag"))
        {
            HAKOokeru = true;
        }
        if (other.CompareTag("enemy"))
        {
            HAKOokeru = true;
        }
        if (other.CompareTag("Ground"))
        {
            HAKOokeru = true;
        }
    }
    void ZKNtatu()
    {
        HKokitime = true;
    }
    void TyaHAKO()
    {
        if (HAKOokeru == true)
        {
            if (HAKOkazu > 0)
            {
                if (HKokitime == true)
                {
                    h = Input.GetAxis("Axis 4");
                    v = Input.GetAxis("Axis 5");
                    //ジャンプした時だけ下に置けるようにする
                    if (0.8f < v)
                    {
                        if (zimen == false)
                        {
                            toro.y = toro.y - 1.3f;
                            GameObject createdHAKO = Instantiate(HAKO) as GameObject;
                            createdHAKO.transform.position = toro;
                            HKokitime = false;
                            Invoke("ZKNtatu", 1f);
                            zimen = false;
                            HAKOkazu -= 1;
                        }
                    }
                    else if (0.8f < h)
                    {
                        toro.x = toro.x + 1f;
                        GameObject createdHAKO = Instantiate(HAKO) as GameObject;
                        createdHAKO.transform.position = toro;
                        HKokitime = false;
                        Invoke("ZKNtatu", 1f);
                        HAKOkazu -= 1;
                    }
                    else if (-0.8f > h)
                    {
                        toro.x = toro.x - 1f;
                        GameObject createdHAKO = Instantiate(HAKO) as GameObject;
                        createdHAKO.transform.position = toro;
                        HKokitime = false;
                        Invoke("ZKNtatu", 1f);
                        HAKOkazu -= 1;
                    }
                        
                }
            }
        }
    }
    void SiroHAKO()
    {
        if (Tyaazi == true)
        {
            if (HAKOkazu > 0)
            {
                h = Input.GetAxis("Axis 4");
                v = Input.GetAxis("Axis 5");
                if (h >= 0)
                {
                    toro.x = toro.x + 1f;
                    toro.y = toro.y + 1f;
                }
                else
                {
                    toro.x = toro.x - 1f;
                    toro.y = toro.y + 1f;
                }
                h = h * 500f;
                v = v * -500f;
                GameObject createdNAGEHAKO = Instantiate(NAGEHAKO) as GameObject;
                createdNAGEHAKO.GetComponent<Rigidbody>().AddForce(h, v, 0);
                createdNAGEHAKO.transform.position = toro;
                HAKOkazu -= 1;
                Tyaazi = false;
                Invoke("Tyazif", 0.3f);
            }
        }
    }
    void kaizyo()
    {
        muteki = false;
    }
    void mutekinaru()
    {
        muteki = true;
    }
    void Housi()
    {
        speed += 1;
    }
     void Load()
    {
        SceneManager.LoadScene("セレクト画面");
    }
    void Tyazif()
    {
        Tyaazi = true;
    }
}
