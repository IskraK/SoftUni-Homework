using System;

namespace CompositePattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var phone = new SingleGift("Phone", 256);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            var rootBox = new CompositeGift("RootBox", 0);
            var truck = new SingleGift("Truck", 289);
            var toy = new SingleGift("Toy", 587);
            rootBox.Add(truck);
            rootBox.Add(toy);

            var childBox = new CompositeGift("ChildBox", 0);
            var soldier = new SingleGift("Soldier", 200);
            childBox.Add(soldier);

            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
        }
    }
}
