using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerSwitch : MonoBehaviour
{
    [SerializeField] GameObject box1;
    [SerializeField] GameObject box2;
    [SerializeField] MonoBehaviour player1Movement;
    [SerializeField] MonoBehaviour player2Movement;
    [SerializeField] MonoBehaviour player1Position;
    [SerializeField] MonoBehaviour player2Position;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            if(box1.activeSelf == true)
            {
                SwitchPlayer1();
            }
            else
            {
                SwitchPlayer2();
            }
        }
    }
    void SwitchPlayer1()
    {
        player2Movement.enabled = true;
        player1Movement.enabled = false;
        player2Position.enabled = false;
        player1Position.enabled = true;
        box1.SetActive(false);
        box2.SetActive(true);
    }
    // TODO:
    // 1. Colors Switch
    // 2. Kill if in block overlap circle
    // 3. Another Level
    void SwitchPlayer2()
    {
        player2Movement.enabled = false;
        player1Movement.enabled = true;
        player2Position.enabled = true;
        player1Position.enabled = false;
        box2.SetActive(false);
        box1.SetActive(true);
    }
}
