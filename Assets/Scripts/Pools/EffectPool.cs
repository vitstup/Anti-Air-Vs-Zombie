public class EffectPool : MonoPool<Effect>
{
    public EffectPool(Effect prefab, int count, bool isAutoExpanded) : base(prefab, count, isAutoExpanded)
    {

    }
}