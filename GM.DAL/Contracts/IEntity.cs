using System;
using System.Collections.Generic;
using System.Text;

using GM.Domain;

namespace GM.DAL.Contracts
{
  public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
