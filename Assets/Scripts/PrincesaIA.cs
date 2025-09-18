using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrincesaIA : MonoBehaviour
{

    public Transform playerPosition;
    public List<Vector3> patrolArea;

    public float playerDetectionRange = 10f;
    public float speed = 3f;

    private int index;
    private Vector3 startPos;

    public enum PrincessState
    {
        Idle,
        Saved,
        InCastle,
    }

    private PrincessState currentState = PrincessState.Idle;

    void Start()
    {
        startPos = transform.position;
        index = 0;
    }

    void Update()
    {
        switch (currentState)
        {
            case PrincessState.Idle:
                IdleBehavior();
                break;

            case PrincessState.Saved:
                SavedBehavior(); 
                break;

            case PrincessState.InCastle:
                InCastleBehavior();
                break;
        }
    }

   void IdleBehavior()
    {
        float distance = Vector3.Distance(transform.position, playerPosition.position);
        if (distance < playerDetectionRange)
        {
            currentState = PrincessState.Saved;
        }
    }

    void SavedBehavior()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, playerPosition.position);
        if (distance > playerDetectionRange)
        {
            currentState = PrincessState.Idle;
        }
    }

    void InCastleBehavior()
    {
        Vector3 target = patrolArea[index];
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.2f)
        {
            index++;
            if (index >= patrolArea.Count)
            {
                index = 0;
            }
        }

        if (Vector3.Distance(transform.position, playerPosition.position) <= playerDetectionRange)
        {
            currentState = PrincessState.Saved;
        }
    }
}
