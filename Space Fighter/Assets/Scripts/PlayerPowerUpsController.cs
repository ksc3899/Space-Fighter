using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpsController : MonoBehaviour
{
    public GameObject laser;
    public GameObject berserk;

    private IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Laser" &&  !laser.activeSelf && !berserk.activeSelf)
        {
            Destroy(collision.gameObject);
            laser.SetActive(true);
            yield return new WaitForSeconds(7f);
            laser.SetActive(false);
        }
        else if(collision.gameObject.tag == "Berserk" && !laser.activeSelf && !berserk.activeSelf)
        {
            Destroy(collision.gameObject);
            berserk.SetActive(true);
            yield return new WaitForSeconds(7f);
            berserk.SetActive(false);
        }
    }
}
