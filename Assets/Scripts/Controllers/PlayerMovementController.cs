using System.Collections;
using System.Collections.Generic;
using Data.ValueObject;
using Enums;
using Managers;
using Signals;
using UnityEngine;
using DG.Tweening;
using System;

namespace Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        #endregion
        #region Private Variables
        private Rigidbody _rig;
        private PlayerManager _manager;
        private PlayerData _data;

        private bool _isClicked = false;

        private bool _isNotStarted = false;
        private bool _isGameOver = false;

        private bool _isRight = false;



        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _rig = GetComponent<Rigidbody>();
            _manager = GetComponent<PlayerManager>();
            _data = _manager.GetData();
        }


        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            if (_isNotStarted)
            {
                return;
            }
            else
            {
                //_rig.velocity = n
                _rig.angularVelocity = new Vector3(_rig.angularVelocity.x, _rig.angularVelocity.y, _data.Speed * (_isRight ? 1 : -1));
            }
        }


        public void OnClicked()
        {
            _isClicked = true;
            _isRight = !_isRight;
        }

        public void OnReleased()
        {
            _isClicked = false;
        }
        public void OnPlayPressed()
        {
            _isNotStarted = false;
        }

        public void OnPlay()
        {
            //_isNotStarted = false;

        }
        public void OnLevelFailed()
        {
            _isGameOver = true;
        }
        public void OnLevelSuccess()
        {
            _isGameOver = true;
        }
        public void OnReset()
        {
            //_isNotStarted = true;
            _isGameOver = false;
            //transform.position = new Vector3(_data.InitializePosX, _data.InitializePosY);
        }
    }
}