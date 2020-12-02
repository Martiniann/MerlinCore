using Merlin2d.Game.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merlin_Core.Actors.Items
{
    public class Backpack : IInventory
    {
        private IItem[] items;
        
        private int capacity;
        private int position = 0;


        public Backpack(int capacity)
        {
            items = new IItem[capacity];
            this.capacity = capacity;
        }

        public void AddItem(IItem item)
        {
            try
            {
                items[position++] = item;
            }
            catch
            {
                throw new FullInventoryException("Inventory is full!");
            }

        }

        public int GetCapacity()
        {
            return capacity;
        }

        public IEnumerator<IItem> GetEnumerator()
        {
            foreach(IItem item in items)
            {
                if (item == null)
                {
                    continue;
                }
                yield return item;
            }
        }

        public IItem GetItem()
        {
            foreach (IItem item in items)
            {
                if (item != null)
                {
                    return item;
                }
            }
            return null;
        }

        public void RemoveItem(IItem item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].GetType() == item.GetType())
                {
                    items[i] = null;
                    break;
                }
            }
        }

        public void RemoveItem(int index)
        {

            items[index] = null;
        }

        public void ShiftLeft()
        {
            IItem[] demo = new IItem[items.Length];
            int nulls = 0;
            foreach(IItem item in items)
            {
                if (item == null)
                {
                    nulls++;
                }
            }
            for (int i = 0; i < items.Length - 1 - nulls; i++)
            {
                demo[i] = items[i + 1];
            }

            demo[demo.Length - 1 - nulls] = items[0];

            items = demo;
        }

        public void ShiftRight()
        {
            IItem[] demo = new IItem[items.Length];
            int nulls = 0;
            foreach (IItem item in items)
            {
                if (item == null)
                {
                    nulls++;
                }
            }

            for (int i = 1; i < items.Length - nulls; i++)
            {

                demo[i] = items[i - 1];
            }

            demo[0] = items[items.Length - 1 - nulls];

            items = demo;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
