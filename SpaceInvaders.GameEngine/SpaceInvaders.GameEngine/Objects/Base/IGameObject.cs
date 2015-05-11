
namespace SpaceInvaders.GameEngine.Objects.Base
{
    interface IGameObject
    {
        int PosX { get; }
        int PosY { get; }
        bool Live { get; set; }
    }
}
