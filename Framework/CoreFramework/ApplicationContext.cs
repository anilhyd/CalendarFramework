using Calendar.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Framework
{
    public class ApplicationContext
    {
        #region TransactionType
        /// <summary>
        /// Gets a value indicating whether the application 
        /// is currently using Enterprise Transaction Or Transactional Scope Or Own Transaction.
        /// </summary>
        public static TransactionalTypes TransactionType
        {
            get
            {
                // return Enum<TransactionalTypes>.Parse(ConfigurationManager.AppSettings["TransactionType"]);
                //return Enum<TransactionalTypes>.Parse(FrameworkConfigurator.FrameworkConfigData.TransactionType);
                return TransactionalTypes.Manual;
            }
        }

        #endregion

        #region Class : Enum

        /// <summary>
        /// Parese the String and returns the Enum based on the Type T.
        /// </summary>
        /// <typeparam name="T">Enumeration of type T.</typeparam>
        public static class Enum<T>
        {
            /// <summary>
            /// Gets the <see cref="System.Collections.Generic.IList">IList</see> values for the Type T Enums.
            /// </summary>
            public static IList<T> GetValues
            {
                get
                {
                    IList<T> list = new List<T>();
                    foreach (object value in Enum.GetValues(typeof(T)))
                    {
                        list.Add((T)value);
                    }

                    return list;
                }
            }

            /// <summary>
            /// Returns the parsed value of Type T.
            /// </summary>
            /// <param name="value">String data for the enumeration.</param>
            /// <returns>Returns enumerater of type T.</returns>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Justification = "Used during parsing the Enum")]
            public static T Parse(string value)
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
        }
        #endregion

        #region UserContext && Organization

        /// <summary>
        /// Gets the UserContext for the logged user.
        /// </summary>
        public UserContext UserContext
        {
            get; internal set;
        }


        #endregion

    }
}
