using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace StreamWriter
{
    public class ObservableCollectionWithItemNotify<T> : ObservableCollection<T>
    {

        public ObservableCollectionWithItemNotify()
        {
            this.CollectionChanged += items_CollectionChanged;
        }


        public ObservableCollectionWithItemNotify(IEnumerable<T> collection) : base(collection)
        {
            Console.WriteLine("Observable Object changed");
            this.CollectionChanged += items_CollectionChanged;
            foreach (INotifyPropertyChanged item in collection)
                item.PropertyChanged += item_PropertyChanged;

        }

        private void items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Observable Object changed");
            if (e != null)
            {
                if (e.OldItems != null)
                    foreach (INotifyPropertyChanged item in e.OldItems)
                        item.PropertyChanged -= item_PropertyChanged;

                if (e.NewItems != null)
                    foreach (INotifyPropertyChanged item in e.NewItems)
                        item.PropertyChanged += item_PropertyChanged;
            }
        }

        private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("Observable Object changed");
            var reset = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
            this.OnCollectionChanged(reset);

        }

    }
}