using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 10.0f;
    private float xOutOfRange = 25.0f;
    private float yOutOfRange = 15.0f;

    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isActive)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            checkOutOfRange();
        }

        if (playerController.isLoser)
        {
            Destroy(gameObject);
        }
    }
    
    private float RandomRotation()
    {
        return Random.Range(0, 360);
    }

    private void checkOutOfRange()
    {
        if (transform.position.x > xOutOfRange || transform.position.x < -xOutOfRange)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > yOutOfRange || transform.position.y < -yOutOfRange)
        {
            Destroy(gameObject);
        }
    }

    private void Spawn()
    {
        int direction = Random.Range(1, 5);
        Debug.Log("Direction set to" + direction);

        switch (direction)
        {
            case 1:
                //West
                transform.position = new Vector2(-xOutOfRange + 1, Random.Range(-yOutOfRange + 1, yOutOfRange - 1));
                transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            case 2:
                //South
                transform.position = new Vector2(Random.Range(-xOutOfRange + 1, xOutOfRange - 1), -yOutOfRange + 1);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 3:
                //East
                transform.position = new Vector2(xOutOfRange - 1, Random.Range(-yOutOfRange + 1, yOutOfRange - 1));
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case 4:
                //North
                transform.position = new Vector2(Random.Range(-xOutOfRange + 1, xOutOfRange - 1), yOutOfRange - 1);
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            default:
                Debug.Log("Invalid Spawn Selection in EnemyController");
                break;
        }
        
    }
}
