using System;
using UnityEngine;

public sealed class Brick : MonoBehaviour
{
    public Action<int> OnBrickDestroy;

    private Renderer renderer;
    private MaterialPropertyBlock block;

    private void Awake()
    {
        renderer = GetComponentInChildren<Renderer>(); 
        block = new MaterialPropertyBlock();
    }

    private void Start()
    {
        switch (PointValue)
        {
            case 1 :
                block.SetColor("_BaseColor", Color.green);
                break;
            case 2:
                block.SetColor("_BaseColor", Color.yellow);
                break;
            case 5:
                block.SetColor("_BaseColor", Color.blue);
                break;
            default:
                block.SetColor("_BaseColor", Color.red);
                break;
        }
        renderer.SetPropertyBlock(block);
    }

    private void OnCollisionEnter()
    {
        OnBrickDestroy.Invoke(PointValue);
        Destroy(gameObject, 0.2f);
    }

    public int PointValue { get; set; }
}
