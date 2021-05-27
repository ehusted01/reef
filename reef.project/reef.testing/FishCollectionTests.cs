using System;
using Xunit;
using reef.shared.Models;
using reef.shared.Models.Fishes;

namespace reef.testing {
  public class FishCollectionTests {
    [Fact]
    public void AddFish() {
      var collection = new FishCollection();
      var fish = new Fish();
      Assert.True(collection.Count() == 0);
      collection.AddFish(fish);
      Assert.True(collection.Count() == 1);
      Assert.True(collection.Updated);
    }

    [Fact]
    public void RemoveFish() {
      var collection = new FishCollection();
      var fish = new Fish();
      Assert.True(collection.Count() == 0);
      collection.AddFish(fish);
      collection.RemoveFish();
      Assert.True(collection.Count() == 0);
      Assert.True(collection.Updated);
    }
  }
}
