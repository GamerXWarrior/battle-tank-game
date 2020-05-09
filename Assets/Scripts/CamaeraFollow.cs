using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Tank;
using TankGame.Event;

public class CamaeraFollow : MonoBehaviour
{
    private TankView player;
    private Vector3 posDifference;
    private Vector3 initPos;
    private Quaternion initRot;

    void Start()
    {
        initPos = transform.position;
        initRot = transform.rotation;
        EventService.Instance.PlayerSpawn += OnPlayerSpawned;
        EventService.Instance.PlayerDeath += OnPLayerDied;
    }

    private void OnPlayerSpawned()
    {
        player = TankService.Instance.GetCurrentPlayer();
        if (player != null)
        {
            //player = TankService.Instance.GetCurrentPlayer();
            transform.parent = player.transform;
            transform.position = player.transform.position + new Vector3(0, 3.18f, -3.04f) ;
            transform.eulerAngles = new Vector3(22.03f, 1.81f, 0);
        }
        else
        {
            Debug.Log("player is null");
        }
    }

    private void OnPLayerDied(int playerNUmber)
    {
        transform.parent = null;
        transform.SetPositionAndRotation(initPos, initRot);
    }

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        if(player != null)
        {
            //posDifference = playerTarget.transform.position - transform.position;
            //transform.position = player.transform.position + new Vector3(0,2f,2f) ;
        }
    }

    //public void setTarget(Transform target)
    //{
    //    playerTarget = target;
    //    posDifference = playerTarget.transform.position - transform.position;
    //}
}
