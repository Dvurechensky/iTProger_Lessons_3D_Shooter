using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    private string remotePlayer = "RemotePlayer";
    [SerializeField]
    private Behaviour[] compometsToDisable;
    private Camera sceneCamera;

    private void Start()
    {
        if(!isLocalPlayer)
        {
            for(int i = 0; i < compometsToDisable.Length; i++)
                compometsToDisable[i].enabled = false;
            gameObject.layer = LayerMask.NameToLayer(remotePlayer);
        }
        else
        {
            sceneCamera = Camera.main;
            if(sceneCamera != null)
                sceneCamera.gameObject.SetActive(false);
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player player = GetComponent<Player>();
        GameManager.RegisterPlayer(netID, player);
    }

    private void OnDisable()
    {
        if (sceneCamera != null)
            sceneCamera?.gameObject.SetActive(true);

        GameManager.UnRegisterPlayer(transform.name);
    }
}
