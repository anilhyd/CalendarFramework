#region Header Info
//-----------------------------------------------------------------------
// <copyright file="CommonRules.cs" company="Calendar.Framework">
//  Copyright (c) Calendar.Framework All rights reserved. Website: www.rudhvi.com.
// </copyright>
// <summary>Stores details about a specific broken business rule.</summary>
// <createdby>Deesayya</createdby> 
// <createddate>24-Sept-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using Calendar.Framework.Entity;
using Calendar.Framework.Runtime;
using Calendar.Framework.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

#endregion

namespace Calendar.Framework.Rules
{
    /// <summary>
    /// Generic rule implementation.
    /// </summary>
    public class CommonRules
    {
        #region Constants

        /// <summary>
        /// Local constant string for Success.
        /// </summary>
        private const string Success = "Success";
        //private const string connection = "Data Source=#source#;Initial Catalog=#db#;User ID=#user#;Password=#password#";
        private const string query = "SELECT COLUMN#sno# FROM #table# WHERE COLUMN#sno# = @code and COLUMNC06 = @orgid ";
        #endregion

        #region Unique Code Check
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static bool CheckUniquenessInOrganization(object entity, RuleMapping rule)
        {
            return CheckUniqueness(entity, rule);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static bool CheckUniquenessInBusinessUnit(object entity, RuleMapping rule)
        {
            return CheckUniqueness(entity, rule, true);
        }

        #endregion

        #region String Maximum Length Rquired If String is Not Null
        /// <summary>
        /// Rule ensuring a string value has a minimum length if string is not empty.
        /// </summary>
        /// <param name="value">The data to validate.</param>
        /// <returns>Returns tru/false.</returns>
        public static bool StringMaxLengthIfNotNull(string value, int maxLength)
        {
            bool result = true;
            if(!String.IsNullOrEmpty(value))
                result = ((value.Trim().Length < maxLength)) ? false : true;

            return result;
        }

        /// <summary>
        /// Rule ensuring a string value has a minimum length if string is not empty.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <param name="rule">Rule object.</param>
        /// <returns>Returns true/false.</returns>
        public static bool StringMaxLengthIfNotNull(object entity, RuleMapping rule)
        {
            bool result = true;
            string value = (string)MethodCaller.CallByName(entity, rule.PropertyName, CallType.Get);
            if (!String.IsNullOrEmpty(value))
                result = ((value.Trim().Length <  Convert.ToInt32(rule.Value))) ? true : false ;

            return result;
        }
        #endregion

        #region String Minimum Length Rquired If String is Not Null
        /// <summary>
        /// Rule ensuring a string value has a minimum length if string is not empty.
        /// </summary>
        /// <param name="value">The data to validate.</param>
        /// <returns>Returns tru/false.</returns>
        public static bool StringMinLengthIfNotNull(string value, int minLength)
        {
            bool result = true;
            if (!String.IsNullOrEmpty(value))
                result = ((value.Trim().Length >= minLength)) ? false : true;

            return result;
        }

        /// <summary>
        /// Rule ensuring a string value has a minimum length if string is not empty.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <param name="rule">Rule object.</param>
        /// <returns>Returns true/false.</returns>
        public static bool StringMinLengthIfNotNull(object entity, RuleMapping rule)
        {
            bool result = true;
            string value = (string)MethodCaller.CallByName(entity, rule.PropertyName, CallType.Get);
            if (!String.IsNullOrEmpty(value))
                result = ((value.Trim().Length >= Convert.ToInt32(rule.Value))) ? false : true;

            return result;
        }
        #endregion

        #region StringRquired
        /// <summary>
        /// Rule ensuring a string value contains one or more
        /// characters.
        /// </summary>
        /// <param name="value">The data to validate.</param>
        /// <returns>Returns tru/false.</returns>
        public static bool StringRequired(string value)
        {
            return (!String.IsNullOrEmpty(value) && (value.Trim().Length > 0)) ? true : false;
        }

        /// <summary>
        /// Rule for validating the string required.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <param name="rule">Rule object.</param>
        /// <returns>Returns true/false.</returns>
        public static bool StringRequired(object entity, RuleMapping rule)
        {
            string value = (string)MethodCaller.CallByName(entity, rule.PropertyName, CallType.Get);
            return (!String.IsNullOrEmpty(value) && (value.Trim().Length > 0)) ? true : false;
        }
        #endregion

        #region StringMaxLength

        /// <summary>
        /// Rule ensuring a string value doesn't exceed
        /// a specified length.
        /// </summary>
        /// <param name="value">The data to validate.</param>
        /// <param name="maxLength">Maximum length of the string.</param>
        /// <returns>Returns true/false.</returns>
        public static bool StringMaxLength(string value, int maxLength)
        {
            return (!String.IsNullOrEmpty(value) && (value.Trim().Length > maxLength)) ? false : true;
        }

        /// <summary>
        ///  Rule ensuring a string value doesn't exceed
        /// a specified length.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <param name="rule">Rule object.</param>
        /// <returns>Returns true/false.</returns>
        public static bool StringMaxLength(object entity, RuleMapping rule)
        {
            string value = (string)MethodCaller.CallByName(entity, rule.PropertyName, CallType.Get);
            return (!String.IsNullOrEmpty(value) && (value.Trim().Length > Convert.ToInt32(rule.Value))) ? false : true;
        }
        #endregion

        #region StringMinLength

        /// <summary>
        /// Rule ensuring a string value has a minimum length.
        /// </summary>
        /// <param name="value">The data to validate.</param>
        /// <param name="minLength">Maximum length of the string.</param>
        /// <returns>Returns true/false.</returns>
        public static bool StringMinLength(string value, int minLength)
        {
            return (!String.IsNullOrEmpty(value) && (value.Trim().Length < minLength)) ? false : true;
        }

        /// <summary>
        /// Rule ensuring a string value has a min length.
        /// </summary>
        /// <param name="entity">Enitty object.</param>
        /// <param name="rule">Rule object.</param>
        /// <returns>Returns true or false.</returns>
        public static bool StringMinLength(object entity, RuleMapping rule)
        {
            string value = (string)MethodCaller.CallByName(entity, rule.PropertyName, CallType.Get);
            return (!String.IsNullOrEmpty(value) && (value.Trim().Length < Convert.ToInt32(rule.Value))) ? false : true;
        }

        #endregion

        #region IntegerMaxValue

        /// <summary>
        /// Rule ensuring an integer value doesn't exceed
        /// a specified value.
        /// </summary>
        /// <param name="value">The data to validate.</param>
        /// <param name="maxValue">Maximum Number.</param>
        /// <returns>Returns true/false.</returns>
        public static bool IntegerMaxValue(int value, int maxValue)
        {
            return value > maxValue ? false : true;
        }

        /// <summary>
        /// Rule ensuring an integer value doesn't exceed
        /// a specified value.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <param name="rule">Rule object.</param>
        /// <returns>Returns true/false.</returns>
        public static bool IntegerMaxValue(object entity, RuleMapping rule)
        {
            int? value = MethodCaller.CallByName(entity, rule.PropertyName, CallType.Get).ToString().ParseNullableInt();
            return (value != null && (value > int.Parse(rule.Value))) ? false : true;
        }
        #endregion

        #region IntegerMinValue

        /// <summary>
        /// Rule ensuring an integer value doesn't go below
        /// a specified value.
        /// </summary>
        /// <param name="value">The data to validate.</param>
        /// <param name="minValue">Minimum Number.</param>
        /// <returns>Returns tru/false.</returns>
        public static bool IntegerMinValue(int value, int minValue)
        {
            return value > minValue ? true : false;
        }

        /// <summary>
        ///  Rule ensuring an integer value doesn't go below
        /// a specified value.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <param name="rule">Rule object.</param>
        /// <returns>Returns tru/false.</returns>
        public static bool IntegerMinValue(object entity, RuleMapping rule)
        {
            int? value = MethodCaller.CallByName(entity, rule.PropertyName, CallType.Get).ToString().ParseNullableInt();
            return (value != null && (value < int.Parse(rule.Value))) ? false : true;
        }
        #endregion

        #region Double MaxValue
        /// <summary>
        /// Rule ensuring an double value doesn't exceed
        /// a specified value.
        /// </summary>
        /// <param name="value">The data to validate.</param>
        /// <param name="maxValue">Maximum Number.</param>
        /// <returns>Returns true/false.</returns>
        public static bool DoubleMaxValue(double value, double maxValue)
        {
            return value > maxValue ? false : true;
        }

        /// <summary>
        /// Rule ensuring an double value doesn't exceed
        /// a specified value.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <param name="rule">Rule object.</param>
        /// <returns>Returns true/false.</returns>
        public static bool DoubleMaxValue(object entity, RuleMapping rule)
        {
            double? value = Convert.ToDouble(MethodCaller.CallByName(entity, rule.PropertyName, CallType.Get));
            return (value != null && (value > double.Parse(rule.Value))) ? false : true;
        }

        #endregion

        #region  Double MinValue

        /// <summary>
        /// Rule ensuring an double value doesn't go below
        /// a specified value.
        /// </summary>
        /// <param name="value">The data to validate.</param>
        /// <param name="maxValue">Maximum Number.</param>
        /// <returns>Returns true/false.</returns>
        public static bool DoubleMinValue(double value, double minValue)
        {
            return value < minValue ? false : true;
        }

        /// <summary>
        /// Rule ensuring an double value doesn't go below
        /// a specified value.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <param name="rule">Rule object.</param>
        /// <returns>Returns true/false.</returns>
        public static bool DoubleMinValue(object entity, RuleMapping rule)
        {
            double? value = Convert.ToDouble(MethodCaller.CallByName(entity, rule.PropertyName, CallType.Get));
            return (value != null && (value < double.Parse(rule.Value))) ? false : true;
        }
        #endregion

        #region Float MaxValue
        /// <summary>
        /// Rule ensuring an double value doesn't exceed
        /// a specified value.
        /// </summary>
        /// <param name="value">The data to validate.</param>
        /// <param name="maxValue">Maximum Number.</param>
        /// <returns>Returns true/false.</returns>
        public static bool DecimalMaxValue(decimal value, decimal maxValue)
        {
            return value > maxValue ? false : true;
        }

        /// <summary>
        /// Rule ensuring an double value doesn't exceed
        /// a specified value.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <param name="rule">Rule object.</param>
        /// <returns>Returns true/false.</returns>
        public static bool DecimalMaxValue(object entity, RuleMapping rule)
        {
            decimal? value = Convert.ToDecimal(MethodCaller.CallByName(entity, rule.PropertyName, CallType.Get));
            return (value != null && (value > decimal.Parse(rule.Value))) ? false : true;
        }

        #endregion

        #region  Float MinValue
        /// <summary>
        /// Rule ensuring an double value doesn't go below
        /// a specified value.
        /// </summary>
        /// <param name="value">The data to validate.</param>
        /// <param name="maxValue">Maximum Number.</param>
        /// <returns>Returns true/false.</returns>
        public static bool DecimalMinValue(decimal value, decimal minValue)
        {
            return value < minValue ? false : true;
        }

        /// <summary>
        /// Rule ensuring an double value doesn't go below
        /// a specified value.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <param name="rule">Rule of the object.</param>
        /// <returns>Returns true/false.</returns>
        public static bool DecimalMinValue(object entity, RuleMapping rule)
        {
            decimal? value = Convert.ToDecimal(MethodCaller.CallByName(entity, rule.PropertyName, CallType.Get));
            return (value != null && (value < decimal.Parse(rule.Value))) ? false : true;
        }
        #endregion

        #region Date MaxValue
        /// <summary>
        /// Rule ensuring an double value doesn't exceed
        /// a specified value.
        /// </summary>
        /// <param name="value">The data to validate.</param>
        /// <param name="maxValue">Maximum Number.</param>
        /// <returns>Returns true/false.</returns>
        public static bool DateMaxValue(DateTime value, DateTime maxValue)
        {
            return value > maxValue ? false : true;
        }

        /// <summary>
        /// Rule ensuring an double value doesn't exceed
        /// a specified value.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <param name="rule">Rule object.</param>
        /// <returns>Returns true/false.</returns>
        public static bool DateMaxValue(object entity, RuleMapping rule)
        {
            DateTime? value = (DateTime)MethodCaller.CallByName(entity, rule.PropertyName, CallType.Get);
            return (value != null && (value > DateTime.Parse(rule.Value))) ? false : true;
        }

        #endregion

        #region  Date MinValue
        /// <summary>
        /// Rule ensuring an double value doesn't go below
        /// a specified value.
        /// </summary>
        /// <param name="value">The data to validate.</param>
        /// <param name="maxValue">Maximum Number.</param>
        /// <returns>Returns true/false.</returns>
        public static bool DateMinValue(DateTime value, DateTime minValue)
        {
            return value < minValue ? false : true;
        }

        /// <summary>
        /// Rule ensuring an double value doesn't go below
        /// a specified value.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <param name="rule">Rule object.</param>
        /// <returns>Returns true/false.</returns>
        public static bool DateMinValue(object entity, RuleMapping rule)
        {
            DateTime? value = (DateTime)MethodCaller.CallByName(entity, rule.PropertyName, CallType.Get);
            return (value != null && (value < DateTime.Parse(rule.Value))) ? false : true;
        }
        #endregion

        #region MaxValue
        /// <summary>
        /// Rule ensuring an integer value doesn't exceed
        /// a specified value.
        /// </summary>
        /// <typeparam name="T">Type object.</typeparam>
        /// <param name="value">Object value.</param>
        /// <param name="maximum">Maximum value of object.</param>
        /// <returns>Returns true/false.</returns>
        public static bool MaxValue<T>(T value, T maximum) where T : IComparable
        {
            return value.CompareTo(maximum) >= 1 ? false : true;
        }
        #endregion

        #region MinValue

        /// <summary>
        /// Rule ensuring that a numeric value
        /// doesn't exceed a specified minimum.
        /// </summary>
        /// <typeparam name="T">Runtime type.</typeparam>
        /// <param name="value">Object value.</param>
        /// <param name="minimumValue">Minimum value of the object.</param>
        /// <returns>Returns true/false.</returns>
        public static bool MinValue<T>(T value, T minimumValue) where T : IComparable
        {
            return value.CompareTo(minimumValue) <= -1 ? false : true;
        }
        #endregion

        #region RegExMatch
        /// <summary>
        /// Rule that checks to make sure a value
        /// matches a given regex pattern.
        /// </summary>
        /// <remarks>
        /// This implementation uses late binding.
        /// </remarks>
        /// <param name="value">Object containing the data to validate.</param>
        /// <param name="regex">RegExRuleArgs parameter specifying the name of the 
        /// Property to validate and the regex pattern.</param>
        /// <returns>False if the rule is broken.</returns>
        public static bool RegExMatch(string value, Regex regex)
        {
            if (value == null)

                // if the value is null at this point
                // then Return the pre-defined result value
                return false;
            else

                // the value is not null, so run the 
                // regular expression
                return regex.IsMatch(value) ? true : false;
        }

        /// <summary>
        /// Exectues the regular expression specified in the rule.
        /// </summary>
        /// <param name="entity">Entity Object.</param>
        /// <param name="rule">Rule object.</param>
        /// <returns>True or false.</returns>
        public static bool RegExMatch(object entity, RuleMapping rule)
        {
            string value = MethodCaller.CallByName(entity, rule.PropertyName, CallType.Get).ToString();

            Regex regex = new Regex(rule.Value);
            if (value == null)

                // then Return the pre-defined result value
                return false;
            else

                // the value is not null, so run the 
                // regular expression
                return regex.IsMatch(value) ? true : false;
        }
        #endregion

        #region ToStirng
        /// <summary>
        /// ToString Overrides.
        /// </summary>
        /// <returns>Returns true/false.</returns>
        public override string ToString()
        {
            return Success;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Returns column sequence number by adding required leading zeros.
        /// </summary>
        /// <param name="sno">sequence number.</param>
        /// <returns>Formatted sequence number.</returns>
        private static string GetColumnSno(short sno)
        { 
            string result = string.Empty;
            if (sno > 99)
                result = sno.ToString();
            else if(sno > 9)
                result = "0"+sno;
            else
                result = "00"+sno;

            return result;
        }

        /// <summary>
        /// Executes the dynamic query for finding code is already exists or not.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        /// <param name="rule">Rule object with Rule Parameters.</param>
        /// <param name="businessUnit">Check with Business Uint/Not.</param>
        /// <returns>Boolean based on unique code exists.</returns>
        private static bool CheckUniqueness(object entity, RuleMapping rule, bool businessUnit = false)
        {
            bool result = false;
//            string value = (string)MethodCaller.CallByName(entity, rule.PropertyName, CallType.Get);
//            Saras.EntityFramework.EntityBase entitybase = entity as Saras.EntityFramework.EntityBase;
//            FeatureMetadata data = BusinessRulesManager.GetFeatureMetaData(rule.FeatureCode,rule.PropertyName.Trim());
////            SAF.Config.IDatabaseConfiguration config = SAF.Config.DatabaseConfigurator.GetCachingConfigData(data.ModuleName);
//              // private const string query = "SELECT COLUMN#sno# FROM #table# WHERE COLUMN#sno# = '#code#' and COLUMNC06 = '#orgid#' ";
////            string connectionString = SAF.Support.Database.DataBaseManager.GetConnectionString(config);

//            List<Tuple<string, object>> paramsql = new List<Tuple<string, object>>();
//            string queryString = query.Replace("#sno#", GetColumnSno(data.SequenceNo)).Replace("#table#", data.TableName);
//            if (businessUnit)
//                queryString = queryString + " and COLUMNC07 = '"+ entitybase.BusinessUnitID +"'";

//            paramsql.Add(new Tuple<string, object>("code", value.Replace("'", "''")));
//            paramsql.Add(new Tuple<string, object>("orgid", entitybase.OrganizationID));

            
//            DbConnection connection = SAF.Support.Database.DataBaseManager.GetConnection(data.ModuleName);

//            if (connection != null)
//            {
//                DbCommand command = connection.CreateCommand();
//                command.CommandText = queryString;
//                SAF.Support.Database.DataBaseManager.GetParam(data.ModuleName, command, paramsql);
//                command.Connection.Open();
//                object uniqueColumn = command.ExecuteScalar();
//                command.Connection.Close();
//                if (uniqueColumn == null)
//                    result = true;
//            }
            return result;
        }
        #endregion
    }
}
