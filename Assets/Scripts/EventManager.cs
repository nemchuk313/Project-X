using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [Header("PLAYER")]

    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _playerHand;

    [Header("TOOLS")]

    [SerializeField]
    private Transform _toolSpawnPosition;
    [SerializeField]
    private GameObject[] _pickUpObjectPrefabs;

   



    // Start is called before the first frame update
    private void Start()
    {
        GameObject pickupObjectInstance = Instantiate(_pickUpObjectPrefabs[0], _toolSpawnPosition.position, Quaternion.identity);// instantiate tool on the scene

        PickupObject pickupObjectScript = pickupObjectInstance.GetComponent<PickupObject>();//take refference too its script

        pickupObjectScript.SetPlayer(_player.transform,_playerHand.transform);//Set player and player s hand transform
    }

    private void Update()
    {
        
    }
}
