using Snek.Models;

namespace Snek.Services
{
    public interface IRandomPointGenerator
    {
        Point NextPoint();
        Point NextPoint(Point exclude);
    }
}