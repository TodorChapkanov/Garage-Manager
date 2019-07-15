using System;
using System.Collections.Generic;
using System.Text;

using GarageManager.Domain;

namespace GarageManager.DAL.Contracts
{
  public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
