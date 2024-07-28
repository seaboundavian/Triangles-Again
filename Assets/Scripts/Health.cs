using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]private int maxHP = 10;
    private int currentHP;

    private Slider slider;
    private TextMeshProUGUI lifeText;
    [SerializeField]private GameObject gameOverScreen;
    private PlayerController playerController;
    
    // The functionality for modifying the player's health is abstracted, allowing anyone to simply call the function
    // and provide the damage int to update the health components without knowing what needs to be updated.
    void Start()
    {
        slider = GetComponent<Slider>();
        lifeText = GameObject.Find("Life Number Text").GetComponent<TextMeshProUGUI>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        slider.maxValue = maxHP;
        currentHP = maxHP;
        AlterHealth(0);
    }

    public void AlterHealth(int damage)
    {
        currentHP -= damage;
        slider.value = currentHP;
        lifeText.text = currentHP.ToString();
        if (currentHP == 0)
        {
            gameOverScreen.gameObject.SetActive(true);
            playerController.isLoser = true;
            playerController.isActive = false;
        }
    }
}
