using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace muchos_motors_api.Utils
{
    public static class ValidationUtils
    {
        public static bool IsNotNull(params object[] parameters)
        {
            foreach (var parameter in parameters)
            {
                if (parameter is string str && string.IsNullOrEmpty(str))
                {
                    return false;
                }

                if (parameter == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
