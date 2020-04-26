using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ElectronicsShop.Models.DbModels;

namespace ElectronicsShop.Models
{
    public class TagManager
    {
        public static List<TagNameWithValue> GetTagNameWithValues(ApplicationDbContext context, Product product)
        {
            var tags =  GetTagsForProduct(context, product.Id);

            var valuesList =  GetValuesForProduct(context, product.Id);

            var tagValues = new List<TagNameWithValue>();
            for (int i = 0; i < tags.Count; i++)
            {
                tagValues.Add(new TagNameWithValue()
                {
                    Name = tags.ToList()[i].Name,
                    Value = valuesList.ToList()[i].Value
                });
            }

            return tagValues;
        }

        public static List<Tag> GetTagsForProduct(ApplicationDbContext context, int productId)
        {
            var tags =
                from tag in context.Tags
                join values in context.TagValues on tag.Id equals values.TagId
                join productTags in context.Products on values.ProductId equals productTags.Id
                where productTags.Id == productId
                orderby tag.Id
                select tag;

            return tags.ToList();
        }

        public static List<TagValue> GetValuesForProduct(ApplicationDbContext _context, int productId)
        {
            var valuesList = from tag in _context.Tags
                join values in _context.TagValues on tag.Id equals values.TagId
                join productTags in _context.Products on values.ProductId equals productTags.Id
                where productTags.Id == productId
                orderby tag.Id
                select values;

            return valuesList.ToList();
        }

    }
}