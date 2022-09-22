using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GotoDeckBuilder : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera deckSelect;
    [SerializeField] CinemachineVirtualCamera deckBuild;

    public void gotoscreen()
    {
        deckBuild.Priority = 1;
        deckSelect.Priority = 0;
    }
}
