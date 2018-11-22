﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : Action {

    public override void Act(StateController controller)
    {
        Attack(controller);
    }

    private void Attack(StateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.attackRange, Color.red);

        if (Physics.SphereCast(controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.forward, out hit, controller.enemyStats.attackRange) && hit.collider.CompareTag("Player"))
        {
            controller.turret.LookAt(new Vector3(controller.chaseTarget.position.x, controller.turret.position.y, controller.chaseTarget.position.z));
            if (controller.CheckIfCountDownElapsed(controller.enemyStats.attackRate))
            {
                controller.gunTankShooting.Fire();
            }
        }
    }
}