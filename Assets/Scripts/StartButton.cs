using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : Button
{
    // Start is called before the first frame update
    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        AssignButton();
    }
    
    protected override void AssignButton()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(OnClick);
    }
    
    void OnClick()
    {
        playerController.isActive = true;
        spawnManager.gameObject.SetActive(true);
        healthUi.gameObject.SetActive(true);
        GameObject.Find("Start Screen").SetActive(false);
    }
}
