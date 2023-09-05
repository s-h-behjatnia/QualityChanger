using QualityChanger.Model;

namespace QualityChanger.Service
{
    public class UpdateQualityService
    {
        IList<Item> Items;
        public UpdateQualityService(IList<Item> items)
        {
            Items = items;
        }
        public void UpdateQuality()
        {
            Items = Items.Select(it => new Item
            {
                Name = it.Name,
                SellIn = GetSellIn(it),
                Quality = GetQuality(it)
            }).ToList();
        }

        public int GetSellIn(Item item)
        {
            int sellIn = item.SellIn;
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return sellIn;
            sellIn--;
            return sellIn;
        }
        public int GetQuality(Item item)
        {
            int quality = item.Quality;
            if (item.SellIn == 50 || item.SellIn == 0)
                return quality;
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return quality;
            if (item.Name == "Conjured Mana Cake")
            {
                if (item.SellIn < 0)
                {
                    quality -= 4;
                    return quality;
                }
                quality -= 2;
                return quality;
            }
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert" || item.Name == "Aged Brie")
            {
                if (item.SellIn > 5 && item.SellIn <= 10)
                {
                    item.Quality += 2;
                }
                if (item.SellIn > 0 && item.SellIn <= 5)
                {
                    item.Quality += 3;
                }
            }
            if (item.SellIn < 0)
            {
                quality -= 2;
                return quality;
            }
            quality--;
            return quality;
        }
    }
}
