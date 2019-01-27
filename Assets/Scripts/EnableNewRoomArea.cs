using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNewRoomArea : MonoBehaviour
{

    private static int winGameRoomCount = 8;
    private static int curerntGameWinRoomCount = 0;


    [SerializeField]
    private List<GameObject> myRoomEnabler = new List<GameObject>();
    [SerializeField]
    private GameObject[] myRoomToEnable;

    private int roomItemCount;
    private int maxRoomItems;

    [SerializeField]
    private Material[] materials;
    [SerializeField]
    private MeshRenderer meshRenderer;

    [SerializeField]
    private Material defaultProtypeMaterial;
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
        meshRenderer.materials = materials;
        //for (int i = 0; i < materials.Length; i++) {
        //    meshRenderer.materials[i] = materials[i];
        //    print("Room completed" + meshRenderer.materials[i] + " " + materials[i]);
        //}
        //print("Room completed");
        curerntGameWinRoomCount++;
        if (curerntGameWinRoomCount >= winGameRoomCount) {
            PlayerController.WinGAme();
        }
    }
    public void RoomDisable()
    {
        foreach (GameObject roomObject in myRoomToEnable)
        {
            roomObject.SetActive(false);
        }

        Material[] tempArray = new Material[meshRenderer.materials.Length];
        for (int i = 0; i < tempArray.Length; i++)
        {
            tempArray[i] = defaultProtypeMaterial;
        }
        meshRenderer.materials = tempArray;

        curerntGameWinRoomCount--;

    }
}
