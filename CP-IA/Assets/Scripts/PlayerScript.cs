using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float velocity;
    public GameObject shoot;
    public GameObject point_shoot;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal") * velocity * Time.deltaTime;
        float inputZ = Input.GetAxis("Vertical") * velocity * Time.deltaTime;
        transform.Translate(inputX, 0.0f, inputZ);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(shoot, point_shoot.transform.position, transform.rotation);
        }

    }
}
