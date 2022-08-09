const { Shop, Item } = require("../src/gilded_rose");

describe("Item", function() {
  it("should create a new Item", function() {
    const item = new Item("foo", 0, 0);
    expect(item).toEqual({
      name: "foo",
      sellIn: 0,
      quality: 0
    });
  });

  it("should create an invalid Item if not all args are supplied", function() {
    const item = new Item(0, 0);
    expect(item).toEqual({
      name: 0,
      sellIn: 0,
      quality: undefined
    });
  });
});

describe("Shop", function() {
  describe("General", () => {
    it("should add an item to the store with name 'foo'", function() {
      const gildedRose = new Shop([new Item("foo", 0, 0)]);
      expect(gildedRose.items[0].name).toBe("foo");
    });

    it("should not throw when run 'updateQuality' with one item in the store", function() {
      const gildedRose = new Shop([new Item("foo", 0, 0)]);
      expect(() => gildedRose.updateQuality()).not.toThrow();
    });

    it("should not throw when run 'updateQuality' with no items in the store", function() {
      const gildedRose = new Shop();
      expect(() => gildedRose.updateQuality()).not.toThrow();
    });
  });

  describe("Regular Item", () => {
    it("'sellIn' and 'quality' should both decrease by 1 if 'sellIn' > 0 and 'quality' > 0", function() {
      const gildedRose = new Shop([new Item("foo", 1, 1)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(0);
      expect(items[0].quality).toBe(0);
    });

    it("'quality' should not decrease below 0", function() {
      const gildedRose = new Shop([new Item("foo", 1, 0)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(0);
      expect(items[0].quality).toBe(0);
    });

    it("'sellIn' should decrease below 0", function() {
      const gildedRose = new Shop([new Item("foo", 1, 0)]);
      gildedRose.updateQuality();
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(-1);
      expect(items[0].quality).toBe(0);
    });

    it("'sellIn' should decrease below 0, but 'quality' should not decrease below 0", function() {
      const gildedRose = new Shop([new Item("foo", 1, 0)]);
      gildedRose.updateQuality();
      gildedRose.updateQuality();
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(-2);
      expect(items[0].quality).toBe(0);
    });

    it("when 'sellIn', < 0 'quality' should decrease by 2 each day", function() {
      const gildedRose = new Shop([new Item("foo", 0, 10)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(-1);
      expect(items[0].quality).toBe(8);
    });
  });

  describe("Aged Brie", () => {
    it("'quality' should increase by 1", function() {
      const gildedRose = new Shop([new Item("Aged Brie", 1, 0)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(0);
      expect(items[0].quality).toBe(1);
    });

    it("'quality' should increase by 2 even when 'sellIn' < 0", function() {
      const gildedRose = new Shop([new Item("Aged Brie", 0, 0)]);
      gildedRose.updateQuality();
      gildedRose.updateQuality();
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(-3);
      expect(items[0].quality).toBe(6);
    });

    it("'quality' should not increase above 50", function() {
      const gildedRose = new Shop([new Item("Aged Brie", 1, 49)]);
      gildedRose.updateQuality();
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(-1);
      expect(items[0].quality).toBe(50);
    });
  });

  describe("Backstage Passes", () => {
    it("'quality' should increase by 1 if sellIn is 11", function() {
      const gildedRose = new Shop([
        new Item("Backstage passes to a TAFKAL80ETC concert", 11, 0)
      ]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(10);
      expect(items[0].quality).toBe(1);
    });

    it("'quality' should increase by 2 if 'sellIn' is 10", function() {
      const gildedRose = new Shop([
        new Item("Backstage passes to a TAFKAL80ETC concert", 10, 0)
      ]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(9);
      expect(items[0].quality).toBe(2);
    });

    it("'quality' should increase by 2 each day if 'sellIn' is <= 10 AND > 5", function() {
      const gildedRose = new Shop([
        new Item("Backstage passes to a TAFKAL80ETC concert", 10, 0)
      ]);
      gildedRose.updateQuality();
      gildedRose.updateQuality();
      gildedRose.updateQuality();
      gildedRose.updateQuality();
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(5);
      expect(items[0].quality).toBe(10);
    });

    it("'quality' should increase by 3 if 'sellIn' is 5", function() {
      const gildedRose = new Shop([
        new Item("Backstage passes to a TAFKAL80ETC concert", 5, 0)
      ]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(4);
      expect(items[0].quality).toBe(3);
    });

    it("'quality' should increase by 3 each day if 'sellIn' is <= 5 AND >= 0", function() {
      const gildedRose = new Shop([
        new Item("Backstage passes to a TAFKAL80ETC concert", 5, 0)
      ]);
      gildedRose.updateQuality();
      gildedRose.updateQuality();
      gildedRose.updateQuality();
      gildedRose.updateQuality();
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(0);
      expect(items[0].quality).toBe(15);
    });

    it("'quality' should always be 0 when 'sellIn' < 0", function() {
      const gildedRose = new Shop([
        new Item("Backstage passes to a TAFKAL80ETC concert", 0, 10)
      ]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(-1);
      expect(items[0].quality).toBe(0);
    });

    // unsure if this test is necessary as it's covered by previous tests
    it("'quality' should always be ('sellIn' - 10) + 10 + 15 when 'sellIn' reaches 0 ", function() {
      const sellIn = 20;
      const gildedRose = new Shop([
        new Item("Backstage passes to a TAFKAL80ETC concert", sellIn, 0)
      ]);

      let items;
      for (let i = 0; i < sellIn; i++) {
        items = gildedRose.updateQuality();
      }

      expect(items[0].sellIn).toBe(0);
      expect(items[0].quality).toBe(sellIn + 15);
    });

    // unsure if this test is necessary as it's covered by previous tests
    it("'quality' should never increase above 50", function() {
      const sellIn = 100;
      const gildedRose = new Shop([
        new Item("Backstage passes to a TAFKAL80ETC concert", sellIn, 0)
      ]);

      let items;
      for (let i = 0; i < sellIn; i++) {
        items = gildedRose.updateQuality();
      }

      expect(items[0].sellIn).toBe(0);
      expect(items[0].quality).toBe(50);
    });
  });

  describe("Sulfuras, Legendary Item", () => {
    it("'sellIn' should not change", function() {
      const gildedRose = new Shop([new Item("Sulfuras, Hand of Ragnaros", 1, 80)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(1);
    });

    it("'quality' should not change", function() {
      const gildedRose = new Shop([new Item("Sulfuras, Hand of Ragnaros", 1, 80)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(80);
    });
  });
});

