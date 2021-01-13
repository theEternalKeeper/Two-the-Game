using BBUnity.Actions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSetupScript : MonoBehaviour
{
    private List<PlayerConfig> playerConfigs;

    [SerializeField]
    private int maxPlayers = 4;

    public static PlayerSetupScript instance {get; private set ;}

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("SINGLETON - Trying to make another Instance!");
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
            playerConfigs = new List<PlayerConfig>();
        }
    }

    public void SetPlayerLoadout (int index, GameObject weapon1, GameObject weapon2)
    {
        playerConfigs[index].selectedWeapon_1 = weapon1;
        playerConfigs[index].selectedWeapon_2 = weapon2;
    }

    public void ReadyPlayer(int index)
    {
        playerConfigs[index].isReady = true;
        if (playerConfigs.All(p => p.isReady == true))
        {

        }
    }

    public void HandlePlayerJoin(PlayerInput playerInput)
    {
        Debug.Log("Player " + playerInput.playerIndex + "joined");
        playerInput.transform.SetParent(transform);
        if (!playerConfigs.Any(p => p.playerIndex == playerInput.playerIndex))
        {
            playerConfigs.Add(new PlayerConfig(playerInput));
        }

    }
}
public class PlayerConfig
{
    public PlayerConfig(PlayerInput Input)
    {
        playerIndex = Input.playerIndex;
        playerInput = Input;
    }
    public PlayerInput playerInput { get; set;}

    public int playerIndex { get; set;}

    public bool isReady { get; set; }

    public GameObject selectedWeapon_1 { get; set; }

    public GameObject selectedWeapon_2 { get; set; }
}
