using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaDash : Ability
{
    [SerializeField] private float dashForce;
    [SerializeField] private float dashDuration;

    private bool isGrounded = false;
    private bool isFly = false;
    private Rigidbody rb;

    public MeshRenderer player;
    public GameObject playerfly;

    float fly;
    float socrefly = 100;
    public Slider sliderFly;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sliderFly.value = fly;
        fly = socrefly;
        player = GetComponent<MeshRenderer>();
        playerfly.SetActive(false);











    }

    void Update()
    {
        sliderFly.value = fly;
        
        if (fly > 0)
        {
            isFly = true;
        }
        else
        {
            isFly = false;
            player.enabled = true;
            playerfly.SetActive(false);

        }
        if (isFly)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                player.enabled = false;
                playerfly.SetActive(true);
                fly -= 0.1f;
                StartCoroutine(Cast());
            }
            else
            {
                player.enabled = true;
                playerfly.SetActive(false);
            }
        }

        

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 atas = new Vector3(0, 100, 0);
                rb.AddForce(atas * 10f);
                rb.drag = 0f;
            }
            else
            {
                InvokeRepeating("ReScorefly", 5f, 1f);

                if (fly >= 100)
                {
                    CancelInvoke("ReScorefly");

                }
            }

        }


       




        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 atas = new Vector3(0, 100, 0);
            rb.AddForce(atas * 10f);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            rb.drag = 5f;
        }
        else
        {
            rb.drag = 0f;
        }*/
    }

    void ReScorefly()
    {
        fly += 10f;
        CancelInvoke("ReScorefly");
        sliderFly.value = fly;

    }

    public override IEnumerator Cast()
    {
        rb.AddForce(Camera.main.transform.forward * dashForce, ForceMode.VelocityChange);
        


        yield return new WaitForSeconds(dashDuration);

        rb.velocity = Vector3.zero;
    }


    void OnCollisionEnter(Collision data)
    {
        if (data.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision data)
    {
        if (data.gameObject.tag == "floor")
        {
            isGrounded = false;
            rb.drag = 1f;

        }
    }

}
