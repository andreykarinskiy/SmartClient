using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    using Prism.Logging;

    public static class LoggerExtension
    {
        public static void Info(this ILoggerFacade logger, string message)
        {
            logger.Log(message, Category.Info, Priority.None);
        }
    }
}
