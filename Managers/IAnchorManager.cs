using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchor.Managers
{
    public interface IAnchorManager
    {
        // Singleton
        public static IAnchorManager Instance { get; }
    }
}
