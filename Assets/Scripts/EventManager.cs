using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public  GameObject player;
    public GameObject playerHand;
    public GameObject pickupObjectPrefab;
    private Vector3 position = new Vector3(0.770924568f,0.66500001f,4.64699984f);

    // Start is called before the first frame update
    void Start()
    {
        GameObject pickupObjectInstance = Instantiate(pickupObjectPrefab, position, Quaternion.identity);

        PickupObject pickupObjectScript = pickupObjectInstance.GetComponent<PickupObject>();

        pickupObjectScript.SetPlayer(player.transform,playerHand.transform);
    }

    
}
