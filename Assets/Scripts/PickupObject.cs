using UnityEngine;
using UnityEngine.InputSystem;

public class PickupObject : MonoBehaviour
{
    public Transform player;
    public Transform hand;
    public float pickupDistance = 2f;

    bool carrying;
    GameObject carriedObject;

    void Update()
    {
        if (carrying)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                DropObject();
            }
        }
        else
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                CheckForPickup();
            }
        }
    }

    void CheckForPickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(player.position, player.forward, out hit, pickupDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                PickUpObject();
            }
        }
    }

    void PickUpObject()
    {
        carrying = true;
        carriedObject = gameObject;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.transform.position = hand.position;
        gameObject.transform.parent = hand;
    }

    void DropObject()
    {
        carrying = false;
        carriedObject = null;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.transform.parent = null;
    }
}