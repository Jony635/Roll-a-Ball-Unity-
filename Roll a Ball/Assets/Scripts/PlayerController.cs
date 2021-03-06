using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int PickUps_Collected;
    public Text countText;
    public Text winText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PickUps_Collected = 0;
        countText.text = "Pick Ups collected: " + PickUps_Collected.ToString();
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        rb.AddForce(movement * speed);
    }

    void LateUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            PickUps_Collected++;
            other.gameObject.SetActive(false);
            countText.text = "Pick Ups collected: " + PickUps_Collected.ToString();
            if (PickUps_Collected == 6)
            {
                winText.gameObject.SetActive(true);
            }
        }
    }
}
