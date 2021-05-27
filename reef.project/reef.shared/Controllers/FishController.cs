using reef.shared.Models.Device;
using reef.shared.Models.Fishes;

namespace reef.shared.Controllers {
  public class FishController {
    public FishController(FishLibrary lib) {
      feeeesh = lib;
    }

    private FishLibrary feeeesh;

    public Fish GetCommon() {
      return feeeesh.getCommonFish();
    }

    /// <summary>
    /// Load the game textures
    /// </summary>
    public void Load(GameIO gameIO) {
      feeeesh.Load(gameIO, "fish.json");
    }
  }
}
