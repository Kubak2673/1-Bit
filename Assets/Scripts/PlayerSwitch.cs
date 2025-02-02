using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerSwitch : MonoBehaviour
{
    [SerializeField] GameObject box1;
    [SerializeField] GameObject box2;
    [SerializeField] MonoBehaviour player1Movement;
    [SerializeField] MonoBehaviour player2Movement;
    [SerializeField] MonoBehaviour player1Position;
    [SerializeField] MonoBehaviour player2Position;
    [SerializeField] BoxCollider2D boxCollider1;
    [SerializeField] BoxCollider2D boxCollider2;
    [SerializeField] CapsuleCollider2D circleCollider1;
    [SerializeField] CapsuleCollider2D circleCollider2;
    [SerializeField] GameObject BGWhite1;
    [SerializeField] GameObject BGWhite2;
    [SerializeField] GameObject BGBlack1;
    [SerializeField] GameObject BGBlack2;
    [SerializeField] GameObject GroundWandB;
    [SerializeField] GameObject GroundBandW;
    [SerializeField] GameObject Walls1;
    [SerializeField] AudioClip switchon;
    AudioSource audioSource;
    [SerializeField] GameObject Walls2;
    [SerializeField] GameObject Death1;
    [SerializeField] GameObject Death2;
    [SerializeField] GameObject decowhite1;
    [SerializeField] GameObject decowhite2;
    [SerializeField] GameObject decoblack1;
    [SerializeField] GameObject decoblack2;
    [SerializeField] GameObject collidersBox1;
    [SerializeField] GameObject collidersBox2;
    [SerializeField] SpriteRenderer player1;
    [SerializeField] SpriteRenderer player2;
    [SerializeField] Sprite phase;
    [SerializeField] Sprite normal;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    void OnInteract(InputValue value)
    {
        if (circleCollider1.IsTouchingLayers(LayerMask.GetMask("Interact")) || circleCollider2.IsTouchingLayers(LayerMask.GetMask("Interact")) || boxCollider1.IsTouchingLayers(LayerMask.GetMask("Interact")) || boxCollider2.IsTouchingLayers(LayerMask.GetMask("Interact")))
        {
            return;
        }
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
        audioSource.PlayOneShot(switchon, 1f);
        player2Movement.enabled = true;
        player1Movement.enabled = false;
        player2Position.enabled = false;
        player1Position.enabled = true;
        box1.SetActive(false);
        box2.SetActive(true);
        BGBlack1.SetActive(false);
        BGWhite1.SetActive(true);
        BGBlack2.SetActive(true);
        BGWhite2.SetActive(false);
        Walls1.SetActive(false);
        Walls2.SetActive(true);
        decoblack1.SetActive(true);
        decowhite1.SetActive(false);
        decoblack2.SetActive(false);
        decowhite2.SetActive(true);
        player1.sprite = phase;
        player2.sprite = normal;
        collidersBox1.SetActive(false);
        collidersBox2.SetActive(true);
        GroundWandB.SetActive(false);
        GroundBandW.SetActive(true);
        Death1.SetActive(true);
        Death2.SetActive(false);
    }
    void SwitchPlayer2()
    {
        audioSource.PlayOneShot(switchon, 1f);
        player2Movement.enabled = false;
        player1Movement.enabled = true;
        player2Position.enabled = true;
        player1Position.enabled = false;        
        box1.SetActive(true);
        box2.SetActive(false);
        BGBlack1.SetActive(true);
        BGWhite1.SetActive(false);
        BGBlack2.SetActive(false);
        BGWhite2.SetActive(true);
        Walls1.SetActive(true);
        Walls2.SetActive(false);
        decoblack2.SetActive(true);
        decowhite2.SetActive(false);
        decoblack1.SetActive(false);
        decowhite1.SetActive(true);
        player1.sprite = normal;
        player2.sprite = phase;
        collidersBox1.SetActive(true);
        collidersBox2.SetActive(false);
        GroundWandB.SetActive(true);
        GroundBandW.SetActive(false);
        Death1.SetActive(false);
        Death2.SetActive(true);
    }
}
