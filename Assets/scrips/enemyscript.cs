using UnityEngine;
using UnityEngine.UI;
public class enemyscript : MonoBehaviour
{
    private int speed = 3;
    Rigidbody rb;
    private Vector3 poso;
    private float moverX = 0f;
    public GameObject gameoverLabelObject;
    public int HP;
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
        PsHP = playerScript.PHP;
        moverX = speed;
        poso = rb.velocity;
        poso.x = moverX;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rb.velocity = poso;
        eslider.value = HP;
        if (HP <1)
        {
            
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("return"))
        {
            speed = speed * -1;
            moverX = speed * 2;
            poso = rb.velocity;
            poso.x = moverX;
        } 
        if (other.CompareTag("bom"))
        {
            HP -= 1;
        }
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
    }

}
