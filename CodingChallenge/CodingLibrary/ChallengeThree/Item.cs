using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingLibrary.ChallengeThree
{
    public class Item
    {
        public Item()
        {
            Number = "10";
        }
        public Item(bool populate)
        {
            Number = "10";
            if (populate)
            {
                Items = new List<Item>(GetSubItems());
            }
        }
        public string Number { get; set; }

        public List<Item> Items { get; set; }




        /// <summary>
        /// Gets a sub-item summary for a given item number.
        /// 
        /// I had to make a few assumptions about what the code was doing and if it was part of an object and this is what i came up with.
        /// based on GetSubItmes ( **With Number**) and also Item.GetSubItems( ** No number** ) i assumed there was a parent with items and those items had children items with items but no more children.
        /// </summary>
        /// <param name="itemNumber">The item number of the item to get the sub-item summary of.</param>
        public SubItemSummary[] GetSubItemSummary(string itemNumber)
        {
            List<Item> subItems = new List<Item>(GetSubItems(itemNumber));

            List<SubItemSummary> subItemSummary = new List<SubItemSummary>();

            subItems.ForEach(i => subItemSummary.AddRange(TransformSubItems(i, i.GetSubItems())));

            return subItemSummary.ToArray();

        }

        /// <summary>
        /// Gets a sub-item summary for a given item number.
        /// </summary>
        /// <param name="itemNumber">The item number of the item to get the sub-item summary of.</param>
        public SubItemSummary[] GetSubItemSummaryCodingChallenge(string itemNumber)
        {
            IEnumerable<Item> subItems = GetSubItems(itemNumber);

            List<SubItemSummary> subItemSummary = new List<SubItemSummary>();

            foreach (Item item in subItems)
            {
                IEnumerable<SubItemSummary> tempSummaries = TransformSubItems(item, item.GetSubItems());

                subItemSummary.AddRange(tempSummaries);
            }

            return subItemSummary.ToArray();
        }
        /// <summary>
        /// Creates a list of items without subitems.
        /// </summary>
        /// <returns></returns>
        private static List<Item> GetStaticSubItems()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item() { Number = "1" });
            items.Add(new Item() { Number = "2" });
            items.Add(new Item() { Number = "3" });
            items.Add(new Item() { Number = "4" });
            return items;
        }
        /// <summary>
        /// Creates a list of items with subitems
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Item> GetSubItems()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item() { Number = "1", Items = GetStaticSubItems() });
            items.Add(new Item() { Number = "2", Items = GetStaticSubItems() });
            items.Add(new Item() { Number = "3", Items = GetStaticSubItems() });
            items.Add(new Item() { Number = "4", Items = GetStaticSubItems() });
            return items;
        }

        /// <summary>
        /// tansforms the list of subtimes into a summary
        /// </summary>
        /// <param name="item"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private IEnumerable<SubItemSummary> TransformSubItems(Item item, IEnumerable<Item> p)
        {
            List<SubItemSummary> summaries = new List<SubItemSummary>();

            foreach (var i in p)
            {
                summaries.Add(new SubItemSummary() { Parent = item, Items = new List<Item>(p) });
            }
            return summaries;
        }

        /// <summary>
        /// gets the sub items for an item
        /// </summary>
        /// <param name="itemNumber"></param>
        /// <returns></returns>
        private IEnumerable<Item> GetSubItems(string itemNumber)
        {
            return Items.Find(x => x.Number.CompareTo(itemNumber) == 0).Items;


        }
        /// <summary>
        /// Overloads for easy comparison.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Item item)
            {
                if (item.Number.CompareTo(Number) != 0)
                    return false;
                if (item.Items != null && this.Items != null)
                {
                    if (item.Items.All(o => this.Items.Contains(o)) && this.Items.All(o => item.Items.Contains(o)))
                        return true;
                }
                return true;
            }
            return false;
        }
    }
    /// <summary>
    /// Class to contain the sub item summary
    /// </summary>
    public class SubItemSummary
    {
        public Item Parent { get; set; }

        public List<Item> Items { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is SubItemSummary summary)
            {
                if (!summary.Parent.Equals(summary.Parent))
                    return false;
                if (summary.Items.All(o => this.Items.Contains(o)) && this.Items.All(o => summary.Items.Contains(o)))
                    return true;
            }
            return false;
        }
    }
}
