# Requirements

There is an application that simulates state of products for the shop. New type of products just added. Implement simulation for these products. Also refactor method `GildedRose.UpdateQuality`. Avoid any changes in class `Item` or of property `GlidedRose.Items`.

## Types of items

### Sulfuras

- All products with name starts with 'Sulfuras' (**Attention: guess**)
- SellIn doesn't change
- Quality doesn't change (**Attention: guess: and always equals to 80**)

### Aged Brie

- All products with name 'Aged Brie' (**Attention: guess**)
- SellIn infinitely decreasing by 1
- Quality increasing up to 50
    - by 1 if SellIn >= 0
    - by 2 if SellIn < 0

### Backstage passes

- All products with name starts with 'Backstage passes' (**Attention: guess**)
- SellIn infinitely decreasing by 1
- Quality increasing up to 50
  - by 1 if SellIn > 10
  - by 2 if SellIn > 5
  - by 3 if SellIn >= 0
  - becomes 0 after SellIn < 0

### Conjured

- All products with name starts with 'Conjured' (**Attention: guess**)
- SellIn infinitely decreasing by 1
- Quality infinitely decreasing down to 0
  - by 2 if SellIn >= 0
  - by 4 if SellIn < 0

### Normal

- All products which are not [Sulfuras](#sulfuras), [Aged Brie](#aged-brie), [Backstage passes](#backstage-passes) nor [Conjured](#conjured) (Maybe 'which are don't belong to any other types' for the case of new product types in the future?)
- SellIn infinitely decreasing by 1
- Quality infinitely decreasing down to 0
  - by 1 if SellIn >= 0
  - by 2 if SellIn < 0

## Application flow

1. Get 0-based number of a day in command line args
   - Default value is 1
2. Have predefined list of products:
   - +5 Dexterity Vest, SellIn = 10, Quality = 20
   - Aged Brie, SellIn = 2, Quality = 0
   - Elixir of the Mongoose, SellIn = 5, Quality = 7
   - Sulfuras, Hand of Ragnaros, SellIn = 0, Quality = 80
   - Sulfuras, Hand of Ragnaros, SellIn = -1, Quality = 80
   - Backstage passes to a TAFKAL80ETC concert, SellIn = 15, Quality = 20
   - Backstage passes to a TAFKAL80ETC concert, SellIn = 10, Quality = 49
   - Backstage passes to a TAFKAL80ETC concert, SellIn = 5, Quality = 49
   - Conjured Mana Cake, SellIn = 3, Quality = 6
3. For each day, starting from 0 and ending with day from point 1 run the simulation
    - On day 0 do nothing
    - On any other day apply [rules based on product type](#types-of-items)
4. For each day print current state in console
