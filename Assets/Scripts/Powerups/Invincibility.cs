using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    [SerializeField] Material invincibilityMaterial;

    List<Material> playerMaterials = new List<Material>();

    protected override void PowerUp(Player player)
    {
        player.CanTakeDamage = false;

        foreach (MeshRenderer mr in player.meshRenderers)
        {
            playerMaterials.Add(mr.material);
            mr.material = invincibilityMaterial;
        }
    }

    protected override void PowerDown(Player player)
    {
        player.CanTakeDamage = true;

        int i = 0;
        foreach (MeshRenderer mr in player.meshRenderers)
        {
            mr.material = playerMaterials[i++];
        }
    }
}
