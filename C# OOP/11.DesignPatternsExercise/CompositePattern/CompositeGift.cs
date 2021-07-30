using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public class CompositeGift : GiftBase, IGiftOperatons
    {
        private ICollection<GiftBase> gifts;
        public CompositeGift(string name, int price) 
            : base(name, price)
        {
            gifts = new HashSet<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }
        public void Remove(GiftBase gift)
        {
            gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            int totalPrice = 0;
            Console.WriteLine($"{name} contains following products with prices:");

            foreach (var gift in gifts)
            {
                totalPrice += gift.CalculateTotalPrice();
            }

            return totalPrice;
        }

    }
}
