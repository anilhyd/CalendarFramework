using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Framework.Utility
{
    #region Enum : TransactionalTypes
    /// <summary>
    /// Provides a list of possible transactional
    /// technologies to be used by the  Excelsoft Applicaiton.
    /// </summary>
    public enum TransactionalTypes
    {
        /// <summary>
        /// Causes the Excelsoft Applicaiton to
        /// use Enterprise Services (COM+) transactions.
        /// </summary>
        EnterpriseServices,

        /// <summary>
        /// Causes the  Excelsoft Applicaiton to
        /// use System.Transactions TransactionScope.
        /// style transactions.
        /// </summary>
        TransactionScope,

        /// <summary>
        /// Causes the  Excelsoft Applicaiton to
        /// use no explicit transactional technology.
        /// </summary>
        /// <remarks>
        /// This option allows the business developer to
        /// implement their own transactions. Common options
        /// include ADO.NET transactions and System.Transactions
        /// TransactionScope.
        /// </remarks>
        Manual
    }

    #region Enum : Search

    /// <summary>
    /// Sets the default enums for DataTypes.
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// Indicates the String datatype.
        /// </summary>
        String = 0,

        /// <summary>
        /// Indicates the Int datatype.
        /// </summary>
        Int = 1,

        /// <summary>
        /// Indicates the Decimal datatype.
        /// </summary>
        Decimal = 2,

        /// <summary>
        /// Indicates the Date datatype.
        /// </summary>
        Date = 3,
    }

    /// <summary>
    /// Search condition values.
    /// </summary>
    public enum Condition
    {
        /// <summary>
        /// Indicates the And Condition.
        /// </summary>        
        And = 0,

        /// <summary>
        /// Indicates the or condition.
        /// </summary>
        Or = 1
    }

    /// <summary>
    /// Used for setting the query operatoin.
    /// </summary>
    public enum Operator
    {
        /// <summary>
        /// Indicates the EqualsTo Operator.
        /// </summary>
        EqualsTo = 0,

        /// <summary>
        /// Indicates the not EqualsTo Operator.
        /// </summary>
        NotEqualsTo = 1,

        /// <summary>
        /// Indicates the Less than Operator.
        /// </summary>
        LessThan = 2,

        /// <summary>
        /// Indicates the Greater than Operator.
        /// </summary>
        GreaterThan = 3,

        /// <summary>
        /// Indicates the less than equal to Operator.
        /// </summary>
        LessThanEqualTo = 4,

        /// <summary>
        /// Indicates the Greater than equal to  Operator.
        /// </summary>
        GreaterThanEqualTo = 5,

        /// <summary>
        /// Indicates the between Operator.
        /// </summary>
        Between = 6,

        /// <summary>
        /// Indicates the starts with Operator.
        /// </summary>
        StartsWith = 7,

        /// <summary>
        /// Indicates the ends with Operator.
        /// </summary>
        EndsWith = 8,

        /// <summary>
        /// Indicates the contains Operator.
        /// </summary>
        Contains = 9,

        /// <summary>
        /// Indicates the does not contain Operator.
        /// </summary>
        DoesNotContain = 10,

        /// <summary>
        /// Indicates the Exact Operator.
        /// </summary>
        Exact = 11
    }

    /// <summary>
    /// Specifies the type of search.
    /// </summary>
    public enum SearchType
    {
        /// <summary>
        /// Indicates search type is Simple.
        /// </summary>
        SimpleSeearch,

        /// <summary>
        /// Indicates Search type is Viewby.
        /// </summary>
        ViewBySearch
    }

    #endregion

    #region Cache
    /// <summary>
    /// Specifies the cache object storage type.
    /// </summary>
    public enum CacheDuration
    {
        /// <summary>
        /// Assigns Long duration valua as a cache expiration value.
        /// </summary>
        LongDuration,

        /// <summary>
        /// Assigns Medim duration valua as a cache expiration value.
        /// </summary>
        MediumDuration,

        /// <summary>
        /// Assigns short duration valua as a cache expiration value.
        /// </summary>
        ShortDuration,

        /// <summary>
        /// Uses the default cache expiration time.
        /// </summary>
        None
    }
    #endregion
        
    #region Enum : License
    /// <summary>
    /// Provides a list of possible transactional
    /// technologies to be used by the  Excelsoft Applicaiton.
    /// </summary>
    public enum LicenseTypes
    {
        /// <summary>
        /// Increments the license metering Parameter.
        /// </summary>
        Increment,

        /// <summary>
        /// Decrements the licese metering Parameter.
        /// </summary>
        Decrement,

        /// <summary>
        /// Verifies the licensing Parameter exists in the licensing file or not.
        /// </summary>
        Verify
    }
    #endregion

    #region Enum : Operation

    /// <summary>
    /// Enum represents the CRUD operations.
    /// </summary>
    public enum Operation
    {
        /// <summary>
        /// Indicates operation is New data.
        /// </summary>
        Insert = 0,

        /// <summary>
        /// Indicates operation is update.
        /// </summary>
        Update = 1,

        /// <summary>
        /// Indicates operation is delete.
        /// </summary>
        Delete = 2,

        /// <summary>
        /// Indicates operation is fetch.
        /// </summary>
        Fetch = 3,

        /// <summary>
        /// Indicates operation is New.
        /// </summary>
        New = 4,

        /// <summary>
        /// Indicates operation is cancel.
        /// </summary>
        Cancel = 5,

        /// <summary>
        /// Indicates operation is Edit.
        /// </summary>
        Edit = 6,

        /// <summary>
        /// Indicates operation is Active.
        /// </summary>
        Active = 7,

        /// <summary>
        /// Indicates operation is InActive.
        /// </summary>
        InActive = 8,

        /// <summary>
        /// Indicates operation is Miscellaneous.
        /// </summary>
        Miscellaneous = 9,

        /// <summary>
        /// Indicates operation is Popup.
        /// </summary>
        Popup = 10,

        /// <summary>
        /// Indicates operation is BulkInsert.
        /// </summary>
        BulkInsert = 11,

        /// <summary>
        /// Indicates operation is Approve.
        /// </summary>
        Approve = 12,

        /// <summary>
        /// Indicates operation is IF1.
        /// </summary>
        IF1 = 13,

        /// <summary>
        /// Indicates operation is IF2.
        /// </summary>
        IF2 = 14,

        /// <summary>
        /// Indicates operation is IF3.
        /// </summary>
        IF3 = 15,

        /// <summary>
        /// Indicates operation is IF4.
        /// </summary>
        IF4 = 16

    }
    #endregion


    #endregion

    #region Rules

    #region Enum : RuleSeverity
    /// <summary>
    /// Values for validation rule severities.
    /// </summary>
    public enum RuleSeverity
    {
        /// <summary>
        /// Represents a serious
        /// business rule violation that
        /// should cause an object to
        /// be considered invalid.
        /// </summary>
        Error,

        /// <summary>
        /// Represents a business rule
        /// violation that should be
        /// displayed to the user, but which
        /// should not make an object be
        /// invalid.
        /// </summary>
        Warning,

        /// <summary>
        /// Represents a business rule
        /// result that should be displayed
        /// to the user, but which is less
        /// severe than a warning.
        /// </summary>
        Information,

        /// <summary>
        /// Represents a business rule
        /// result that should not
        /// be displayed to the user,
        /// and where the rule was
        /// successful.
        /// </summary>
        Success
    }
    #endregion

    #region Enum : Execution Status
    /// <summary>
    /// Provides a list of possible Excution stauses.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Indicates the Success status.
        /// </summary>
        Success,

        /// <summary>
        /// Indicates the Excuting status.
        /// </summary>
        Executing,

        /// <summary>
        /// Indicates the Failed status.
        /// </summary>
        Failed,

        /// <summary>
        /// Indicates the Inprocess status.
        /// </summary>
        InProcess
    }
    #endregion

    #region Enum : Rule Type

    /// <summary>
    /// Values for Rule type.
    /// </summary>
    public enum RuleType
    {
        /// <summary>
        /// Indicates Rule type to business rule.
        /// </summary>
        BusinessRule,

        /// <summary>
        /// Indicates rule type to validation.
        /// </summary>
        Validation
    }

    /// <summary>
    /// Indicates the reason the MobileFormatter
    /// functionality has been invoked.
    /// </summary>
    public enum StateMode
    {
        /// <summary>
        /// The object is being serialized for
        /// a clone or data portal operation.
        /// </summary>
        Serialization,

        /// <summary>
        /// The object is being serialized for
        /// an n-level undo operation.
        /// </summary>
        Undo
    }
    #endregion

    #region Enum : CallType

    /// <summary>
    /// Valid options for calling a property or method
    /// via the <see cref="Csla.MethodCaller.CallByName"/> method.
    /// </summary>
    public enum CallType
    {
        /// <summary>
        /// Gets a value from a property.
        /// </summary>
        Get,

        /// <summary>
        /// Sets a value into a property.
        /// </summary>
        Let,

        /// <summary>
        /// Invokes a method.
        /// </summary>
        Method,

        /// <summary>
        /// Sets a value into a property.
        /// </summary>
        Set,

        /// <summary>
        /// Get a value from varible.
        /// </summary>
        GetFieldValue,

        /// <summary>
        /// Sets the value to field.
        /// </summary>
        SetFieldValue
    }
    #endregion
    #endregion


}
