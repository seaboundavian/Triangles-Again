using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField]private UnityEngine.UI.Button button;
    [SerializeField] private GameObject spawnManager;
    private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject healthUi;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        button = GetComponent<UnityEngine.UI.Button>();
        if (CompareTag("Respawn"))
        {
            button.onClick.AddListener(BackToMenu);
        }
        else
        {
            button.onClick.AddListener(StartGame);    
        }
        
    }

    void StartGame()
    {
        playerController.isActive = true;
        spawnManager.gameObject.SetActive(true);
        healthUi.gameObject.SetActive(true);
        GameObject.Find("Start Screen").SetActive(false);
    }

    void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
