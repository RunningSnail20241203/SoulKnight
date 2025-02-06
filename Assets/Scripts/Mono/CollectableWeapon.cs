using System;
using Character;
using Factory;
using UnityEngine;

namespace Mono
{
    public class CollectableWeapon : MonoBehaviour
    {
        private const string PlayerTag = "Player";
        private bool _isPlayerEnter;
        private IPlayer _player;

        private void Update()
        {
            if (_isPlayerEnter)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (Enum.TryParse(name, out PlayerWeaponType playerWeaponType))
                    {
                        _player.AddWeapon(playerWeaponType);
                        Destroy(gameObject);
                    }
                    else
                    {
                        Debug.LogError($"Weapon name error:{name}");
                    }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(PlayerTag))
            {
                Debug.Log("Player enter");
                _isPlayerEnter = true;
                _player = other.GetComponent<PlayerRef>().Player;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(PlayerTag))
            {
                Debug.Log("Player exit");
                _isPlayerEnter = false;
            }
        }
    }
}