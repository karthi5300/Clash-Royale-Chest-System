using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestConfigSO" , menuName = "ScriptableObjects/Chests/ChestConfiguration")]
public class ChestConfig : ScriptableObject
{
    [Serializable]
    public class ChestConfigPair
    {
        public ChestType ChestType;
        public ChestScriptableObject ChestSO;
    }

    public ChestConfigPair[] ChestConfigurationMap;
}
