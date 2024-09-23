using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Game.Model
{
    public interface IReadOnlyTimer
    {
        int Second { get; }
        int Minute { get; }
        int Hours { get; }
    }
}
