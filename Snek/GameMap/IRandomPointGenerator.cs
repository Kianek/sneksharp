
namespace Snek.GameMap
{
    public interface IRandomPointGenerator
    {
        Point NextPoint();
        Point NextPoint(Point exclude);
    }
}