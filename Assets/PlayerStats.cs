using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    [SerializeField] private int startMoney = 400;
    public static int Lives;
    [SerializeField] private int startLives = 20;

    private void Start()
    {
        money = startMoney;
        Lives = startLives;
    }
}