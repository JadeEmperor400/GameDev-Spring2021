using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] deadends;
    public GameObject[] itemRooms;
    public GameObject[] bossRooms;
    public GameObject[] closers;
    public GameObject[] openers;
    public GameObject closedWall;
    public List<GameObject> rooms;

    public const int MAX_ROOMS = 15;
    public const int MIN_ROOMS = 15;
    public int tblr_limit;
    public bool stopGenerating;
    public bool minReached;
    public bool itemRoomCreated;
    public bool bossRoomCreated;
    // Start is called before the first frame update
    void Start()
    {
        //Test
        stopGenerating = false;
        minReached = false;
        itemRoomCreated = false;
        bossRoomCreated = false;

        setClosers(false);
        setOpeners(true);
        

    }

    // Update is called once per frame
    void Update()
    {
        //if(tblr_limit <= 0)
        //{
        //    openers[0].GetComponent<AddRoom>().setAllowed(false);
        //}

        if (rooms.Count >= MIN_ROOMS)
        {
            minReached = true;
            setClosers(true);
            setOpeners(false);
        }

        if(rooms.Count >= MAX_ROOMS)
        {
            stopGenerating = true;
        }
    }

    public bool generationStopped()
    {
        return stopGenerating;
    }

    void setClosers(bool allow)
    {
        for(int i = 0; i < closers.Length; i++)
        {
            closers[i].GetComponent<AddRoom>().setAllowed(allow);
            
        }
    }

    void setOpeners(bool allow)
    {
        for (int i = 0; i < openers.Length; i++)
        {
            openers[i].GetComponent<AddRoom>().setAllowed(allow);

        }
    }

    public int getLimit()
    {
        return tblr_limit;
    }

    public void decrementLimit()
    {
        tblr_limit--;
    }

    public bool getItemSpawned()
    {
        return itemRoomCreated;
    }

    public void setItemSpawned(bool spawned)
    {
        itemRoomCreated = spawned;
    }

    public bool getBossSpawned()
    {
        return bossRoomCreated;
    }

    public void setBossSpawned(bool spawned)
    {
        bossRoomCreated = spawned;
    }
}
