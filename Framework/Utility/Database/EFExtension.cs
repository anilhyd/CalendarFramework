using Microsoft.EntityFrameworkCore;
using Calendar.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Calendar.Framework.Database
{
    public static class EFExtension
    {

        #region Assign Default Values
        /// <summary>
        /// Enables the tracking for modification and deletions in the Entity.
        /// </summary>
        /// <typeparam name="T">Type fo Entity object.</typeparam>
        /// <param name="trackingItem">Entity object.</param>
        /// <param name="userContext">User context object.</param>
        public static void AssignDefaultValues<T>(this T entity, UserContext userContext, string operation) where T : EntityBase
        {
            if (entity.EntityObjects == null)
                entity.EntityObjects = new List<EntityBase>();
            else if (entity.EntityObjects.Count > 0)
            {
                foreach (EntityBase entityObject in (entity as EntityBase).EntityObjects)
                    entityObject.IsVisited = false;

                entity.EntityObjects.Clear();
            }

            BuildEntityObjects(entity, entity);

            foreach (EntityBase entityObject in entity.EntityObjects)
                CopyDefaultColumnValues(userContext, operation, entityObject);

            // ClearVisiting(entity);
        }

        private static void BuildEntityObjects(EntityBase parentEntity, EntityBase original)
        {
            if (parentEntity == null)
            {
                throw new ArgumentNullException("trackingItem");
            }

            if (parentEntity.IsVisited == false)
            {
                parentEntity.IsVisited = true;
                Type entityObject = parentEntity.GetType();

                foreach (PropertyInfo propertyInfo in entityObject.GetProperties())
                {
                    if (propertyInfo.GetGetMethod().Invoke(parentEntity, new object[0]) != null)
                    {
                        // for Checking the Collectin of Entity
                        var collection = propertyInfo.GetGetMethod().Invoke(parentEntity, new object[0]) as IEnumerable<EntityBase>;
                        if (collection != null && collection.Count() > 0)
                        {
                            foreach (EntityBase entitybase in collection)
                                if (entitybase.IsVisited == false)
                                    BuildEntityObjects(entitybase, original);
                        }
                        else
                        {
                            EntityBase entitybase = propertyInfo.GetGetMethod().Invoke(parentEntity, new object[0]) as EntityBase;
                            if (entitybase != null && entitybase.IsVisited == false)
                            {
                                BuildEntityObjects(entitybase, original);
                            }
                        }
                    }
                }
                original.EntityObjects.Add(parentEntity);
            }
        }
        #endregion

        #region Private Methods
        internal static void CopyDefaultColumnValues(UserContext context, string operation, EntityBase entity)
        {
            if (string.IsNullOrWhiteSpace(entity.CreatedBy))
            {
                entity.CreatedBy = context.UserID;
            }

            if (entity.LanguageId == null || entity.LanguageId.Equals(""))
                entity.LanguageId = "en-US";

            if (entity.RowState.Equals(EntityState.Added) || operation.Equals("Insert"))
            {
                DateTime dtNow = DateTime.UtcNow;
                entity.CreatedDate = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, dtNow.Hour, dtNow.Minute, dtNow.Second, dtNow.Millisecond);

                //this.RecordState = 0;
                //this.WorkflowState = 0;
                //entity.LastUpdatedDate = DateTime.UtcNow;

                entity.LastUpdatedDate = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, dtNow.Hour, dtNow.Minute, dtNow.Second, dtNow.Millisecond);
            }

            if (string.IsNullOrWhiteSpace(entity.LastUpdatedBy))
            {
                entity.LastUpdatedBy = context.UserID;
            }

        }

        //private static void ClearVisiting<T>(this T trackingItem) where T : IObjectWithChangeTracker
        //{
        //    trackingItem.ChangeTracker.IsVisited = false;
        //    ObjectChangeTracker tracker = trackingItem.ChangeTracker;

        //    if (tracker.TrackEntities != null)
        //    {
        //        foreach (KeyValuePair<string, ObjectList> kvp in tracker.TrackEntities)
        //        {
        //            ObjectList list = kvp.Value;
        //            foreach (object childObject in list)
        //            {
        //                var childEntity = childObject as IObjectWithChangeTracker;
        //                if (childEntity != null)
        //                {
        //                    if (childEntity.ChangeTracker.IsVisited)
        //                    {
        //                        childEntity.ChangeTracker.IsVisited = false;

        //                        if (childEntity.ChangeTracker.TrackEntities.Count > 0)
        //                            ClearVisiting(childEntity);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        #endregion

    }
}
