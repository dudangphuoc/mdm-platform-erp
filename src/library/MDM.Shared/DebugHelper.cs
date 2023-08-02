using System;
using System.Collections.Generic;
using System.Text;

namespace MDM.Shared
{
    static public class DebugHelper
    {
        public static bool IsDebug
        {
            get
            {
#pragma warning disable
#if DEBUG
                return true;
#endif
                return false;
#pragma warning restore
            }
        }
    }
}
