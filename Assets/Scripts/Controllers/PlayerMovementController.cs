using Data.ValueObject;
using Managers;
using UnityEngine;

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

        private bool _isShooted = false;

        private bool _isNotStarted = true;

        private bool _isRight = false;
        private bool _isSlowMo = false;



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
            RotatePlayer();
            AddForceToPlayer();
        }

        

        private void RotatePlayer()
        {
            if (_isNotStarted)
            {
                return;
            }
            if (_isSlowMo)
            {
                _rig.angularVelocity = Vector3.zero;
                return;
            }

            _rig.AddRelativeTorque(new Vector3(0, 0, _data.Speed * (_isRight ? 1 : -1)),ForceMode.Impulse);
        }

        private void AddForceToPlayer()
        {
            if (!_isShooted)
            {
                return;
            }
            _isShooted = false;

            if (_isSlowMo)
            {
                return;
            }


            _rig.velocity = new Vector3(0, 0);
            if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 90)
            {
                _rig.AddForce(new Vector3(_data.ForceX, _data.ForceY, 0), ForceMode.Impulse);
            }
            else if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 180)
            {
                _rig.AddForce(new Vector3(-_data.ForceX, _data.ForceY, 0), ForceMode.Impulse);

            }
            else
            {

            }

        }


        public void OnClicked()
        {
            
        }

        public void OnShooted(int currentLoadCount, int totalAmmoCount)
        {
            _isShooted = true;
            _isRight = !_isRight;
        }

        public void OnReleased()
        {
            _isShooted = false;
        }


        public void OnPlay()
        {
            _isNotStarted = false;

        }
        public void OnLevelFailed()
        {
            
        }
        public void OnLevelSuccess()
        {
            
        }
        public void OnSlowMo(bool state)
        {
            _isSlowMo = state;
        }
        public void OnRestartLevel()
        {
            _isNotStarted = true;
            _rig.angularVelocity = Vector3.zero;
            _rig.velocity = Vector3.zero;
            //_isNotStarted = true;
            transform.position = new Vector3(_data.InitializePosX, _data.InitializePosY);
            transform.eulerAngles = Vector3.zero;
            _isSlowMo = false;
            _isRight = false;
            _isShooted = false;
        }
    }
}