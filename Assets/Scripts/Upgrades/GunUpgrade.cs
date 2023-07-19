public abstract class GunUpgrade : Upgrade
{
    protected AbstractGun gun;

    public GunUpgrade(AbstractGun gun)
    {
        SetGun(gun);
    }
    
    public void SetGun(AbstractGun gun)
    {
        this.gun = gun;
    }
}