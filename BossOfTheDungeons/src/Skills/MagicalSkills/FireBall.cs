﻿using BossOfTheDungeons.Common.Structs;
using BossOfTheDungeons.Skills.Base;
using BossOfTheDungeons.Skills.Enums;
using BossOfTheDungeons.Skills.Utils;

namespace BossOfTheDungeons.Skills.MagicalSkills;

public class FireBall : Skill
{
    public FireBall() : base("Огненный шар", 15, DamageType.MagicalDamage, SkillType.Normal)
    {
    }

    public override Damage DamageCalculation(DamageCalculationParameters parameters)
    {
        return base.DamageCalculation(parameters);
    }
}