using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerShootingController : MonoBehaviour
{
    public GameObject bullets;
    public GameObject bullet;
    public Transform shootPoint;
    public float shootingFrequency;
    public float bulletSpeed;
    public int ammoLeft;
    public TextMeshProUGUI ammoLeftText;
    public GameObject laser;
    public AudioSource nukeSound;
    public AudioSource shotAudio;

    private Transform enemies;
    private float timer = 0f;
    private GameObject shot;
    private PlayerMovementController playerMovementController;
    private int nukesAvailable = 5;

    private void Start()
    {
        shotAudio = GetComponent<AudioSource>();
        playerMovementController = GetComponent<PlayerMovementController>();
        enemies = GameObject.FindGameObjectWithTag("Enemies").transform;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.N) && nukesAvailable > 0)
        {
            NukemAll();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !laser.activeSelf)
        {
            if (timer > shootingFrequency && ammoLeft > 0)
            {
                shotAudio.Play();
                shot = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                shot.GetComponent<Rigidbody2D>().AddForce(this.transform.up * bulletSpeed * 2000f);
                shot.transform.parent = this.bullets.transform;
                timer = 0;
                ammoLeft--;
                ammoLeftText.text = ammoLeft.ToString();
            }
        }
    }

    private void NukemAll()
    {
        nukeSound.Play();
        foreach (Transform child in enemies)
        {
            Destroy(child.gameObject);
        }
        GameObject.FindGameObjectWithTag("N" + nukesAvailable.ToString()).SetActive(false);
        nukesAvailable--;
    }
}
