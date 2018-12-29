using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Repository
{
    // TODO: VC: Attempt usage of entity

    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}
