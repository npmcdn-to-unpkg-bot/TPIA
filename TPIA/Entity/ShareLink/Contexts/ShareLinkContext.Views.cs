//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Entity.Infrastructure.MappingViews;

[assembly: DbMappingViewCacheTypeAttribute(
    typeof(TPIA.Entity.ShareLink.Contexts.ShareLinkContext),
    typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySets3c19356321497d2d2a57dc6fa58202003a520659cae07d3c842592c32c0130b9))]

namespace Edm_EntityMappingGeneratedViews
{
    using System;
    using System.CodeDom.Compiler;
    using System.Data.Entity.Core.Metadata.Edm;

    /// <summary>
    /// Implements a mapping view cache.
    /// </summary>
    [GeneratedCode("Entity Framework Power Tools", "0.9.0.0")]
    internal sealed class ViewsForBaseEntitySets3c19356321497d2d2a57dc6fa58202003a520659cae07d3c842592c32c0130b9 : DbMappingViewCache
    {
        /// <summary>
        /// Gets a hash value computed over the mapping closure.
        /// </summary>
        public override string MappingHashValue
        {
            get { return "3c19356321497d2d2a57dc6fa58202003a520659cae07d3c842592c32c0130b9"; }
        }

        /// <summary>
        /// Gets a view corresponding to the specified extent.
        /// </summary>
        /// <param name="extent">The extent.</param>
        /// <returns>The mapping view, or null if the extent is not associated with a mapping view.</returns>
        public override DbMappingView GetView(EntitySetBase extent)
        {
            if (extent == null)
            {
                throw new ArgumentNullException("extent");
            }

            var extentName = extent.EntityContainer.Name + "." + extent.Name;

            if (extentName == "CodeFirstDatabase.ShareLink")
            {
                return GetView0();
            }

            if (extentName == "ShareLinkContext.ShareLink")
            {
                return GetView1();
            }

            return null;
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.ShareLink.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView0()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing ShareLink
        [CodeFirstDatabaseSchema.ShareLink](T1.ShareLink_LID, T1.ShareLink_Category, T1.ShareLink_Title, T1.ShareLink_Description, T1.ShareLink_ImgUrl, T1.ShareLink_LinkUrl)
    FROM (
        SELECT 
            T.LID AS ShareLink_LID, 
            T.Category AS ShareLink_Category, 
            T.Title AS ShareLink_Title, 
            T.Description AS ShareLink_Description, 
            T.ImgUrl AS ShareLink_ImgUrl, 
            T.LinkUrl AS ShareLink_LinkUrl, 
            True AS _from0
        FROM ShareLinkContext.ShareLink AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for ShareLinkContext.ShareLink.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView1()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing ShareLink
        [TPIA.Entity.ShareLink.Contexts.ShareLink](T1.ShareLink_LID, T1.ShareLink_Category, T1.ShareLink_Title, T1.ShareLink_Description, T1.ShareLink_ImgUrl, T1.ShareLink_LinkUrl)
    FROM (
        SELECT 
            T.LID AS ShareLink_LID, 
            T.Category AS ShareLink_Category, 
            T.Title AS ShareLink_Title, 
            T.Description AS ShareLink_Description, 
            T.ImgUrl AS ShareLink_ImgUrl, 
            T.LinkUrl AS ShareLink_LinkUrl, 
            True AS _from0
        FROM CodeFirstDatabase.ShareLink AS T
    ) AS T1");
        }
    }
}
