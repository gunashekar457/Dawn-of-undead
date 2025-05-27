using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using code;

public class Raycast : MonoBehaviour
{
    public float damage = 10f;
    public float range = 10f;
    public Camera cam;
    private Animation shoot;
    public TMP_Text interactUI;
    public GameObject shootParticles;

    private void Start()
    {
        //shoot = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        RaycastHit hit;
  

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit,range))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward*range, Color.red);
            if (hit.collider.CompareTag("Interact"))
            {
                interactUI.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.SetActive(false);
                    GameManager.instance.Interact();
                }
            }
            else if(hit.collider.CompareTag("RadioTower"))
            {
                interactUI.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    GameManager.instance.EnableGameState(GameState.AtRadioTower);
                }
            }
            else
            {
                interactUI.gameObject.SetActive(false);
            }
        }
        else
        {
            interactUI.gameObject.SetActive(false);
        }

    }     
    void Shoot()
    {
        //shoot.Play();

        shootParticles.gameObject.SetActive(true);
        StartCoroutine(shootParticleEffect());
        RaycastHit hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit,100f))
        {
            Enemy enemy =  hit.transform.GetComponent<Enemy>();
            if(enemy!=null)
            {
                enemy.Die();
            }
        }
    }

    public IEnumerator shootParticleEffect()
    {
        yield return new WaitForSeconds(0.5f);
        shootParticles.gameObject.SetActive(false);
    }
}
