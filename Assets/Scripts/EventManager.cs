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

    [Header("Ghosts")]

    [SerializeField]
    private Transform _ghostSpawnPosition;
    [SerializeField]
    private GameObject[] _ghostPrafabs;

    [SerializeField]
    private int numberOfGhosts;
    private GameObject[] _ghostsOnTheScene;




    // Start is called before the first frame update
    private void Start()
    {
        _ghostsOnTheScene = new GameObject[numberOfGhosts];
        Instantiate();
    }

    private void Update()
    {
        CheckIfNight();
        GhostsOnOff();
    }

    private void Instantiate()
    {
        //TOOL

        GameObject pickupObjectInstance = Instantiate(_pickUpObjectPrefabs[0], _toolSpawnPosition.position, Quaternion.identity);// instantiate tool on the scene

        PickupObject pickupObjectScript = pickupObjectInstance.GetComponent<PickupObject>();//take refference too its script

        pickupObjectScript.SetPlayer(_player.transform, _playerHand.transform);//Set player and player s hand transform

        //GHOST

        _ghostsOnTheScene[0] = Instantiate(_ghostPrafabs[0],_ghostSpawnPosition.position, Quaternion.identity);// instantiate ghost on the scene

    }

    private bool CheckIfNight()
    {
        if (Clock.Instance != null)
        {
            return Clock.Instance.IsDay;
        }
        else 
        {
            throw new System.Exception("Clock instance is null!");
        }
    }

    private void GhostsOnOff()
    {
        if (CheckIfNight())
        {
            for (int i = 0; i < _ghostsOnTheScene.Length; i++)
            {
                _ghostsOnTheScene[i].gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < _ghostsOnTheScene.Length; i++)
            {
                _ghostsOnTheScene[i].gameObject.SetActive(true);
            }
        }
    }

}
