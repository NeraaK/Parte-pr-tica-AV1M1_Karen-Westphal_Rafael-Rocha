using UnityEngine;

public abstract class BossBase
{      
     public abstract void Enter(BossST boss);
     public abstract void Execute(BossST boss);
     public abstract void Exit(BossST boss);
    
}
