using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField]
    private float bulletVelocity;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletVelocity * Time.deltaTime);
    }
}
