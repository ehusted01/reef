using System;
using Xunit;
using reef.shared.Models;

namespace reef.testing {
  public class FishCollectionTests {
    [Fact]
    public void AddFish() {
      var fish = new FishCollection();
      Assert.True(fish.FishCount == FishCollection.DefaultFishCount);
      fish.AddFish();
      Assert.True(fish.FishCount == FishCollection.DefaultFishCount+1);
      Assert.True(fish.FishUpdated = true);
    }

    [Fact]
    public void RemoveFish() {
      var fish = new FishCollection();
      Assert.True(fish.FishCount == FishCollection.DefaultFishCount);
      fish.AddFish();
      fish.RemoveFish();
      Assert.True(fish.FishCount == FishCollection.DefaultFishCount);
      Assert.True(fish.FishUpdated = true);
    }
  }
}
