#region Header Info
//-----------------------------------------------------------------------
// <copyright file="DynamicMethodHandle.cs" company="Calendar.Framework Ltd.">
//  Copyright (c) Calendar.Framework Ltd. All rights reserved. Website: 
// </copyright>
// <summary>Handles the dynamic methods.</summary>
// <createdby>Desayya</createdby> 
// <createddate>11-July-2010</createddate>
// <revisionhistory>
//  <revision modifiedby='' modifieddate='' revisionno=''></revision>
// </revisionhistory>
//-----------------------------------------------------------------------
#endregion

#region Namespaces

using System;
using System.Reflection;

#endregion

namespace Calendar.Framework.Runtime
{
    /// <summary>
    /// Handles dynamic methods at runtime.
    /// </summary>
    internal class DynamicMethodHandle
    {
        /// <summary>
        ///  Initializes a new instance of the DynamicMethodHandle class.
        /// </summary>
        /// <param name="info">Method info object.</param>
        /// <param name="parameters">Method Parameters.</param>
        public DynamicMethodHandle(System.Reflection.MethodInfo info, params object[] parameters)
        {
            if (info == null)
            {
                this.DynamicMethod = null;
            }
            else
            {
                this.MethodName = info.Name;
                var infoParams = info.GetParameters();
                object[] inParams = null;
                if (parameters == null)
                {
                    inParams = new object[] { null };
                }
                else
                {
                    inParams = parameters;
                }

                var paramCount = infoParams.Length;
                if (paramCount > 0 &&
                   ((paramCount == 1 && infoParams[0].ParameterType.IsArray) ||
                   (infoParams[paramCount - 1].GetCustomAttributes(typeof(ParamArrayAttribute), true).Length > 0)))
                {
                    this.HasFinalArrayParam = true;
                    this.MethodParamsLength = paramCount;
                    this.FinalArrayElementType = infoParams[paramCount - 1].ParameterType;
                }

                this.DynamicMethod = DynamicMethodHandlerFactory.CreateMethod(info);
            }
        }

        /// <summary>
        /// Gets the Method Name.
        /// </summary>
        public string MethodName { get; private set; }

        /// <summary>
        /// Gets the Dynamic method delegate.
        /// </summary>
        public DynamicMethodDelegate DynamicMethod { get; private set; }

        /// <summary>
        /// Gets a value indicating whether Final Array if exists.
        /// </summary>
        public bool HasFinalArrayParam { get; private set; }

        /// <summary>
        /// Gets the lenth of the parameters in a method.
        /// </summary>
        public int MethodParamsLength { get; private set; }

        /// <summary>
        /// Gets the Final Array Element type.
        /// </summary>
        public Type FinalArrayElementType { get; private set; }
    }
}