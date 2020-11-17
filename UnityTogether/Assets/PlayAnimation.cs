using System.Collections;
using System.Collections.Generic;
using Animancer;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    [SerializeField]
    private AnimancerComponent _Animancer;

    [SerializeField]
    private AnimationClip _Clip;

    private void OnEnable()
    {
        _Animancer.Play(_Clip);
    }


}
