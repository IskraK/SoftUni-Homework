using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void InitializeWarriors()
        {
            Assert.That(arena.Warriors,Is.Not.Null);
        }

        [Test]
        public void Count_IsZero_WhenArenaIsEmpty()
        {
            Assert.That(arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void Enroll_ThrowsException_WhenWarriorExists()
        {
            string name = "Warrior";
            Warrior warrior = new Warrior(name, 50, 100);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior(name, 50, 50)));
        }

        [Test]
        public void Enroll_EncreasesArenaCount()
        {
            Warrior warrior = new Warrior("Warrior", 50, 100);
            arena.Enroll(warrior);
            Assert.That(arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Enroll_AddsNewWarrior_WhenWarriorDoesNotExists()
        {
            string name = "Warrior";
            Warrior warrior = new Warrior(name, 50, 100);
            arena.Enroll(warrior);
            Assert.That(arena.Warriors.Any(w => w.Name == name),Is.True);
        }

        //[Test]
        //public void Fight_ThrowsException_WhenDefenderDoesNotExists()
        //{
        //    string attackerName = "Attacker";
        //    Warrior attacker = new Warrior(attackerName, 50, 100);
        //    arena.Enroll(attacker);
        //    Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, "defender"));
        //}

        //[Test]
        //public void Fight_ThrowsException_WhenAttackerDoesNotExists()
        //{
        //    string defenderName = "Defender";
        //    Warrior defender = new Warrior(defenderName, 50, 100);
        //    arena.Enroll(defender);
        //    Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", defenderName));
        //}

        //[Test]
        //public void Fight_ThrowsException_WhenBothWarriorsDoNotExist()
        //{
        //    Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", "Defender"));
        //}

        [Test]
        [TestCase("Attacker", "Attacker", "Defender")]
        [TestCase("Defender", "Attacker", "Defender")]
        [TestCase("Warrior", "Attacker", "Defender")]
        public void Fight_ThrowsException_WhenWarriorDoesNotExists(string warriorName,string attackerName,string defenderName)
        {
            arena.Enroll(new Warrior(warriorName, 50, 100));
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName));
        }

        [Test]
        public void Fight_BothWarriorsLoseHp()
        {
            int initialHp = 100;
            Warrior attacker = new Warrior("Attacker", 50, initialHp);
            Warrior defender = new Warrior("Defender", 50, initialHp);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight(attacker.Name, defender.Name);
            Assert.That(defender.HP, Is.EqualTo(initialHp-attacker.Damage));
            Assert.That(attacker.HP, Is.EqualTo(initialHp-defender.Damage));
        }
    }
}
