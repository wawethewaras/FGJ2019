using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNewRoomArea : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> myRoomEnabler = new List<GameObject>();
    [SerializeField]
    private GameObject[] myRoomToEnable;

    private int roomItemCount;
    private int maxRoomItems;

    private void Start()
    {
        maxRoomItems = myRoomEnabler.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < myRoomEnabler.Count; i++) {
            if (myRoomEnabler[i] == other.gameObject) {
                roomItemCount++;
                if (roomItemCount == maxRoomItems) {
                    RoomEnabled();
                }
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < myRoomEnabler.Count; i++)
        {
            if (myRoomEnabler[i] == other.gameObject)
            {
                roomItemCount--;
                if (roomItemCount < maxRoomItems) {
                    RoomDisable();
                }
            }
        }

    }

    public void RoomEnabled() {
        foreach (GameObject roomObject in myRoomToEnable) {
            roomObject.SetActive(true);
        }
    }
    public void RoomDisable()
    {
        foreach (GameObject roomObject in myRoomToEnable)
        {
            roomObject.SetActive(false);
        }
    }
}
