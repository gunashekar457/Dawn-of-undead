
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaypointMarker : MonoBehaviour
{
    [Header("UI Related")]
    public Image[] waypointImgs;
    public TMP_Text[] distanceTxt;

    [Header("Transform Related")]
    public GameObject player;
    public Transform[] RadioParts;

    private Vector3 offset;
    void Start()
    {
        offset = new Vector3(0, 2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < RadioParts.Length; i++)
        {
            float minX = waypointImgs[i].GetPixelAdjustedRect().width / 2;
            float maxX = Screen.width - minX;

            float minY = waypointImgs[i].GetPixelAdjustedRect().height / 2;
            float maxY = Screen.height - minY;

            Vector2 pos = Camera.main.WorldToScreenPoint(RadioParts[i].position + offset);

            if (Vector3.Dot((RadioParts[i].position - transform.position), transform.forward) < 0)
            {
                if (pos.x < Screen.width / 2)
                {
                    pos.x = maxX;
                }
                else
                {
                    pos.x = minX;
                }
            }

            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            waypointImgs[i].transform.position = pos;

            distanceTxt[i].text = Mathf.Round(Vector3.Distance(player.transform.position, RadioParts[i].position)).ToString() + " m";

            if (!GameManager.instance.radios[0].activeInHierarchy)
            {
                waypointImgs[0].gameObject.SetActive(false);
            }
            else if (GameManager.instance.radios[0].activeInHierarchy)
            {
                waypointImgs[0].gameObject.SetActive(true);
            }
            if (!GameManager.instance.radios[1].activeInHierarchy)
            {
                waypointImgs[1].gameObject.SetActive(false);
            }
            else if (GameManager.instance.radios[1].activeInHierarchy)
            {
                waypointImgs[1].gameObject.SetActive(true);
            }
            if (!GameManager.instance.radios[2].activeInHierarchy)
            {
                waypointImgs[2].gameObject.SetActive(false);
            }
            else if (GameManager.instance.radios[2].activeInHierarchy)
            {
                waypointImgs[2].gameObject.SetActive(true);
            }
            if (!GameManager.instance.radios[3].activeInHierarchy)
            {
                waypointImgs[3].gameObject.SetActive(false);
            }
            else if (GameManager.instance.radios[3].activeInHierarchy)
            {
                waypointImgs[3].gameObject.SetActive(true);
            }
            if (!GameManager.instance.radios[4].activeInHierarchy)
            {
                waypointImgs[4].gameObject.SetActive(false);
            }
            else if (GameManager.instance.radios[4].activeInHierarchy)
            {
                waypointImgs[4].gameObject.SetActive(true);
            }
            if (!GameManager.instance.radios[5].activeInHierarchy)
            {
                waypointImgs[5].gameObject.SetActive(false);
            }
            else if (GameManager.instance.radios[5].activeInHierarchy)
            {
                waypointImgs[5].gameObject.SetActive(true);
            }
        }
      }
    }
