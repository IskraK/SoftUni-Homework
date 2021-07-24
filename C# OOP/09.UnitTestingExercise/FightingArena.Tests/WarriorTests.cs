using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("  ",50,100)]
        [TestCase(null,50,100)]
        [TestCase("Warrior",0,100)]
        [TestCase("Warrior",-50,100)]
        [TestCase("Warrior",50,-100)]
        public void Ctor_ThrowsException_WhenArgsAreNotValid(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase(30,55)]
        [TestCase(10,55)]
        [TestCase(55,30)]
        [TestCase(55,20)]
        public void Attack_ThrowsException_WhenHpIsLessThanMin(int attackerHp,int warriorHp)
        {
            Warrior attacker = new Warrior("Attacker", 50, attackerHp);
            Warrior warrior = new Warrior("Warrior", 10, warriorHp);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Attack_ThrowsException_WhenWarriorKillsAttacker()
        {
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", attacker.HP+1, 100);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Attack_DecreasesAttackerHp()
        {
            int attackerHp = 100;
            Warrior attacker = new Warrior("Attacker", 50, attackerHp);
            Warrior warrior = new Warrior("Warrior", 30, 100);
            attacker.Attack(warrior);
            Assert.That(attacker.HP, Is.EqualTo(attackerHp - warrior.Damage));
        }

        [Test]
        public void Attack_SetWarriorHpToZero_WhenAttackerDamageIsGreaterThanWarriorHp()
        {
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", 30, 40);
            attacker.Attack(warrior);
            Assert.That(warrior.HP, Is.EqualTo(0));
        }

        [Test]
        public void Attack_DecreasesWarriorHpByAttackerDamage()
        {
            int warriorHp = 100;
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", 30, warriorHp);
            attacker.Attack(warrior);
            Assert.That(warrior.HP, Is.EqualTo(warriorHp-attacker.Damage));
        }
    }
}