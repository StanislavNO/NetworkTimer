using System;

namespace Assets.Code.Networking
{
    public interface ITimeProvider
    {
        DateTime ServerTime { get; }

        void Update(Action Complied);
    }
}
