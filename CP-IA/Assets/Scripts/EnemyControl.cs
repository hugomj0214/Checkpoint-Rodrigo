using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyControl : MonoBehaviour
{
    
    private Transform alvo;
    public Transform alvo_player;
    public float velocidade;
    public GameObject chamarIA_alerta;
    public float campoVisao;

    private Estados estadoAtual;

    public enum Estados
    {
        Esperar,
        Patrulhar,
        Alerta
    }

    [Header("Estado: Esperar")]
    public float tempoEsperar = 2f;
    private float tempoEsperando;

    [Header("Estado: Patrulhar")]
    public Transform waypoint1;
    public Transform waypoint2;
    public Transform waypoint3;
    public Transform waypoint4;
    private Transform waypointAtual;
    public float distanciaMinimaWaypoint = 2f;
    private float distanciaWaypointAtual;

    // Start is called before the first frame update
    void Start()
    {
        waypointAtual = waypoint1;

        Esperar();
    }

    // Update is called once per frame
    void Update()
    {

        ChecarEstados();

        //Movimenta o Agente
        transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
        transform.LookAt(alvo.transform.position);


    }

    private void ChecarEstados()
    {
        switch (estadoAtual)
        {
            case Estados.Esperar:
                if (EsperouTempoSuficiente())
                {
                    Patrulhar();
                }
                else
                {
                    alvo = transform;
                }
                break;
            case Estados.Patrulhar:
                if (PertoWaypointAtual())
                {
                    Esperar();

                    AlterarWaypoint();
                }
                else
                {
                    alvo = waypointAtual;
                }

                break;
            case Estados.Alerta:
                break;
            default:
                break;
        }
    }

    private bool EsperouTempoSuficiente()
    {
        return tempoEsperando + tempoEsperar <= Time.time;
    }

    //ESTADO DE IDLE
    private void Esperar()
    {
        estadoAtual = Estados.Esperar;
        tempoEsperando = Time.time;
    }

    //MÉTODOS ESTADO PATROL
    private void Patrulhar()
    {
        estadoAtual = Estados.Patrulhar;
    }
    private bool PertoWaypointAtual()
    {
        distanciaWaypointAtual = Vector3.Distance(transform.position,waypointAtual.position);
        return distanciaWaypointAtual <= distanciaMinimaWaypoint;

    }
    private void AlterarWaypoint()
    {
        //waypointAtual = (waypointAtual == waypoint1) ? waypoint2 : waypoint1;
        if (waypointAtual == waypoint1)
        { 
            waypointAtual = waypoint2;
        }
            else if (waypointAtual == waypoint2)
            {
                waypointAtual = waypoint3;
            }
                else if (waypointAtual == waypoint3)
                {
                    waypointAtual = waypoint4;
                }
                else
                {
                    waypointAtual = waypoint1;
                }

    } 
}
