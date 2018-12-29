﻿/*************************************************************************
 *  Copyright © 2015-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Mechanism.cs
 *  Description  :  Define abstract mechanism.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/25/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.Machinery
{
    /// <summary>
    /// Base mechanism.
    /// </summary>
    public abstract class Mechanism : MonoBehaviour, IMechanism
    {
        public Vector3 _Myv3;
        public Vector3 _myscale;
        public Vector3 _myrotation;
        public Transform tr;
        public bool IsReSetTr = false;
        [Header("开始调试")]
        public bool IsStart = false;
        void OnValidate()
        {
            // print("1111");
            if (IsReSetTr && tr)
            {
                _Myv3 = tr.localPosition;
                _myscale = tr.localScale;
                _myrotation = tr.localEulerAngles;
                IsReSetTr = false;
            }
            if (tr && IsStart)
            {
                tr.localPosition = _Myv3;
                tr.localEulerAngles = _myrotation;
                tr.localScale = _myscale;
            }
        }
        #region Protected Method
        protected virtual void Awake()
        {
            Initialize();
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize mechanism.
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Drive mechanism by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of drive.</param>
        /// <param name="type">Type of drive.</param>
        public abstract void Drive(float velocity, DriveType type);
        #endregion
    }

    /// <summary>
    /// Trigger for mechanism.
    /// </summary>
    public abstract class TriggerMechanism : Mechanism, ITriggerMechanism
    {
        #region Field and Property
        /// <summary>
        /// Trigger is triggered?
        /// </summary>
        public abstract bool IsTriggered { get; }
        #endregion

        #region Public Method
        /// <summary>
        /// Drive trigger by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of drive.</param>
        /// <param name="type">Type of drive.</param>
        public override void Drive(float velocity = 0, DriveType type = DriveType.Ignore) { }
        #endregion
    }
}