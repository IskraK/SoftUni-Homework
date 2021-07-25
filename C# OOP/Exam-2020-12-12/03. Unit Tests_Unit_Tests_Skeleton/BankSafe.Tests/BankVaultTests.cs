using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;
        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            item = new Item("Owner", "123");
        }

        [Test]
        public void Ctor_InitializeDictionary()
        {
            Assert.That(vault.VaultCells, Is.Not.Null);
        }

        [Test]
        public void Ctor_ReturnsCorrectCount()
        {
            Assert.That(vault.VaultCells.Count, Is.EqualTo(12));
        }

        [Test]
        public void AddItem_ThrowsException_WhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => vault.AddItem("cell", item));
        }

        [Test]
        public void AddItem_ThrowsException_WhenCellIsNotEmpty()
        {
            vault.AddItem("A1", item);
            Item item2 = new Item("Owner2", "222");
            Assert.Throws<ArgumentException>(() => vault.AddItem("A1", item2));
        }

        [Test]
        public void AddItem_ThrowsException_WhenCellAndItemExist()
        {
            vault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => vault.AddItem("A2",item));
        }

        [Test]
        public void AddItem_WorksCorrect_WhenArgsAreValid()
        {
            string result=vault.AddItem("A1", item);
            Assert.That(vault.VaultCells["A1"].Owner, Is.EqualTo(item.Owner));
            Assert.That(vault.VaultCells["A1"].ItemId, Is.EqualTo(item.ItemId));
            Assert.That(vault.VaultCells["A1"], Is.EqualTo(item));
            Assert.That($"Item:{item.ItemId} saved successfully!", Is.EqualTo(result));
        }

        [Test]
        public void RemoveItem_ThrowsException_WhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("cell", item));
        }

        [Test]
        public void RemoveItem_ThrowsException_WhenItemDoesNotExist()
        {
            vault.AddItem("A1", item);
            Item item2 = new Item("Owner2", "222");
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A1", item2));
        }

        [Test]
        public void RemoveItem_WorksCorrect_WhenArgsAreValid()
        {
            vault.AddItem("A1", item);
            string result = vault.RemoveItem("A1", item);
            Assert.That(vault.VaultCells["A1"], Is.Null);
            Assert.That($"Remove item:{item.ItemId} successfully!", Is.EqualTo(result));
        }
    }
}