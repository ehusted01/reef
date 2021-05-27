using reef.shared.Models.Device;
using reef.shared.Models.Fish;

namespace reef.shared.Controllers {
  public class FishController {
    public FishController(FishLibrary lib) {
      feeeesh = lib;
    }

    private FishLibrary feeeesh;

    /// <summary>
    /// Load the game textures
    /// </summary>
    public void Load(GameIO gameIO) {
      feeeesh.Load(gameIO, "fish.json");
    }
  }
}
