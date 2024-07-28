using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button : MonoBehaviour
{
    //All UI buttons inherit variables from this parent class. AssignButton() is "morphed" for each button.
    [SerializeField]protected UnityEngine.UI.Button button;
    [SerializeField] protected GameObject spawnManager;
    private TextMeshProUGUI scoreText;
    [SerializeField] protected GameObject healthUi;
    protected PlayerController playerController;
    // Start is called before the first frame update
    
    protected virtual void AssignButton()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        Debug.Log("This button is generic and does nothing.");
    }
}
