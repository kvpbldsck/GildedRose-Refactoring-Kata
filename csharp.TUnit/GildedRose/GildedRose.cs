using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private const string BackstagePassesName = "Backstage passes to a TAFKAL80ETC concert";
    private const string AgedBrieName = "Aged Brie";
    private const string SulfurasName = "Sulfuras, Hand of Ragnaros";
    private const string ConjuredName = "Conjured Mana Cake";

    private const int MinQuality = 0;
    private const int MaxQuality = 50;
    private const int SulfurasQuality = 80;

    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            item.SellIn = CalculateNewSellIn(item);
            item.Quality = CalculateNewQuality(item);
        }
    }

    private static int CalculateNewSellIn(Item item) 
        => item.Name switch
        {
            SulfurasName => item.SellIn,
            _ => item.SellIn - 1
        };

    private static int CalculateNewQuality(Item item) 
        => item.Name switch
        {
            SulfurasName 
                => SulfurasQuality,
                
            AgedBrieName when item.SellIn < 0 
                => Math.Clamp(item.Quality + 2, MinQuality, MaxQuality),
            AgedBrieName 
                => Math.Clamp(item.Quality + 1, MinQuality, MaxQuality),
                
            BackstagePassesName when item.SellIn > 10 
                => Math.Clamp(item.Quality + 1, MinQuality, MaxQuality),
            BackstagePassesName when item.SellIn > 5 
                => Math.Clamp(item.Quality + 2, MinQuality, MaxQuality),
            BackstagePassesName when item.SellIn >= 0 
                => Math.Clamp(item.Quality + 3, MinQuality, MaxQuality),
            BackstagePassesName when item.SellIn > 10 
                => MinQuality,
                
            _ when item.SellIn >= 0 
                => Math.Clamp(item.Quality - 1, MinQuality, MaxQuality),
            _ 
                => Math.Clamp(item.Quality - 2, MinQuality, MaxQuality),
        };
}
