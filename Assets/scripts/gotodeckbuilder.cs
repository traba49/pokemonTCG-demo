using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class gotodeckbuilder : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera deckselect;
    [SerializeField] CinemachineVirtualCamera deckbuild;

    public void gotoscreen()
    {
        deckbuild.Priority = 1;
        deckselect.Priority = 0;
    }
}
