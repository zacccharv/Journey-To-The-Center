using UnityEngine;

[RequireComponent(typeof(Drill))]
[RequireComponent(typeof(MinerManager))]
public class DrillData : MonoBehaviour
{
    public static DrillData instance;
    [HideInInspector] public Drill drill;
    [HideInInspector] public MinerManager minerManager;
    //[HideInInspector] public SingleUseItemManager singleUseItemManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            drill = GetComponent<Drill>();
            minerManager = GetComponent<MinerManager>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}