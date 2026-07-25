using System.Collections.Generic;
using System.Threading.Tasks;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    private const string RequirementsSkipReason = "Requirements are not finalized";
    
    private IEnumerable<TestDataRow<(Item item, Item expectedAfterDay)>> GetOneDayTestData()
    {
        #region Sulfuras
        
        yield return new((
                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80},
                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80}), 
            DisplayName: "Sulfuras state invariability");
        
        yield return new((
                new() {Name = "sulfuras, hand of ragnaros", SellIn = 1, Quality = 80},
                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80}), 
            DisplayName: "Sulfuras detection lower case",
            Skip: RequirementsSkipReason);
        
        yield return new((
                new() {Name = "SULFURAS, HAND OF RAGNAROS", SellIn = 1, Quality = 80},
                new() {Name = "SULFURAS, HAND OF RAGNAROS", SellIn = 1, Quality = 80}), 
            DisplayName: "Sulfuras detection upper case",
            Skip: RequirementsSkipReason);
        
        yield return new((
                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 0},
                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80}), 
            DisplayName: "Sulfuras quality recovering",
            Skip: RequirementsSkipReason);
        
        yield return new((
                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 81},
                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80}), 
            DisplayName: "Sulfuras quality recovering",
            Skip: RequirementsSkipReason);
        
        yield return new((
                new() {Name = "Sulfuras", SellIn = 1, Quality = 0},
                new() {Name = "Sulfuras", SellIn = 1, Quality = 80}), 
            DisplayName: "Sulfuras short name detection",
            Skip: RequirementsSkipReason);
        
        #endregion

        #region Aged Brie
        
        yield return new((
                new() {Name = "Aged Brie", SellIn = 1, Quality = 1},
                new() {Name = "Aged Brie", SellIn = 0, Quality = 2}),
            DisplayName: "Aged Brie quality increasing");
        
        yield return new((
                new() {Name = "Aged Brie", SellIn = 0, Quality = 1},
                new() {Name = "Aged Brie", SellIn = -1, Quality = 3}),
            DisplayName: "Aged Brie quality increasing after sell day");
        
        yield return new((
                new() {Name = "Aged Brie", SellIn = 1, Quality = 50},
                new() {Name = "Aged Brie", SellIn = 0, Quality = 50}),
            DisplayName: "Aged Brie quality limit");
        
        yield return new((
                new() {Name = "Aged Brie", SellIn = 1, Quality = -2},
                new() {Name = "Aged Brie", SellIn = 0, Quality = 0}),
            DisplayName: "Aged Brie quality recovering from too low",
            Skip: RequirementsSkipReason);
        
        yield return new((
                new() {Name = "Aged Brie", SellIn = 1, Quality = 100},
                new() {Name = "Aged Brie", SellIn = 0, Quality = 50}),
            DisplayName: "Aged Brie quality recovering from too big",
            Skip: RequirementsSkipReason);
        
        #endregion

        #region Backstage passes
        
        yield return new((
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 1},
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 2}),
            DisplayName: "Backstage passes quality increasing");
        
        yield return new((
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 1},
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 3}),
            DisplayName: "Backstage passes quality increasing by 2 if SellIn <= 10");
        
        yield return new((
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 1},
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 4}),
            DisplayName: "Backstage passes quality increasing by 3 if SellIn <= 5");
        
        yield return new((
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 1},
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0}),
            DisplayName: "Backstage passes quality becomes 0 after SellIn < 0");
        
        yield return new((
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 50},
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50}),
            DisplayName: "Backstage passes quality limited");
        
        yield return new((
                new() {Name = "Backstage passes Sulfuras", SellIn = 1, Quality = 0},
                new() {Name = "Backstage passes Sulfuras", SellIn = 0, Quality = 3}),
            DisplayName: "Backstage passes correct detection",
            Skip: RequirementsSkipReason);

        #endregion

        #region Conjured
        
        yield return new((
                new() {Name = "Conjured Mana Cake", SellIn = 15, Quality = 4},
                new() {Name = "Conjured Mana Cake", SellIn = 14, Quality = 2}),
            DisplayName: "Conjured quality decreasing by 2");
        
        yield return new((
                new() {Name = "Conjured Mana Cake", SellIn = 0, Quality = 4},
                new() {Name = "Conjured Mana Cake", SellIn = -1, Quality = 0}),
            DisplayName: "Conjured quality decreasing by 4 if SellIn < 0");
        
        yield return new((
                new() {Name = "Conjured Mana Cake", SellIn = 0, Quality = 0},
                new() {Name = "Conjured Mana Cake", SellIn = -1, Quality = 0}),
            DisplayName: "Conjured quality limited");
        
        yield return new((
                new() {Name = "Conjured backstage passes sulfures", SellIn = 20, Quality = 4},
                new() {Name = "Conjured backstage passes sulfures", SellIn = 19, Quality = 2}),
            DisplayName: "Conjured correct detection",
            Skip: RequirementsSkipReason);

        #endregion

        #region Normal
        
        yield return new((
                new() {Name = "+5 Dexterity Vest", SellIn = 15, Quality = 4},
                new() {Name = "+5 Dexterity Vest", SellIn = 14, Quality = 3}),
            DisplayName: "Normal product quality decreasing by 1");
        
        yield return new((
                new() {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 4},
                new() {Name = "+5 Dexterity Vest", SellIn = -1, Quality = 2}),
            DisplayName: "Normal product quality decreasing by 2 if SellIn < 0");
        
        yield return new((
                new() {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 0},
                new() {Name = "+5 Dexterity Vest", SellIn = -1, Quality = 0}),
            DisplayName: "Normal product quality limited");
        
        yield return new((
                new() {Name = "+5 conjured backstage passes sulfures", SellIn = 0, Quality = 4},
                new() {Name = "+5 conjured backstage passes sulfures", SellIn = -1, Quality = 2}),
            DisplayName: "Normal product correct detection",
            Skip: RequirementsSkipReason);

        #endregion
    }

    [Test]
    [InstanceMethodDataSource(nameof(GetOneDayTestData))]
    public async Task OneDayTest(Item item, Item expectedAfterDay)
    {
        var items = new List<Item> { item };
        var app = new GildedRose(items);
        app.UpdateQuality();
        await Assert.That(items[0].Name).EqualTo(expectedAfterDay.Name);
        await Assert.That(items[0].Quality).EqualTo(expectedAfterDay.Quality);
        await Assert.That(items[0].SellIn).EqualTo(expectedAfterDay.SellIn);
    }
}
