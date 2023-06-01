using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Tooltip("Furthest distance bullet will look for target")]
    public float maxDistance = 1000000;
    RaycastHit hit;
    public GameObject decalHitWall;
    public GameObject bloodEffect;
	public GameObject woodEffect;
    public GameObject BarrelEffect;
	public GameObject stoneEffect;
	public GameObject metalEffect;
    public LayerMask ignoreLayer;

    /*
    * Upon bullet creation with this script attached,
    * the bullet creates a raycast which searches for colliders with corresponding materials.
    * If the raycast hits something with a matching material, it will create the corresponding effect.
    */
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, ~ignoreLayer))
        {
            ObjectHealth objectHealth = hit.collider.GetComponent<ObjectHealth>();

            if (objectHealth != null)
            {
                MaterialType materialType = objectHealth.materialType;

                switch (materialType)
                {
                    case MaterialType.Wood:
                        SpawnDecal(hit, woodEffect);
                        break;
                    case MaterialType.Metal:
                        SpawnDecal(hit, metalEffect);
                        break;
                    case MaterialType.Barrel:
                        SpawnDecal(hit, BarrelEffect);
                        break;
                    case MaterialType.Skin:
                        SpawnDecal(hit, bloodEffect);
                        break;
                    case MaterialType.Stone:
                        SpawnDecal(hit, stoneEffect);
                        break;
					case MaterialType.Wall:
                        SpawnDecal(hit, decalHitWall);
                        break;
                    default:
                        break;
                }
            }

            Destroy(gameObject);
        }

        Destroy(gameObject, 0.1f);
    }

    void SpawnDecal(RaycastHit hit, GameObject prefab)
    {
        GameObject spawnedDecal = Instantiate(prefab, hit.point + hit.normal * 0.01f, Quaternion.LookRotation(hit.normal));
        spawnedDecal.transform.SetParent(hit.collider.transform);
    }
}