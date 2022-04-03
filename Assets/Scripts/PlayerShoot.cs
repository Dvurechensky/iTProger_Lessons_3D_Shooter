using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : MonoBehaviour
{
    public Weapon weapon;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask mask;

    private void Start()
    {
        if (cam == null)
        {
            Debug.LogError("No Camera");
            this.enabled = false;
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
            if (_hit.collider.tag == "Player")
                CmdPlayerShoot(_hit.collider.name, weapon.damage);
        }
    }

    [Command]
    private void CmdPlayerShoot(string _ID, float _DAMAGE)
    {
        Debug.Log(_ID + " Damages");

        Player player = GameManager.GetPlayer(_ID);
        player.TakeDamage(_DAMAGE);
    }


}
