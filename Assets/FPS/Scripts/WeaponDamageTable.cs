
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamageTable : MonoBehaviour
{
    public Dictionary<WeaponType, Dictionary<MaterialType, int>> damageTable = new Dictionary<WeaponType, Dictionary<MaterialType, int>>();

    private void Start()
    {
        // Przykładowe wartości obrażeń dla każdej kombinacji broni i materiałów
        // Klucz słownika to rodzaj broni, a drugi słownik zawiera wartości dla każdego rodzaju materiału
        damageTable[WeaponType.Semi] = new Dictionary<MaterialType, int>
        {
            { MaterialType.Wood, 5 },
            { MaterialType.Metal, 5 },
            { MaterialType.Barrel, 8 },
            { MaterialType.Skin, 10 },
            { MaterialType.Stone, 10 }
        };

        damageTable[WeaponType.Auto] = new Dictionary<MaterialType, int>
        {
            { MaterialType.Wood, 3 },
            { MaterialType.Metal, 3 },
            { MaterialType.Barrel, 4 },
            { MaterialType.Skin, 6 },
            { MaterialType.Stone, 4 }
        };

         damageTable[WeaponType.Laser] = new Dictionary<MaterialType, int>
        {
            { MaterialType.Wood, 99 },
            { MaterialType.Metal, 99 },
            { MaterialType.Barrel, 33 },
            { MaterialType.Skin, 99 },
            { MaterialType.Stone, 33 }
        };
    }

    public int GetDamage(WeaponType weaponType, MaterialType materialType)
    {
        if (damageTable.ContainsKey(weaponType) && damageTable[weaponType].ContainsKey(materialType))
        {
            return damageTable[weaponType][materialType];
        }

        return 0;
    }
}
