using CproefLib.DAL;
using CproefLib.Entities;
using CproefLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CproefLib.BL
{
    /// <summary>
    /// The business logic for the categories
    /// </summary>
    public class BL_Categories
    {
        /// <summary>
        /// Saves the model
        /// </summary>
        public static bool Save(Categories model)
        {
            try
            {
                if (model.IsNew())
                    Create(model);
                else
                    Update(model);
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        /// <summary>
        /// creates a model
        /// </summary>
        private static void Create(Categories model)
        {
            try
            {
                DAL_Categories.Create(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// update the model
        /// </summary>
        private static void Update(Categories model)
        {
            try
            {
                DAL_Categories.Update(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Deletes the model in the database
        /// </summary>
        /// <param name="model">The given category</param>
        public static void Delete(Categories model)
        {
            try
            {
                model.DeletedAt = DateTime.Now;
                Save(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get all the product categories in a list
        /// </summary>
        /// <returns>List of product categories</returns>
        public static List<Categories> GetAll()
        {
            try
            {
                return DAL_Categories.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Gets the overview for a combobox
        /// </summary>
        public static List<CategoryItem> GetOverview(int? parentId = null, string prefix = "", int excludeId = 0, bool addSelect = true)
        {
            var result = new List<CategoryItem>();

            if (addSelect)
                result.Add(new CategoryItem() { ID = null, Name = "- Select -" });


            List<Categories> _overview = DAL_Categories.GetAll(parentId, excludeId);

            foreach (var _item in _overview)
            {
                result.Add(new CategoryItem()
                {
                    ID = _item.Id,
                    Name = ($"{prefix} {_item.Name}").Trim()
                });

                string prefixNext = prefix + "-";

                result.AddRange(GetOverview(_item.Id, prefixNext, excludeId, false));
            }

            return result;
        }
    }
}
