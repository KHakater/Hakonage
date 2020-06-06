using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kaasoruscript : MonoBehaviour
{
    public int stage = 1;
    public float before6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("6") == 1)
        {
            if (before6 == 0)
            {
                if (stage < 4)
            {
                stage += 1;
                if (stage % 2 == 0)
                {
                    transform.Translate(2f, -6f, 0f);
                }
                else
                {
                    transform.Translate(2f, 6f, 0f);
                }
            }
            }
        }
        if (Input.GetAxis("6") == -1)
        {
            if (before6 == 0)
            {
                if (stage > 1)
                {
                    stage -= 1;
                    if (stage % 2 == 0)
                    {
                        transform.Translate(-2f, -6f, 0f);
                    }
                    else
                    {
                        transform.Translate(-2f, 6f, 0f);
                    }
                }
            }
        }
        before6 = Input.GetAxis("6");
        if (Input.GetButtonDown("jump"))
        {
            SceneManager.LoadScene(stage);
        }
    }
}
