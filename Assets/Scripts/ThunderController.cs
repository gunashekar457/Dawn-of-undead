using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class ThunderController : MonoBehaviour
{
    public List<Thunders> thunders;
    public ThunderID thunderID;


    public GameObject thunderObject;
    public GameObject startObject;
    public GameObject endObject;
    public GameObject endRef;
    public float travelSpeed;
    public int number;

    public List<GameObject> newThunders;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenrateThunder", 5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //{

        //    GenrateThunder();
        //}
        //SetThunder(thunderID);
    }
    IEnumerator DisableGameObject(float time, GameObject thunderObject)
    {
        yield return new WaitForSeconds(time);
        thunderObject.SetActive(false);
    }
    public void GenrateThunder()
    {

        GameObject randomThunder = newThunders[Random.Range(0, newThunders.Count)];
        randomThunder.SetActive(true);
        StartCoroutine(DisableGameObject(5, randomThunder));


        //List<ThunderID> numberOfThunders = new List<ThunderID>() { ThunderID.Thunder1, ThunderID.Thunder2, ThunderID.Thunder3 };
        //ThunderID randomThunder = numberOfThunders[Random.Range(0, numberOfThunders.Count)];
        //number = (int)randomThunder;
        //thunderID = randomThunder;
        //thunderObject = thunders[(int)randomThunder - 1].thunderObject;
        //startObject = thunders[(int)randomThunder-1 ].startObject;
        //endObject = thunders[(int)randomThunder -1].endObject;
        //endRef = thunders[(int)randomThunder-1 ].endRef;
        //travelSpeed = thunders[(int)randomThunder - 1].travelSpeed;
        //thunderID = randomThunder;

    }
    void SetThunder(ThunderID thunderID)
    {
        switch (thunderID)
        {
            case ThunderID.Thunder1:
                thunderObject.SetActive(true);
                endObject.transform.position = Vector3.MoveTowards(endObject.transform.position, endRef.transform.position, Time.deltaTime* travelSpeed) ;
                break;
            case ThunderID.Thunder2:
                thunderObject.SetActive(true);
                endObject.transform.position = Vector3.MoveTowards(endObject.transform.position, endRef.transform.position,Time.deltaTime*travelSpeed);
                break; 
            case ThunderID.Thunder3:
                thunderObject.SetActive(true);
                endObject.transform.position = Vector3.MoveTowards(endObject.transform.position, endRef.transform.position , Time.deltaTime* travelSpeed);
                break;

        }
    }
}
[Serializable]
public class Thunders
{
    public GameObject thunderObject;
    public GameObject startObject;
    public GameObject endObject;
    public GameObject endRef;
    public float travelSpeed;
}
public enum ThunderID
{
    None,
    Thunder1,
    Thunder2,
    Thunder3,
}
