using System.Collections.Generic;

public class EnemyPoolsHandler 
{
    private Dictionary<string, ZombiePool> pools = new Dictionary<string, ZombiePool>();

    private void AddPool(Zombie zombie)
    {
        ZombiePool pool = new ZombiePool(zombie, 3, true);
        pools.Add(zombie.gameObject.name, pool);
    }

    public Zombie GetZombie(Zombie zombie)
    {
        string name = zombie.gameObject.name;
        if (!pools.ContainsKey(name)) AddPool(zombie);
        return pools[name].GetElement();
    }
}