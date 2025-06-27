using Fusion;
using UnityEngine;

public class RaycastAttack : NetworkBehaviour
{
    public float Damage = 1;

    public PlayerMovement PlayerMovement;

    void Update()
    {
        if (HasStateAuthority == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
                Ray ray = PlayerMovement.camera.ScreenPointToRay(Input.mousePosition);
            ray.origin += PlayerMovement.camera.transform.forward;

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f);
            }

            if (Physics.Raycast(ray.origin, ray.direction, out var hit))
            {
                if (hit.transform.TryGetComponent<Health>(out var health))
                {
                    health.DealDamageRpc(Damage,Object.InputAuthority.ToString());
                }
            }
        }
       
        

       
    }
}