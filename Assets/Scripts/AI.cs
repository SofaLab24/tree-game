using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AI : MonoBehaviour
{
    private Rigidbody2D enemyR;

    private GameObject player;
    private Transform playerT;
    // Start is called before the first frame update

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerT = player.transform;
        enemyR = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > playerT.position.x)
        {
            //target is left
            playerT.localScale = new Vector2(-1, 1);
            enemyR.velocity = new Vector2(-2f, 0f); // -2f galima pakeisti "movement speed"
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y), 2f * Time.deltaTime);
        }
        else if (transform.position.x < playerT.position.x)
        {
            //target is right
            transform.localScale = new Vector2(1, 1);
            enemyR.velocity = new Vector2(2f, 0f);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y), 2f * Time.deltaTime);
        }
    }
}
