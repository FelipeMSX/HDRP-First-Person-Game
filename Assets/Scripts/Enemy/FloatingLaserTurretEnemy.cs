using Assets.Scripts;
using Assets.Scripts.Enemy;
using Assets.Scripts.Enemy.Weapons;
using Assets.Scripts.Enemy.Weapons.Behaviours;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyWeaponShootable))]
[RequireComponent(typeof(EnemySingleShootBehaviour))]
[RequireComponent(typeof(IEnemyRangeFollowBehaviour))]


public class FloatingLaserTurretEnemy : Actor
{
    public TurretFloatingEnemyMode EnemyMode;


    private TurretFloatingEnemyMode _currentEnemyMode;

    private IEnemyRangeFollowBehaviour _rangeFollower;

 

    private EnemyWeaponShootable _weapon;


    private void Start()
    {
        Affiliation = 1;
        _currentEnemyMode = EnemyMode;

        _rangeFollower = GetComponent<IEnemyRangeFollowBehaviour>();
        _weapon = GetComponent<EnemyWeaponShootable>();


    }

    private void Update()
    {
        if (_currentEnemyMode != EnemyMode)
        {
            _currentEnemyMode = EnemyMode;

            switch (_currentEnemyMode)
            {
                case TurretFloatingEnemyMode.Idle:
                    Idle();
                    break;
                case TurretFloatingEnemyMode.Attack:
                    Attack();
                    break;

            }
        }
    }

    private void Idle()
    {

    }

    private void Attack()
    {

    }

    public enum TurretFloatingEnemyMode { Idle, Attack }

}

