using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM2 : MonoBehaviour
{

    public float vision_distance;
    public float velocity;
    public float health;
    public GameObject shoot;
    public GameObject target;
    public GameObject point_shoot;
    Vector3 inicial_position;
    bool attacking;

    int PATROL = 0;
    int CHASE = 1;
    int ATTACK = 2;
    int state;

    public void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            inicial_position, velocity * Time.deltaTime);
    }

    public void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            target.transform.position, velocity * Time.deltaTime);
    }

    public void Attack()
    {
        if (attacking == false)
        {
            transform.LookAt(target.transform);
            StartCoroutine(Shoot());
            attacking = true;
        }
    }


    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.3f);
        if (state == ATTACK)
        {
            Instantiate(shoot, point_shoot.transform.position, transform.rotation);
            StartCoroutine(Shoot());      
        }
        else
        {
            attacking = false;
        }
    }

    public void FSM()
    {
        if (state == PATROL)
        {
            Patrol();
        }
        else if (state == CHASE)
        {
            Chase();
        }
        else if (state == ATTACK)
        {
            Attack();
        }
    }


    public void Start()
    {
        // OBTEM A POSICAO PARA ONDE ELE DEVE RETORNAR
        inicial_position = transform.position;

        // OBTEM O JOGADOR
        //target = GameObject.Find("Player");
        target = GameObject.FindGameObjectWithTag("Player");
    }


    public void Update()
    {
        // IMPLEMENTAÇÃO DA REGRA
        float r = Vector3.Distance(transform.position, target.transform.position);

        if (r > vision_distance || health < 10.0f)
        {
            state = PATROL;
        }
        else
        {
            if (r < vision_distance / 2)
            {
                state = ATTACK;
            }
            else
            {
                state = CHASE;
            }
        }

        // MAQUINA DE ESTADO
        FSM();

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "PlayerProjetil")
        {
            Debug.Log("Dano entrou");
        }
    }
}
