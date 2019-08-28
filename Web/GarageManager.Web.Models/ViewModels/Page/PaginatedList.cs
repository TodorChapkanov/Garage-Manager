using System.Collections;
using System.Collections.Generic;

namespace GarageManager.Web.Models.ViewModels.Page
{
    public class PaginatedList<T> :  IEnumerable<T>
    {
        
        
        public PaginatedList(IEnumerable<T> items)
        {
            this.Data = items;
        }
        public IEnumerable<T> Data { get; private set; }

        public IEnumerator<T> GetEnumerator() => this.Data.GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        
    }
}
