using System.Collections.Generic;
using UnityEngine;

namespace RunDoorsButtons.Data
{
    [CreateAssetMenu(menuName = "Data/FieldData")]
    public class FieldData : ScriptableObject
    {
        [SerializeField] private List<DoorByButtonConfig> _configs = new List<DoorByButtonConfig>();
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _distanceToButton;
        [SerializeField] private float _doorTimer;

        public List<DoorByButtonConfig> Configs => _configs;
        public float PlayerSpeed => _playerSpeed;
        public float DistanceToButton => _distanceToButton;
        public float DoorTimer => _doorTimer;
    }
}