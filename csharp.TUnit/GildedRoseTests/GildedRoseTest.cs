using System.Collections.Generic;
using System.Threading.Tasks;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public async Task Foo()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        await Assert.That(items[0].Name).EqualTo("fixme");
    }
}
