using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScriptPlayer : MonoBehaviour
{
    [SerializeField]
    private float bulletVelocity;
    public GameObject projetil_position;

    // Update is called once per frame
    void Update()
    {
        projetil_position.transform.Translate(Vector3.forward * bulletVelocity * Time.deltaTime);
        //transform.Translate(Vector3.up * bulletVelocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Dano entrou");
        }
    }
}
