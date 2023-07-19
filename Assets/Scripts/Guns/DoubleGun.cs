using UnityEngine;

public class DoubleGun : AbstractGun
{
    [SerializeField] private ShootPoint shootPointOne;
    [SerializeField] private ShootPoint shootPointTwo;

    [SerializeField] private Effect effectPrefab;

    [Header("Recoil")]
    [SerializeField] private bool haveRecoil;
    [SerializeField, Range(0, 0.001f)] private float recoilOfset;
    [SerializeField] private Transform cannonTransformOne;
    [SerializeField] private Transform cannonTransformTwo;

    [Header("Audio")]
    [SerializeField] private bool haveAudio;
    [SerializeField] private AudioSource audioSource;

    // hiden
    private int currentGun;

    private EffectPool effectPool;

    private Vector3 cannonBasePositionOne;
    private Vector3 cannonBasePositionTwo;

    protected override void Start()
    {
        base.Start();
        effectPool = new EffectPool(effectPrefab, 3, true);

        cannonBasePositionOne = cannonTransformOne.localPosition;
        cannonBasePositionTwo = cannonTransformTwo.localPosition;
    }

    protected override void Shoot()
    {
        var bullet = bulletPool.GetElement();
        bullet.Shooted(GetCurrentShootPoint().transform, additionalDamage);

        var effect = effectPool.GetElement();
        effect.transform.position = GetCurrentShootPoint().transform.position;
        effect.Play();

        if (haveRecoil) DoRecoil();
        if (haveAudio) DoAudio();

        ChangeShootPoint();
    }

    private ShootPoint GetCurrentShootPoint()
    {
        if (currentGun == 0) return shootPointOne;
        else return shootPointTwo;
    }

    private void ChangeShootPoint()
    {
        if (currentGun == 0) currentGun = 1;
        else currentGun = 0;
    }

    private void DoRecoil()
    {
        if (currentGun == 0)
        {
            cannonTransformOne.transform.localPosition += new Vector3(recoilOfset, 0f, 0f);
            cannonTransformTwo.transform.localPosition = cannonBasePositionTwo;
        }
        else
        {
            cannonTransformTwo.transform.localPosition += new Vector3(recoilOfset, 0f, 0f);
            cannonTransformOne.transform.localPosition = cannonBasePositionOne;
        }
    }

    private void DoAudio()
    {
        audioSource.Play();
    }
}