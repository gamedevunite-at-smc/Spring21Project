using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BulletSystem : MonoBehaviour
{

    private new Transform transform;
    private new ParticleSystem particleSystem;

    public enum TeamEnum { Player, Enemy }

    [SerializeField] private TeamEnum _teamEnum;
    public TeamEnum teamEnum
    {
        get
        {
            return _teamEnum;
        }
        set
        {
            if (_teamEnum == value)
                return;

            var mainModule = particleSystem.main;
            var collisionModule = particleSystem.collision;

            switch (teamEnum)
            {
                case TeamEnum.Player:
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                    mainModule.startRotation = 0;
                    collisionModule.collidesWith = LayerMask.GetMask("Enemy");
                    break;
                case TeamEnum.Enemy:
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    mainModule.startRotation = Mathf.Deg2Rad * 180;
                    collisionModule.collidesWith = LayerMask.GetMask("Player");
                    break;
                default:
                    break;
            }
        }
    }

    [SerializeField] private BulletSystemData bulletSystemData;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
        transform = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        particleSystem.Stop();
        teamEnum = _teamEnum;
    }

    public void StartShooting()
    {
        particleSystem.Play();
    }

    public void StopShooting()
    {
        particleSystem.Stop();
    }

    private void SetData()
    {
        if (bulletSystemData == null)
        {
            Debug.LogError("Bullet System data is not set.", this);
            return;
        }

        if (particleSystem == null)
            particleSystem = GetComponent<ParticleSystem>();

        if (transform == null)
            transform = GetComponent<Transform>();

        var mainModule = particleSystem.main;
        var emissionModule = particleSystem.emission;

        var collisionModule = particleSystem.collision;

        switch (_teamEnum)
        {
            case TeamEnum.Player:
                transform.rotation = Quaternion.Euler(0, 0, -90);
                mainModule.startRotation = 0;
                collisionModule.collidesWith = LayerMask.GetMask("Enemy");
                break;
            case TeamEnum.Enemy:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                mainModule.startRotation = Mathf.Deg2Rad * 180;
                collisionModule.collidesWith = LayerMask.GetMask("Player");
                break;
            default:
                break;
        }

        emissionModule.rateOverTime = bulletSystemData.particlesPerSecond;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {

        SetData();

    }
#endif
}
