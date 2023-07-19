public class BulletPool : MonoPool<Bullet>
{
    public BulletPool(Bullet prefab, int count, bool isAutoExpanded) : base(prefab, count, isAutoExpanded)
    {

    }
}