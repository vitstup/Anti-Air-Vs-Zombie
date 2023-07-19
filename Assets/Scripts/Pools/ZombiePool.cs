public class ZombiePool : MonoPool<Zombie>
{
    public ZombiePool(Zombie prefab, int count, bool isAutoExpanded) : base(prefab, count, isAutoExpanded)
    {

    }
}