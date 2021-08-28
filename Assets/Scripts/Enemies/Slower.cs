using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : Enemy
{
    [SerializeField] float _slowAmount;
    [SerializeField] float _slowTime;

    protected override void PlayerImpact(Player player)
    {
        TankController controller = player.GetComponent<TankController>();
        if (controller != null)
        {
            controller.MoveSpeed -= _slowAmount;
            controller.StartCoroutine(RestoreSpeed(_slowTime, _slowAmount, controller));
        }
    }

    static IEnumerator RestoreSpeed(float time, float slowAmount, TankController controller)
    {
        yield return new WaitForSeconds(time);
        controller.MoveSpeed += slowAmount;
    }
}