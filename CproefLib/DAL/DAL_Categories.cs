using CproefLib.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CproefLib.DAL
{
    /// <summary>
    /// Data access layer of categories
    /// </summary>
    public class DAL_Categories
    {
        /// <summary>
        /// Creates a new category in the database
        /// </summary>
        /// <param name="model">The new category</param>
        public static void Create(Categories model)
        {
            var ctx = AppDbContext.Instance();

            ctx.Categories.Add(model);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Update the record in the database
        /// </summary>
        /// <param name="model">The given record</param>
        public static void Update(Categories model)
        {
            var ctx = AppDbContext.Instance();

            ctx.Entry(model).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        /// <summary>
        /// Gets all the categories from the database
        /// </summary>
        /// <returns>List of categories</returns>
        public static List<Categories> GetAll()
        {
            var ctx = AppDbContext.Instance();

            return ctx.Categories.Where(pc => pc.DeletedAt == null).ToList();
        }

        /// <summary>
        /// Gets all the categories with the given parentId ordered by the name from the database
        /// </summary>
        /// <param name="parentId">The parentId</param>
        /// <param name="excludeId">The id that isn't allowed in the list</param>
        /// <returns>List of categories</returns>
        public static List<Categories> GetAll(int? parentId, int excludeId = 0)
        {
            var ctx = AppDbContext.Instance();

            return ctx.Categories
                        .Where(pc => pc.DeletedAt == null && pc.ParentId == parentId && pc.Id != excludeId)
                        .OrderBy(pc => pc.Name)
                        .ToList();
        }
    }
}
