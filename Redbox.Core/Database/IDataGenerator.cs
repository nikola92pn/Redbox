using System;

namespace Redbox.Core.Database
{
    public interface IDataGenerator
    {
        public void Initialize(IServiceProvider serviceProvider);
    }
}
