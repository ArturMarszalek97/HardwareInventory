using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Models.Helpers
{
    /// <summary>
    ///     Container for common strings in modules.
    /// </summary>
    public class CommonContainer
    {
        /// <summary>
        ///     The execute request invoke
        /// </summary>
        public const string InfoMethodInvoked = "{0} invoked";

        /// <summary>
        ///     The information method completed
        /// </summary>
        public const string InfoMethodCompleted = "{0} completed successfully";

        /// <summary>
        ///     The execute request fatal
        /// </summary>
        public const string FatalStringGeneral = "Fatal error occurred!";

        /// <summary>
        ///     The fatal string general with argument
        /// </summary>
        public const string FatalStringGeneralWithArgument = "Fatal error \"{0}\" occurred in method {1}";

        /// <summary>
        ///     The error string general with argument
        /// </summary>
        public const string ErrorStringGeneralWithArgument = "Error \"{0}\" occurred in method {1}";

        /// <summary>
        ///     The error argument null
        /// </summary>
        public const string ErrorArgumentNull = "One or more required parameters are null";

        /// <summary>
        ///     The method returned result
        /// </summary>
        public const string DebugMethodReturnedResult = "The {0} method returned the result.";

        /// <summary>
        ///     The internal server error
        /// </summary>
        public const string ErrorInternalServer = "Internal server error.";

        /// <summary>
        ///     The not found error
        /// </summary>
        public const string NotFoundError = "Not found error in method {0}.";
    }
}
