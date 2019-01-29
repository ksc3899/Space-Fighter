using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthController : MonoBehaviour
{
    public int maximumHealth;
    public Slider healthSlider;
    public GameOverController gameOverController;

    private float timer = 0f;
    private int currenthealth;
    private bool isShieldEnabled = false;
    private int shieldsAvailable = 5;

    private void Start()
    {
        currenthealth = maximumHealth;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) && shieldsAvailable > 0)
        {
            StartCoroutine(ShieldController());
        }

        if(currenthealth <= 0f)
        {
            gameOverController.GameOver();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (timer > 0.5f && isShieldEnabled == false)
        {
            if (collision.gameObject.tag == "Enemy 1" || collision.gameObject.tag == "Enemy 2")
            {
                currenthealth -= 10;
                healthSlider.value = currenthealth;
                StartCoroutine(BlinkShip());
            }
            else if (collision.gameObject.tag == "Enemy 3")
            {
                currenthealth -= 20;
                healthSlider.value = currenthealth;
                StartCoroutine(BlinkShip());
            }
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    IEnumerator ShieldController()
    {
        isShieldEnabled = true;

        Image shieldIcon = GameObject.FindGameObjectWithTag("S" + shieldsAvailable.ToString()).GetComponent<Image>();
        shieldIcon.enabled = false;
        yield return new WaitForSeconds(1.75f);
        shieldIcon.enabled = true;
        yield return new WaitForSeconds(1.75f);
        shieldIcon.enabled = false;
        yield return new WaitForSeconds(1.5f);
        shieldIcon.enabled = true;
        yield return new WaitForSeconds(1.5f);
        shieldIcon.enabled = false;
        yield return new WaitForSeconds(1);
        shieldIcon.enabled = true;
        yield return new WaitForSeconds(1);
        shieldIcon.enabled = false;
        yield return new WaitForSeconds(0.5f);
        shieldIcon.enabled = true;
        yield return new WaitForSeconds(0.5f);
        shieldIcon.enabled = false;

        shieldsAvailable--;
        isShieldEnabled = false;
    }

    IEnumerator BlinkShip()
    {
        SpriteRenderer ship = GetComponentInChildren<SpriteRenderer>();
        for (int i = 0; i < 6; i++)
        {
            ship.enabled = !ship.enabled;
            yield return new WaitForSeconds(0.15f);
        }
    }
}
