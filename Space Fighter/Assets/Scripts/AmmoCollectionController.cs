using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollectionController : MonoBehaviour
{
    public GameObject ammoParent;

    private IEnumerator Start()
    {
        ammoParent = GameObject.FindGameObjectWithTag("Ammo Parent");
        this.transform.parent = this.ammoParent.transform;

        yield return new WaitForSeconds(2f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled =true;
        yield return new WaitForSeconds(2f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.25f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.25f);
        Destroy(this.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerShootingController>().ammoLeft++;
            collision.gameObject.GetComponent<PlayerShootingController>().ammoLeftText.text = collision.gameObject.GetComponent<PlayerShootingController>().ammoLeft.ToString();
            Destroy(this.gameObject);
        }
    }
}
