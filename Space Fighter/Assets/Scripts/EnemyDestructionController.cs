using UnityEngine;

public class EnemyDestructionController : MonoBehaviour
{
    public GameObject ammo;

    private AudioSource enemyDestructionAudio;
    private ScoreManager scoreManager;
    private GameObject scoreUI;

    private void Start()
    {
        enemyDestructionAudio = GetComponent<AudioSource>();
        scoreUI = GameObject.FindGameObjectWithTag("ScoreUI");
        scoreManager = scoreUI.GetComponent<ScoreManager>();
        Destroy(this.gameObject, 8f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy 1")
        {
            enemyDestructionAudio.Play();
            Instantiate(ammo, collision.transform.position, Quaternion.identity);
            scoreManager.DisplayScoreText(5);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy 2")
        {
            enemyDestructionAudio.Play();
            Instantiate(ammo, collision.transform.position, Quaternion.identity);
            scoreManager.DisplayScoreText(5);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy 3")
        {
            enemyDestructionAudio.Play();
            Instantiate(ammo, collision.transform.position, Quaternion.identity);
            scoreManager.DisplayScoreText(10);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
