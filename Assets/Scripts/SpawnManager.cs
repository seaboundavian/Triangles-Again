using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemies;
    [SerializeField] private float spawnRate;
    private int score = 0;

    private PlayerController playerController;

    [SerializeField]private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        Instantiate(enemies);
        StartCoroutine("SpawnEnemies");
    }

    IEnumerator SpawnEnemies()
    {
        while (playerController.isActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemies);
            score++;
            scoreText.text = score.ToString();
        }
    }
}
