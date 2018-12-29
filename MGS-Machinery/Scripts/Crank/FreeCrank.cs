﻿  /*************************************************************************
 *  Copyright © 2015-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FreeCrank.cs
 *  Description  :  Define FreeCrank component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/17/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.Machinery
{
    /// <summary>
    /// Crank free rotate around the axis Z.
    /// </summary>
    [AddComponentMenu("Mogoson/Machinery/FreeCrank")]
    public class FreeCrank : CrankMechanism
    {
       
        #region Protected Method
        /// <summary>
        /// Rotate crank by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of drive.</param>
        /// <param name="type">Type of drive.</param>
        protected override void DriveCrank(float velocity, DriveType type = DriveType.Ignore)
        {
            triggerRecord = Angle;
            Angle += velocity * Time.deltaTime;
            DriveCrank();

            if (CheckTriggers())
            {
                Angle = triggerRecord;
                DriveCrank();
            }
        }

        /// <summary>
        /// Rotate crank.
        /// </summary>
        protected void DriveCrank()
        {
            transform.localRotation = Quaternion.Euler(StartAngles + new Vector3(0, 0, Angle));
            DriveRockers();
        }
        #endregion

       


    }
}