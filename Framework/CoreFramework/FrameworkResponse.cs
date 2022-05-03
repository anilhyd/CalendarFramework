using Calendar.Framework.Rules;
using Calendar.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Framework
{
    public class FrameworkResponse
    {
        /// <summary>
        /// Internal variable for storing the record status.
        /// </summary>
        private Status status = Status.Failed;

        /// <summary>
        /// Gets or sets the execution status of the operation.
        /// </summary>
        public Status Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }

        /// <summary>
        /// Gets the Error code if any exception happened during the execution.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the Unique Code of the operation.
        /// </summary>
        public string TransactionCode { get; set; }

        /// <summary>
        /// Gets or sets the Message if operation success for showing message into top layers.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets the Exception object if any exception occurs during the process of the operation.
        /// </summary>
        public BDException Exception { get; internal set; }

        /// <summary>
        /// Gets the collection of currently broken rules.
        /// </summary>
        /// <remarks>
        /// This collection is readonly and can be safely made available
        /// to code outside the business object such as the UI. This allows
        /// external code, such as a UI, to display the list of broken rules
        /// to the user.
        /// </remarks>
        public BrokenRulesCollection BrokenRules { get; internal set; }

        /// <summary>
        /// Holds the List of exception details
        /// </summary>
        public List<ExceptionDetail> ExceptionList { get; set; }

        /// <summary>
        /// Holds the List of exception details
        /// </summary>
        public string GetExceptionString()
        {
            StringBuilder result = new StringBuilder();
            foreach (ExceptionDetail exception in ExceptionList)
            {
                result.Append("<Exception Id='");
                result.Append(exception.Id);
                result.Append("' Name='");
                result.Append(exception.ColumnName);
                result.Append("' Message='");
                result.Append(exception.Message);
                result.Append("' />");
            }
            string output = result.ToString();
            if (!string.IsNullOrWhiteSpace(output))
                output = "<Exceptions>" + output + "</Exceptions>";

            return output;
        }

        /// <summary>
        /// Gets or sets the Request. Used Integration framework.
        /// </summary>
        internal string Request { get; set; }

        /// <summary>
        /// Gets or sets the Response. Used Integration framework.
        /// </summary>
        internal string Response { get; set; }

        /// <summary>
        /// Gets or sets the Results return by integration framework. Used Integration framework.
        /// </summary>
        internal List<KeyValuePair<string, string>> Results { get; set; }

        /// <summary>
        /// Gets or sets the Results return by integration framework. Used Integration framework.
        /// </summary>
        internal bool IsProcessed { get; set; }

        /// <summary>
        /// Returns the Saved Entity.
        /// </summary>
        public object Entity { get; set; }
    }
}
